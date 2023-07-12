using CinemaManagementSystem.Application.Contracts.Persistence;
using FluentValidation;

namespace CinemaManagementSystem.Application.DTOs.Actor.Validators
{
    public class UpdateActorDTOValidator : AbstractValidator<UpdateActorDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateActorDTOValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Include(new IActorDTOValidator(_unitOfWork));
            RuleFor(m => m.Id)
                .NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

