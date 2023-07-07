using CinemaManagementSystem.Application.DTOs.Movie;
using CinemaManagementSystem.Application.Responses.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Application.Responses.Movie
{
    public class MovieCommandResponse : BaseCommandResponse
    {
        public MovieDTO MovieDTO { get; set; }
    }
}
