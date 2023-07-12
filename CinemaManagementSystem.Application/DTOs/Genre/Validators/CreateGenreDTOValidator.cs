using System;
using CinemaManagementSystem.Application.Contracts.Persistence;
using FluentValidation;

namespace CinemaManagementSystem.Application.DTOs.Genre.Validators
{
    public class CreateGenreDTOValidator : AbstractValidator<CreateGenreDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateGenreDTOValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Include(new IGenreDTOValidator(_unitOfWork));
        }
    }
}

