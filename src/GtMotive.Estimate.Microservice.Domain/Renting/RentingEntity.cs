using System;
using GtMotive.Estimate.Microservice.Domain.Primitives;

namespace GtMotive.Estimate.Microservice.Domain.Renting
{
    /// <summary>
    /// Class renting.
    /// </summary>
    public class RentingEntity : AggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentingEntity"/> class.
        /// Constructor by default.
        /// </summary>
        public RentingEntity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RentingEntity"/> class.
        /// </summary>
        /// <param name="idRenting">Unique identifier of the renting.</param>
        /// <param name="idVehicle">Unique identifier of the car.</param>
        /// <param name="dniCustomer">Unique identifier of the customer.</param>
        /// <param name="startRenting">When the renting starts.</param>
        /// <param name="finishRenting">When the renting will be finished.</param>
        public RentingEntity(Guid idRenting, Guid idVehicle, string dniCustomer, DateTime startRenting, DateTime finishRenting)
        {
            IdRenting = idRenting;
            IdVehicle = idVehicle;
            DNICustomer = dniCustomer;
            StartRenting = startRenting;
            FinishRenting = finishRenting;
        }

        /// <summary>
        /// Gets or sets the unique identifier of the renting.
        /// </summary>
        public Guid IdRenting { get; set; }

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
