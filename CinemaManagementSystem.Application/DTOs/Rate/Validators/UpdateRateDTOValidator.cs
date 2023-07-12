using CinemaManagementSystem.Application.Contracts.Persistence;
using FluentValidation;

namespace CinemaManagementSystem.Application.DTOs.Rate.Validators
{
    public class UpdateRateDTOValidator : AbstractValidator<UpdateRateDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateRateDTOValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Include(new IRateDTOValidator(_unitOfWork));
            RuleFor(m => m.Id)
                .NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}