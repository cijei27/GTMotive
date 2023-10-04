using System;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using GtMotive.Estimate.Microservice.Api;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.RentingVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.ReturnVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.ShowVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.Data;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Host.Configuration;
using GtMotive.Estimate.Microservice.Host.DependencyInjection;
using GtMotive.Estimate.Microservice.Infrastructure;
using GtMotive.Estimate.Microservice.Infrastructure.Database;
using GtMotive.Estimate.Microservice.Infrastructure.Database.Repositories;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using IdentityServer4.AccessTokenValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

var builder = WebApplication.CreateBuilder();

// Configuration.
if (!builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile("serilogsettings.json", optional: false, reloadOnChange: true);

    var secretClient = new SecretClient(
        new Uri($"https://{builder.Configuration.GetValue<string>("KeyVaultName")}.vault.azure.net/"),
        new DefaultAzureCredential());

    builder.Configuration.AddAzureKeyVault(secretClient, new KeyVaultSecretManager());
}

// Logging configuration for host bootstrapping.
builder.Logging.ClearProviders();

builder.Host.UseSerilog();

// Add services to the container.
if (!builder.Environment.IsDevelopment())
{
    builder.Services.AddApplicationInsightsTelemetry(builder.Configuration);
    builder.Services.AddApplicationInsightsKubernetesEnricher();
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddTransient<IRentingRepository, RentingRepository>();
builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<CreateVehicleCommandHandler>();
builder.Services.AddScoped<RentingVehicleCommandHandler>();
builder.Services.AddScoped<ReturnVehicleCommandHandler>();
builder.Services.AddScoped<ShowVehicleCommandHandler>();
builder.Services.AddDbContext<RentingContext>(options =>
{
    options.UseInMemoryDatabase("RentingDb")
        .EnableSensitiveDataLogging()
    .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning));
});

builder.Services.AddScoped<IRentingContext>(sp =>
        sp.GetRequiredService<RentingContext>());

builder.Services.AddScoped<IUnitOfWork>(sp =>
        sp.GetRequiredService<RentingContext>());
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);
var appSettings = appSettingsSection.Get<AppSettings>();
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDb"));

builder.Services.AddControllers(ApiConfiguration.ConfigureControllers)
    .WithApiControllers();

builder.Services.AddBaseInfrastructure(builder.Environment.IsDevelopment());

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                               ForwardedHeaders.XForwardedProto;

    // Only loopback proxies are allowed by default.
    // Clear that restriction because forwarders are enabled by explicit
    // configuration.
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
    })
    .AddIdentityServerAuthentication(options =>
    {
        options.Authority = appSettings.JwtAuthority;
        options.ApiName = "estimate-api";
        options.SupportedTokens = SupportedTokens.Jwt;
    });

builder.Services.AddSwagger(appSettings, builder.Configuration);

var app = builder.Build();

var pathBase = new PathBase(builder.Configuration.GetValue("PathBase", defaultValue: PathBase.DefaultPathBase));

if (pathBase.IsDefault == false)
{
    app.UsePathBase(pathBase.CurrentWithoutTrailingSlash);
}

app.UseForwardedHeaders();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwaggerInApplication(pathBase, builder.Configuration);
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
