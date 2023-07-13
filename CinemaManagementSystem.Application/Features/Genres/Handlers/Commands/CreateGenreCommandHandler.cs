using AutoMapper;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Application.DTOs.Genre.Validators;
using CinemaManagementSystem.Application.Features.Genres.Requests.Commands;
using CinemaManagementSystem.Application.Responses.Genre;
using CinemaManagementSystem.Domain.Entities;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Genres.Handlers.Commands
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, CreateGenreCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateGenreCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CreateGenreCommandResponse> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateGenreCommandResponse();
            var validator = new IGenreDTOValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.CreateGenreDTO);
            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            var genre = _mapper.Map<Genre>(request.CreateGenreDTO);
            genre = await _unitOfWork.GenreRepository.AddAsync(genre);
            await _unitOfWork.Save();
            response.IsSuccess = true;
            response.Message = "Creation Successful";
            response.Id = genre.Id;
            response.CreateGenreDTO = request.CreateGenreDTO;
            return response;

        }
    }
}