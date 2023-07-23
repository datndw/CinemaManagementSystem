using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.DTOs.Movie;
using CinemaManagementSystem.Application.Features.Movies.Requests.Queries;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Movies.Handlers.Queries
{
    public class GetMoviesRequestHandler : IRequestHandler<GetMoviesRequest, List<MovieRateDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetMoviesRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<List<MovieRateDTO>> Handle(GetMoviesRequest request, CancellationToken cancellationToken)
        {
            var movies = await _unitOfWork.MovieRepository.GetMoviesWithRate();
            return _mapper.Map<List<MovieRateDTO>>(movies);
        }
    }
}