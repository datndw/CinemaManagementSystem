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

		public UnitOfWork(CinemaManagementSystemDbContext context)
		{
			_context = context;
		}

		public IMovieRepository MovieRepository => _movieRepository ??= new MovieRepository(_context);
        public IGenreRepository GenreRepository => _genreRepository ??= new GenreRepository(_context);


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

