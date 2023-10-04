namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Represents an interface for the output port responsible for handling the results of creating a vehicle.
    /// </summary>
    public interface ICreateVehicleOutputPort : IOutputPortStandard<CreateVehicleOutput>
    {
        /// <summary>
        /// Handles an exception that occurred during the vehicle creation process.
        /// </summary>
        /// <param name="message">The error message describing the exception.</param>
        void ExceptionHandle(string message);
    }
}
