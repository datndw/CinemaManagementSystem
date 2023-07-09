using AutoMapper;
using CinemaManagementSystem.Application.Features.Movies.Requests.Commands;
using CinemaManagementSystem.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Application.Features.Movies.Handlers.Commands
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteMovieCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _unitOfWork.MovieRepository.GetAsync(request.Id);
            await _unitOfWork.MovieRepository.DeleteAsync(movie);
            await _unitOfWork.Save();
            return true;
        }
    }
}
