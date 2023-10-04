using System;
using GtMotive.Estimate.Microservice.Domain.Primitives;

namespace GtMotive.Estimate.Microservice.Domain.Renting
{
    /// <summary>
    /// Class Vehicle.
    /// </summary>
    public class VehicleEntity : AggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleEntity"/> class.
        /// Constructor by default.
        /// </summary>
        public VehicleEntity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleEntity"/> class.
        /// </summary>
        /// <param name="idVehicle">Guid of the vehicle.</param>
        /// <param name="idFleet">Guid of the vehicle's fleet.</param>
        /// <param name="plateNumber">the unique identifier of the car.</param>
        /// <param name="model">The model of the car.</param>
        /// <param name="brand">The brand of the car.</param>
        /// <param name="power">CV.</param>
        /// <param name="colour">Colour.</param>
        /// <param name="fuelType">Gasoil, Diesel or electric car.</param>
        /// <param name="seatsNumber">Numbers of seats.</param>
        /// <param name="registration">Manufacturing date of the car.</param>
        /// <param name="renting">Show if the vehicle is renting or not.</param>
        public VehicleEntity(Guid idVehicle, Guid idFleet, string plateNumber, string model, string brand, DateTime registration, bool renting)
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
        /// Gets or sets a value indicating whether the vehicle is renting or not.
        /// </summary>
        public bool Renting { get; set; }
    }
}
