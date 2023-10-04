using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Domain.Renting;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ShowVehicle
{
    /// <summary>
    /// output data.
    /// </summary>
    public class ShowVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShowVehicleOutput"/> class.
        /// </summary>
        /// <param name="vehicles">The list of available vehicles.</param>
        public ShowVehicleOutput(ICollection<VehicleEntity> vehicles)
        {
            Vehicles = vehicles;
        }

        /// <summary>
        /// Gets the list of available vehicles.
        /// </summary>
        public ICollection<VehicleEntity> Vehicles { get; }
    }
}
