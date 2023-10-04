namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentingVehicle
{
    /// <summary>
    /// An interface for the output port to handle the results of renting a vehicle.
    /// </summary>
    public interface IRentingVehiculeOutputPort : IOutputPortStandard<RentingVehicleOutput>, IOutputPortNotFound
    {
        /// <summary>
        /// Handles an exception that occurred during the vehicle creation process.
        /// </summary>
        /// <param name="message">The error message describing the exception.</param>
        void ExceptionHandle(string message);
    }
}
