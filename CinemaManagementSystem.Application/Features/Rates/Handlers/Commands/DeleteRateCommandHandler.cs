using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.Features.Rates.Requests.Commands;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Rates.Handlers.Commands
{
    public class DeleteRateCommandHandler : IRequestHandler<DeleteRateCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteRateCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteRateCommand request, CancellationToken cancellationToken)
        {
            var Rate = await _unitOfWork.RateRepository.GetAsync(request.Id);
            await _unitOfWork.RateRepository.DeleteAsync(Rate);
            await _unitOfWork.Save();
            return true;
        }
    }
}