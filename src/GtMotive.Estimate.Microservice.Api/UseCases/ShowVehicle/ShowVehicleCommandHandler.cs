using System;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ShowVehicle;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ShowVehicle
{
    public class ShowVehicleCommandHandler : IRequestHandler<ShowVehicleCommand, ErrorOr<ShowVehicleOutput>>
    {
        private readonly IShowVehicleUseCase _showVehicleUseCase;
        private readonly IUnitOfWork _unitOfWork;

        public ShowVehicleCommandHandler(IShowVehicleUseCase showVehicleUseCase, IUnitOfWork unitOfWork)
        {
            _showVehicleUseCase = showVehicleUseCase ?? throw new ArgumentNullException(nameof(showVehicleUseCase));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<ShowVehicleOutput>> Handle(ShowVehicleCommand request, CancellationToken cancellationToken)
        {
            if (request is not null)
            {
                var input = new ShowVehicleInput(request.IdFleet);
                var response = await _showVehicleUseCase.Execute(input);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return response.Value;
            }

            return Domain.Errors.Errors.Renting.VehicleDoesNotExists;
        }
    }
}
