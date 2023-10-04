namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ShowVehicle
{
    /// <summary>
    /// interface for the output port to handle all the vehicles.
    /// </summary>
    public interface IShowVehicleOutputPort : IOutputPortStandard<ShowVehicleOutput>
    {
        /// <summary>
        /// Handles an exception that occurred during the retrieval of available vehicles.
        /// </summary>
        /// <param name="message">The error message describing the exception.</param>
        void ExceptionHandle(string message);
    }
}
