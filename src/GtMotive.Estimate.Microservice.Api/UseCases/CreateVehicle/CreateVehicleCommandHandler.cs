using System;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, ErrorOr<CreateVehicleOutput>>
    {
        private readonly ICreateVehicleUseCase _createVehicleUseCase;
        private readonly IUnitOfWork _unitOfWork;

        public CreateVehicleCommandHandler(ICreateVehicleUseCase createVehicleUseCase, IUnitOfWork unitOfWork)
        {
            _createVehicleUseCase = createVehicleUseCase ?? throw new ArgumentNullException(nameof(createVehicleUseCase));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<CreateVehicleOutput>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            if (request is not null)
            {
                var input = new CreateVehicleInput(request.IdFleet, request.PlateNumber, request.Model, request.Brand, request.Registration, request.Renting);
                var response = await _createVehicleUseCase.Execute(input);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return response;
            }

            return Domain.Errors.Errors.Renting.VehicleDoesNotExists;
        }
    }
}
