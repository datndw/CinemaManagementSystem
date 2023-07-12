using System;
using CinemaManagementSystem.Application.Contracts.Persistence;
using FluentValidation;

namespace CinemaManagementSystem.Application.DTOs.Genre.Validators
{
	public class IGenreDTOValidator : AbstractValidator<IGenreDTO>
	{
		private readonly IUnitOfWork _unitOfWork;
		public IGenreDTOValidator(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
            RuleFor(n => n.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");
        }
	}
}

