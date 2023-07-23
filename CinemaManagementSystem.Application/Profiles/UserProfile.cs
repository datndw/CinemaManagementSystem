using AutoMapper;
using CinemaManagementSystem.Application.DTOs.Common;
using CinemaManagementSystem.Application.DTOs.User;
using CinemaManagementSystem.Domain.Entities;

namespace CinemaManagementSystem.Application.Profiles
{
    public class UserProfile : Profile
	{
		public UserProfile()
		{
            CreateMap<User, UserDTO>()
                .ReverseMap();
            CreateMap<User, CreateUserDTO>()
                .ReverseMap();
            CreateMap<User, UpdateUserDTO>()
                .ReverseMap();
            CreateMap<MovieUser, FavoritesDTO>()
                .ReverseMap();
        }
	}
}