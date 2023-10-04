using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Represents the output data produced by the use case for creating a vehicle.
    /// </summary>
    public class CreateVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleOutput"/> class.
        /// </summary>
        /// <param name="idVehicle">idVehicle.</param>
        /// <param name="idFleet">idFleet.</param>
        /// <param name="plateNumber">plateNumber.</param>
        /// <param name="model">model.</param>
        /// <param name="brand">brand.</param>
        /// <param name="registration">registration.</param>
        /// <param name="renting">renting.</param>
        public CreateVehicleOutput(Guid idVehicle, Guid idFleet, string plateNumber, string model, string brand, DateTime registration, bool renting)
        {
            IdVehicle = idVehicle;
            IdFleet = idFleet;
            PlateNumber = plateNumber;
            Model = model;
            Brand = brand;
            Registration = registration;
            Renting = renting;
        }

        /// <summary>
        /// Gets or sets guid of the vehicle.
        /// </summary>
        public Guid IdVehicle { get; set; }

        /// <summary>
        /// Gets or sets guid of the vehicle's fleet.
        /// </summary>
        public Guid IdFleet { get; set; }

        /// <summary>
        /// Gets or sets guid of the unique identifier of the car.
        /// </summary>
        public string PlateNumber { get; set; }

        /// <summary>
        /// Gets or sets guid of the model.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets guid of the brand.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets guid of the manufacturing date of the car.
        /// </summary>
        public DateTime Registration { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets guid of the vehicle.
        /// </summary>
        public bool Renting { get; set; }
    }
}
