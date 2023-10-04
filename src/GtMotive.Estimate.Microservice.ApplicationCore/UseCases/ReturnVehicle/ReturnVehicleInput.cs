using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    ///  Input data for return a rented vehicle.
    /// </summary>
    public class ReturnVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleInput"/> class.
        /// </summary>
        /// <param name="idRenting">idRenting.</param>
        public ReturnVehicleInput(Guid idRenting)
        {
            IdRenting = idRenting;
        }

        /// <summary>
        /// Gets or sets renting identifier.
        /// </summary>
        public Guid IdRenting { get; set; }
    }
}
