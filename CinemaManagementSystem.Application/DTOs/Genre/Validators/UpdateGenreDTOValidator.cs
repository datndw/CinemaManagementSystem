using System;
using CinemaManagementSystem.Application.Contracts.Persistence;
using FluentValidation;

namespace CinemaManagementSystem.Application.DTOs.Genre.Validators
{
    public class UpdateGenreDTOValidator : AbstractValidator<UpdateGenreDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateGenreDTOValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Include(new IGenreDTOValidator(_unitOfWork));
            RuleFor(m => m.Id)
                .NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

