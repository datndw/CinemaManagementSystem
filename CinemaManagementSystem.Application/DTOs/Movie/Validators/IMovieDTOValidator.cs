using CinemaManagementSystem.Application.Persistance.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Application.DTOs.Movie.Validators
{
    public class IMovieDTOValidator : AbstractValidator<IMovieDTO>
    {
        private readonly IMovieRepository _repository;
        public IMovieDTOValidator(IMovieRepository repository)
        {
            _repository = repository;

            RuleFor(m => m.Title)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");
        }
    }
}
