using CinemaManagementSystem.Application.Contracts.Persistence;
using FluentValidation;

namespace CinemaManagementSystem.Application.DTOs.Actor.Validators
{
    public class IActorDTOValidator : AbstractValidator<IActorDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public IActorDTOValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(m => m.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");
        }
    }
}

