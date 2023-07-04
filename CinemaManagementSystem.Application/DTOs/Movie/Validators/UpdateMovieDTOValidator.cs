using CinemaManagementSystem.Application.Persistance.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Application.DTOs.Movie.Validators
{
    public class UpdateMovieDTOValidator : AbstractValidator<UpdateMovieDTO>
    {
        private readonly IMovieRepository _repository;
        public UpdateMovieDTOValidator(IMovieRepository repository)
        {
            _repository = repository;
            Include(new IMovieDTOValidator(_repository));
            RuleFor(m => m.Id)
                .NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
