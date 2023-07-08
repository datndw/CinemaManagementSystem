using CinemaManagementSystem.Domain.Entities;

namespace CinemaManagementSystem.Persistence.Extensions
{
    public static class DataExtension
    {
        public static List<User> Users = new List<User>
        {
            new User
            {
                Id = new Guid(1,1,1,1,1,1,1,1,1,1,1),
                Firstname = "System",
                Lastname = "Administrator",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new User
            {
                Id = new Guid(2,2,2,2,2,2,2,2,2,2,2),
                Firstname = "System",
                Lastname = "Publisher",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
            new User
            {
                Id = new Guid(3,3,3,3,3,3,3,3,3,3,3),
                Firstname = "System",
                Lastname = "User",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            },
        };

        public static List<Movie> Movies = new List<Movie>
        {
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "Fast & Furious X",
                Description = "Dom Toretto và gia đình anh ta là mục tiêu của đứa con trai đầy thù hận của trùm ma túy Hernan Reyes.",
                ImageUrl = "/brZzXXQ8GuzlAdu4TJxjhC8ebBL.jpg",
                BackDropUrl = "/4XM8DUTQb3lhLemJC51Jx4a2EuA.jpg",
                AgeRequired = 8,
                ReleaseDate = DateTime.Now,
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            }
        };

        public static List<Genre> Genres = new List<Genre>
        {
            new Genre
                {
                    Id = Guid.NewGuid(),
                    Name = "Phim Hành Động",
                    DateCreated = DateTime.Now,
                    CreatedBy = "Administrator",
                    LastModifiedDate = DateTime.Now,
                    LastModifiedBy = "Administrator"
                },
                new Genre
                {
                    Id = Guid.NewGuid(),
                    Name = "Phim Phiêu Lưu",
                    DateCreated = DateTime.Now,
                    CreatedBy = "Administrator",
                    LastModifiedDate = DateTime.Now,
                    LastModifiedBy = "Administrator"
                }
        };

        public static List<Actor> Actors = new List<Actor>
        {
            new Actor
            {
                Id = Guid.NewGuid(),
                Name = "Cao Quynh Anh",
                Description = "Xinh gai, code gioi :))",
                BirthDate = DateTime.Now,
                Gender = "Female",
                ImageUrl = "",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            }
        };

        public static List<Company> Companies = new List<Company>
        {
            new Company
            {
                Id = Guid.NewGuid(),
                Name = "Lucasfilm Ltd.",
                Description = "Founded in 1971, Lucasfilm is one of the world's leading entertainment companies and home to the legendary Star Wars and Indiana Jones franchises.",
                ImageUrl = "/o86DbpburjxrqAzEDhXZcyE8pDb.png",
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            }
        };

        public static List<Rate> Rates = new List<Rate>
        {

            new Rate
            {
                Id = Guid.NewGuid(),
                Rating = 9.5,
                Comment = "Web xịn, phim hay, toàn trai xinh gái đẹp, recommend nha mọi ngừi",
                MovieId = Movies.ElementAt(0).Id,
                UserId = Users.ElementAt(0).Id,
                DateCreated = DateTime.Now,
                CreatedBy = "Administrator",
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Administrator"
            }

        };

        public static List<MovieActor> MovieActors = new List<MovieActor>
        {
            new MovieActor
            {
                MovieId = Movies.ElementAt(0).Id,
                ActorId = Actors.ElementAt(0).Id,
            }
        };

        public static List<MovieCompany> MovieCompanies = new List<MovieCompany>
        {
            new MovieCompany
            {
                MovieId = Movies.ElementAt(0).Id,
                CompanyId = Companies.ElementAt(0).Id,
            }
        };

        public static List<MovieGenre> MovieGenres = new List<MovieGenre>
        {
            new MovieGenre
            {
                MovieId = Movies.ElementAt(0).Id,
                GenreId = Genres.ElementAt(0).Id,
            }
        };
    }
}