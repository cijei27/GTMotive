using System;
using System.Threading.Tasks;
using ErrorOr;
using FluentAssertions;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.Api.Renting.CreateVehicle
{
    public class CreateVehicleCommandHandlerTest
    {
        private readonly Mock<ICreateVehicleUseCase> _mockVehicleRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly CreateVehicleCommandHandler _handler;

        public CreateVehicleCommandHandlerTest()
        {
            _mockVehicleRepository = new Mock<ICreateVehicleUseCase>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _handler = new CreateVehicleCommandHandler(_mockVehicleRepository.Object, _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task HandleCreateVehicleWhenAllParametersAreCorrectsShouldReturnVehicleCreated()
        {
            // Arrange
            var idFleet = Guid.Parse("52ab6d63-5fc8-4d6e-b110-1df6937333e3");
            var plateNumber = "4532IJK";
            var model = "Ford";
            var brand = "Fiesta";
            var registration = DateTime.UtcNow;
            var renting = false;

            var command = new CreateVehicleCommand(idFleet, plateNumber, model, brand, registration, renting);

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            result.IsError.Should().BeFalse();
            result.Should().BeOfType<ErrorOr<CreateVehicleOutput>>();
        }
    }
}
