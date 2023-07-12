using CinemaManagementSystem.Application.Contracts.Persistence;
using FluentValidation;

namespace CinemaManagementSystem.Application.DTOs.Rate.Validators
{
    public class CreateRateDTOValidator : AbstractValidator<CreateRateDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateRateDTOValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Include(new IRateDTOValidator(_unitOfWork));
        }
    }
}