using System;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.DTOs.Movie;
using FluentValidation;

namespace CinemaManagementSystem.Application.DTOs.Rate.Validators
{
    public class IRateDTOValidator : AbstractValidator<IRateDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public IRateDTOValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(r => r.Rating)
                .LessThan(5).WithMessage("{PropertyName} can not be more than 10");

            RuleFor(c => c.Comment)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters");
        }
    }
}

