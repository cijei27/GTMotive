using GtMotive.Estimate.Microservice.Domain.Renting;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    public class MongoService
    {
        private readonly IMongoDatabase _database;

        public MongoService(IOptions<MongoDbSettings> options)
        {
            if (options is not null)
            {
                MongoClient = new MongoClient(options.Value.ConnectionString);
                _database = MongoClient.GetDatabase(options.Value.MongoDbDatabaseName);
            }
        }

        public MongoClient MongoClient { get; }

        public IMongoCollection<VehicleEntity> Vehicles => _database.GetCollection<VehicleEntity>("Vehicle");

        public IMongoCollection<RentingEntity> Renting => _database.GetCollection<RentingEntity>("Renting");
    }
}
