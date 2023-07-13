using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.Features.Rates.Requests.Commands;
using CinemaManagementSystem.Application.Responses.Rate;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Rates.Handlers.Commands
{
    public class UpdateRateCommandHandler : IRequestHandler<UpdateRateCommand, UpdateRateCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateRateCommandResponse> Handle(UpdateRateCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateRateCommandResponse();
            var rate = await _unitOfWork.RateRepository.GetAsync(request.Id);
            if (request.UpdateRateDTO != null)
            {
                _mapper.Map(request.UpdateRateDTO, rate);
                await _unitOfWork.RateRepository.UpdateAsync(rate);
                await _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Update Successful";
                response.Id = rate.Id;
                response.UpdateRateDTO = request.UpdateRateDTO;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Update Failed";
                response.Errors = new List<string> { "Rate to be updated can't not be null" };
            }
            return response;
        }
    }
}