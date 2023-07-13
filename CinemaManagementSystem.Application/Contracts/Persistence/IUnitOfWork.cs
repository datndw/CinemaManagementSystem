using System;
namespace CinemaManagementSystem.Application.Contracts.Persistence
{
	public interface IUnitOfWork
	{
		IMovieRepository MovieRepository { get; }
		IGenreRepository GenreRepository { get; }
		IUserRepository UserRepository { get; }
		ICompanyRepository CompanyRepository { get; }
		IActorRepository ActorRepository { get; }
		IRateRepository RateRepository { get; }

		Task Save();
	}
}

