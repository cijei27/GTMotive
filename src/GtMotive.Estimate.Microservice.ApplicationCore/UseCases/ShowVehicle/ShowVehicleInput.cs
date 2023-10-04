using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ShowVehicle
{
    /// <summary>
    /// input data to all availables vehicles.
    /// </summary>
    public class ShowVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShowVehicleInput"/> class.
        /// </summary>
        /// <param name="idFleet">The ID of the fleet for which available vehicles will be retrieved.</param>
        public ShowVehicleInput(Guid idFleet)
        {
            IdFleet = idFleet;
        }

        /// <summary>
        /// Gets the ID of the fleet for which available vehicles will be retrieved.
        /// </summary>
        public Guid IdFleet { get; private set; }
    }
}
