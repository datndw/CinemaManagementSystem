using AutoMapper;
using CinemaManagementSystem.Application.Features.Movies.Requests.Commands;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Application.Features.Movies.Handlers.Commands
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateMovieCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _unitOfWork.MovieRepository.GetAsync(request.Id);
            if (request.MovieDTO != null)
            {
                _mapper.Map(request.MovieDTO, movie);
                await _unitOfWork.MovieRepository.UpdateAsync(movie);
                await _unitOfWork.Save();
            }
            else if (request.ChangeMovieImageUrlDTO != null)
            {
                await _unitOfWork.MovieRepository.ChangeImageUrl(movie, request.ChangeMovieImageUrlDTO.ImageUrl);
                await _unitOfWork.Save();
            }
            return Unit.Value;

        }
    }
}
