using System;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentingVehicle;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.RentingVehicle
{
    public class RentingVehicleCommandHandler : IRequestHandler<RentingVehicleCommand, ErrorOr<RentingVehicleOutput>>
    {
        private readonly IRentingVehicleUseCase _rentingVehicleUseCase;
        private readonly IUnitOfWork _unitOfWork;

        public RentingVehicleCommandHandler(IRentingVehicleUseCase rentingVehicleUseCase, IUnitOfWork unitOfWork)
        {
            _rentingVehicleUseCase = rentingVehicleUseCase ?? throw new ArgumentNullException(nameof(rentingVehicleUseCase));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<RentingVehicleOutput>> Handle(RentingVehicleCommand request, CancellationToken cancellationToken)
        {
            if (request is not null)
            {
                var input = new RentingVehicleInput(request.IdVehicle, request.DNICustomer, request.StartRenting, request.FinishRenting);
                var response = await _rentingVehicleUseCase.Execute(input);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return response;
            }

            return Domain.Errors.Errors.Renting.RentingNotCreated;
        }
    }
}
