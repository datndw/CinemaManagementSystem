using System;
namespace CinemaManagementSystem.Application.Contracts.Persistence
{
	public interface IUnitOfWork
	{
		IMovieRepository MovieRepository { get; }
		IGenreRepository GenreRepository { get; }
		Task Save();
	}
}

