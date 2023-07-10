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

		}
	}
}

