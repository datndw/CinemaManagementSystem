using CinemaManagementSystem.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Application.DTOs.Movie.Validators
{
    public class CreateMovieDTOValidator : AbstractValidator<CreateMovieDTO>
    {
        private readonly IMovieRepository _repository;
        public CreateMovieDTOValidator(IMovieRepository repository)
        {
            _repository = repository;
            Include(new IMovieDTOValidator(_repository));
        }
    }
}
