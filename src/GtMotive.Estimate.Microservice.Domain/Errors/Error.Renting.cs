using ErrorOr;

namespace GtMotive.Estimate.Microservice.Domain.Errors
{
    /// <summary>
    /// Errors.
    /// </summary>
    public static partial class Errors
    {
        /// <summary>
        /// Errors for renting.
        /// </summary>
        public static class Renting
        {
            /// <summary>
            /// Gets error when Vehicle is out of the fleet to be rented.
            /// </summary>
            public static Error RentingCarNotAvailable =>
                Error.Validation("VehicleEntity.Registration", "Vehicle is out of the fleet to be rented");

            /// <summary>
            /// Gets get error when customer has a renting pending.
            /// </summary>
            public static Error CustomerHasRentingActive =>
                Error.Validation("VehicleEntity.Renting", "Customer has a renting pending.");

            /// <summary>
            /// Gets vehicle does not exist in our database.
            /// </summary>
            public static Error VehicleDoesNotExists =>
                Error.Validation("VehicleEntity.IdVehicle", "Vehicle does not exist in our database.");

            /// <summary>
            /// Gets errors when renting does not exists in our database.
            /// </summary>
            public static Error RentingIsNotAvailable =>
                Error.Validation("Renting.IdRenting", "Renting does not exists.");

            /// <summary>
            /// Gets errors when renting could no created.
            /// </summary>
            public static Error RentingNotCreated =>
                Error.Validation("Renting.IdRenting", "Renting could not created.");
        }
    }
}
