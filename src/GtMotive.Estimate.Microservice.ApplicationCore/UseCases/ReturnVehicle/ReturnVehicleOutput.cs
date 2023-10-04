namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// The output retunr vehicle class.
    /// </summary>
    public class ReturnVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleOutput"/> class.
        /// </summary>
        /// <param name="messageStatus">messageStatus.</param>
        public ReturnVehicleOutput(string messageStatus)
        {
            MessageStatus = messageStatus;
        }

        /// <summary>
        /// Gets or sets a message to the status of the vehicle.
        /// </summary>
        public string MessageStatus { get; set; }
    }
}
