using CinemaManagementSystem.Application.Contracts.Persistence;
using FluentValidation;

namespace CinemaManagementSystem.Application.DTOs.Company.Validators
{
    public class ICompanyDTOValidator : AbstractValidator<ICompanyDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ICompanyDTOValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(m => m.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");
        }
    }
}