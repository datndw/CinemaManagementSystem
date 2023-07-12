using CinemaManagementSystem.Application.Contracts.Persistence;
using FluentValidation;

namespace CinemaManagementSystem.Application.DTOs.Company.Validators
{
    public class CreateCompanyDTOValidator : AbstractValidator<CreateCompanyDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateCompanyDTOValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Include(new ICompanyDTOValidator(_unitOfWork));
        }
    }
}