using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.Features.Genres.Requests.Commands;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Genres.Handlers.Commands
{
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteGenreCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _unitOfWork.GenreRepository.GetAsync(request.Id);
            await _unitOfWork.GenreRepository.DeleteAsync(genre);
            await _unitOfWork.Save();
            return true;
        }
    }
}