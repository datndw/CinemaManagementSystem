using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.Features.Movies.Requests.Commands;
using CinemaManagementSystem.Application.Responses.Movie;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Movies.Handlers.Commands
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, UpdateMovieCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMovieCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateMovieCommandResponse> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateMovieCommandResponse();
            var movie = await _unitOfWork.MovieRepository.GetAsync(request.Id);
            if (request.UpdateMovieDTO != null)
            {
                _mapper.Map(request.UpdateMovieDTO, movie);
                await _unitOfWork.MovieRepository.UpdateAsync(movie);
                await _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Update Successful";
                response.Id = movie.Id;
                response.UpdateMovieDTO = request.UpdateMovieDTO;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Update Failed";
                response.Errors = new List<string> { "Movie to be updated can't not be null"};
            }
            return response;
        }
    }
}