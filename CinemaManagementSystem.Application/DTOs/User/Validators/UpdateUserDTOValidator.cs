using System;
using CinemaManagementSystem.Application.Contracts.Persistence;
using FluentValidation;

namespace CinemaManagementSystem.Application.DTOs.User.Validators
{
    public class UpdateUserDTOValidator : AbstractValidator<UpdateUserDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateUserDTOValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Include(new IUserDTOValidator(_unitOfWork));
            RuleFor(m => m.Id)
                .NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

