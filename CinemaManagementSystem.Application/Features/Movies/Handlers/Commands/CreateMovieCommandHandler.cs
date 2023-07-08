using AutoMapper;
using CinemaManagementSystem.Application.DTOs.Movie;
using CinemaManagementSystem.Application.DTOs.Movie.Validators;
using CinemaManagementSystem.Application.Exceptions;
using CinemaManagementSystem.Application.Features.Movies.Requests.Commands;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.Responses;
using CinemaManagementSystem.Application.Responses.Movie;
using CinemaManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Application.Features.Movies.Handlers.Commands
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, CreateMovieCommandResponse>
    {
        private readonly IMovieRepository _repository;
        private readonly IMapper _mapper;
        public CreateMovieCommandHandler(IMovieRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CreateMovieCommandResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateMovieCommandResponse();
            var validator = new IMovieDTOValidator(_repository);
            var validationResult = await validator.ValidateAsync(request.CreateMovieDTO);
            if (!validationResult.IsValid) {
                response.IsSuccess = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            var movie = _mapper.Map<Movie>(request.CreateMovieDTO);
            movie = await _repository.AddAsync(movie);
            response.IsSuccess = true;
            response.Message = "Creation Successful";
            response.Id = movie.Id;
            response.CreateMovieDTO = request.CreateMovieDTO;
            return response;

        }
    }
}
