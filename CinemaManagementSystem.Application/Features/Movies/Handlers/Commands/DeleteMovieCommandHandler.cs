using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.Features.Movies.Requests.Commands;
using MediatR;

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