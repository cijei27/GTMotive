using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// class for creating a vehicle.
    /// </summary>
    public class CreateVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleInput"/> class.
        /// </summary>
        /// <param name="idFleet">idFleet.</param>
        /// <param name="plateNumber">plateNumber.</param>
        /// <param name="model">model.</param>
        /// <param name="brand">brand.</param>
        /// <param name="registration">registration.</param>
        /// <param name="renting">renting.</param>
        public CreateVehicleInput(Guid idFleet, string plateNumber, string model, string brand, DateTime registration, bool renting)
        {
            IdFleet = idFleet;
            PlateNumber = plateNumber;
            Model = model;
            Brand = brand;
            Registration = registration;
            Renting = renting;
        }

        /// <summary>
        /// Gets or sets guid of the vehicle's fleet..
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
