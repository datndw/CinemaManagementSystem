using System;
using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.Features.Companies.Requests.Commands;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Companies.Handlers.Commands
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteCompanyCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.CompanyRepository.GetAsync(request.Id);
            await _unitOfWork.CompanyRepository.DeleteAsync(company);
            await _unitOfWork.Save();
            return true;
        }
    }
}

