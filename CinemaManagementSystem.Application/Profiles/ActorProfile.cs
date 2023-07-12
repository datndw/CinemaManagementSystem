using AutoMapper;
using CinemaManagementSystem.Application.DTOs.Actor;
using CinemaManagementSystem.Domain.Entities;

namespace CinemaManagementSystem.Application.Profiles
{
    public class ActorProfile : Profile
	{
		public ActorProfile()
		{
            CreateMap<Actor, ActorDTO>()
                .ReverseMap();
            CreateMap<Actor, CreateActorDTO>()
                .ReverseMap();
            CreateMap<Actor, UpdateActorDTO>()
                .ReverseMap();
        }
	}
}