using CinemaManagementSystem.Application.DTOs.Movie;
using CinemaManagementSystem.Application.Resposes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Application.Resposes.Movie
{
    public class MovieCommandResponse : BaseCommandResponse
    {
        public MovieDTO MovieDTO { get; set; }
    }
}
