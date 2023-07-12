using System;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.DTOs.Movie;
using FluentValidation;

namespace CinemaManagementSystem.Application.DTOs.User.Validators
{
    public class IUserDTOValidator : AbstractValidator<IUserDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public IUserDTOValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(f => f.Firstname)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");
            RuleFor(l => l.Lastname)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");
        }
    }
}

