using CinemaManagementSystem.Application.Contracts.Persistence;
using FluentValidation;

namespace CinemaManagementSystem.Application.DTOs.Actor.Validators
{
    public class CreateActorDTOValidator : AbstractValidator<CreateActorDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateActorDTOValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Include(new IActorDTOValidator(_unitOfWork));
        }
    }
}