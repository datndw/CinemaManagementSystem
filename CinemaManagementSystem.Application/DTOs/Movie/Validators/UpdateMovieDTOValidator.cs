using CinemaManagementSystem.Application.Contracts.Persistence;
using FluentValidation;

namespace CinemaManagementSystem.Application.DTOs.Movie.Validators
{
    public class UpdateMovieDTOValidator : AbstractValidator<UpdateMovieDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateMovieDTOValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Include(new IMovieDTOValidator(_unitOfWork));
            RuleFor(m => m.Id)
                .NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}