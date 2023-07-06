using CinemaManagementSystem.Application.Contracts.Identity;
using CinemaManagementSystem.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Identity.Services
{
    public class UserServices : IUserService
    {
        public Task<User> GetUser(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
