using System;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ReturnVehicle
{
    public class ReturnVehicleCommandHandler : IRequestHandler<ReturnVehicleCommand, ErrorOr<ReturnVehicleOutput>>
    {
        private readonly IReturnVehicleUseCase _returnVehicleUseCase;
        private readonly IUnitOfWork _unitOfWork;

        public ReturnVehicleCommandHandler(IReturnVehicleUseCase returnVehicleUseCase, IUnitOfWork unitOfWork)
        {
            _returnVehicleUseCase = returnVehicleUseCase ?? throw new ArgumentNullException(nameof(returnVehicleUseCase));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<ReturnVehicleOutput>> Handle(ReturnVehicleCommand request, CancellationToken cancellationToken)
        {
            if (request is not null)
            {
                var input = new ReturnVehicleInput(request.IdRenting);
                var response = await _returnVehicleUseCase.Execute(input);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return response;
            }

            return Domain.Errors.Errors.Renting.RentingIsNotAvailable;
        }
    }
}
