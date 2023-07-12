using CinemaManagementSystem.Application.Contracts.Persistence;
using FluentValidation;

namespace CinemaManagementSystem.Application.DTOs.User.Validators
{
    public class CreateUserDTOValidator : AbstractValidator<CreateUserDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserDTOValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Include(new IUserDTOValidator(_unitOfWork));
        }
    }
}