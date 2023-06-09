﻿using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.DTOs.Movie.Validators;
using CinemaManagementSystem.Application.Features.Movies.Requests.Commands;
using CinemaManagementSystem.Application.Responses.Movie;
using CinemaManagementSystem.Domain.Entities;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Movies.Handlers.Commands
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, CreateMovieCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateMovieCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CreateMovieCommandResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateMovieCommandResponse();
            var validator = new IMovieDTOValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.CreateMovieDTO);
            if (!validationResult.IsValid) {
                response.IsSuccess = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            var movie = _mapper.Map<Movie>(request.CreateMovieDTO);
            movie = await _unitOfWork.MovieRepository.AddAsync(movie);
            await _unitOfWork.Save();
            response.IsSuccess = true;
            response.Message = "Creation Successful";
            response.Id = movie.Id;
            response.CreateMovieDTO = request.CreateMovieDTO;
            return response;

        }
    }
}