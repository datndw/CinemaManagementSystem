using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.DTOs.Rate.Validators;
using CinemaManagementSystem.Application.Features.Rates.Requests.Commands;
using CinemaManagementSystem.Application.Responses.Rate;
using CinemaManagementSystem.Domain.Entities;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Rates.Handlers.Commands
{
    public class CreateRateCommandHandler : IRequestHandler<CreateRateCommand, CreateRateCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateRateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CreateRateCommandResponse> Handle(CreateRateCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateRateCommandResponse();
            var validator = new IRateDTOValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.CreateRateDTO);
            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            var rate = _mapper.Map<Rate>(request.CreateRateDTO);
            rate = await _unitOfWork.RateRepository.AddAsync(rate);
            await _unitOfWork.Save();
            response.IsSuccess = true;
            response.Message = "Creation Successful";
            response.Id = rate.Id;
            response.CreateRateDTO = request.CreateRateDTO;
            return response;

        }
    }
}