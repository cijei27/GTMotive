using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentingVehicle
{
    /// <summary>
    /// The input data for renting a vehicle.
    /// </summary>
    public class RentingVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentingVehicleInput"/> class.
        /// </summary>
        /// <param name="idVehicle">Unique identifier of the car.</param>
        /// <param name="dniCustomer">Unique identifier of the customer.</param>
        /// <param name="startRenting">When the renting starts.</param>
        /// <param name="finishRenting">When the renting will be finished.</param>
        public RentingVehicleInput(Guid idVehicle, string dniCustomer, DateTime startRenting, DateTime finishRenting)
        {
            IdVehicle = idVehicle;
            DNICustomer = dniCustomer;
            StartRenting = startRenting;
            FinishRenting = finishRenting;
        }

        /// <summary>
        /// Gets or sets the unique identifier of the renting.
        /// </summary>
        public Guid IdVehicle { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the renting.
        /// </summary>
        public string DNICustomer { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the renting.
        /// </summary>
        public DateTime StartRenting { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the renting.
        /// </summary>
        public DateTime FinishRenting { get; set; }
    }
}
