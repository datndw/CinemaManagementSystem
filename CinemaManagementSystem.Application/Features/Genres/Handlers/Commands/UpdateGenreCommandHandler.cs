using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.Features.Genres.Requests.Commands;
using CinemaManagementSystem.Application.Responses.Genre;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Genres.Handlers.Commands
{
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, UpdateGenreCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateGenreCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateGenreCommandResponse> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateGenreCommandResponse();
            var genre = await _unitOfWork.GenreRepository.GetAsync(request.Id);
            if (request.UpdateGenreDTO != null)
            {
                _mapper.Map(request.UpdateGenreDTO, genre);
                await _unitOfWork.GenreRepository.UpdateAsync(genre);
                await _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Update Successful";
                response.Id = genre.Id;
                response.UpdateGenreDTO = request.UpdateGenreDTO;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Update Failed";
                response.Errors = new List<string> { "Genre to be updated can't not be null" };
            }
            return response;
        }
    }
}