using CinemaManagementSystem.Application.Contracts.Persistence;
using FluentValidation;

namespace CinemaManagementSystem.Application.DTOs.Company.Validators
{
    public class UpdateCompanyDTOValidator : AbstractValidator<UpdateCompanyDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCompanyDTOValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Include(new ICompanyDTOValidator(_unitOfWork));
            RuleFor(m => m.Id)
                .NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}