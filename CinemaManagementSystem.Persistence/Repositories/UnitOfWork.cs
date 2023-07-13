using System;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Persistence.DbContexts;

namespace CinemaManagementSystem.Persistence.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly CinemaManagementSystemDbContext _context;
		private IMovieRepository _movieRepository;
		private IGenreRepository _genreRepository;
		private IUserRepository _userRepository;
		private IActorRepository _actorRepository;
		private ICompanyRepository _companyRepository;
		private IRateRepository _rateRepository;

		public UnitOfWork(CinemaManagementSystemDbContext context)
		{
			_context = context;
		}

		public IMovieRepository MovieRepository => _movieRepository ??= new MovieRepository(_context);
        public IGenreRepository GenreRepository => _genreRepository ??= new GenreRepository(_context);
		public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);
        public IActorRepository ActorRepository => _actorRepository ??= new ActorRepository(_context);
        public ICompanyRepository CompanyRepository => _companyRepository ??= new CompanyRepository(_context);
        public IRateRepository RateRepository => _rateRepository ??= new RateRepository(_context);


        public void Dispose()
		{
			_context.Dispose();
			GC.SuppressFinalize(this);
		}

		public async Task Save()
		{
			await _context.SaveChangesAsync();
		}

    }
}

