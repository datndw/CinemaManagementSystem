﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Domain.Entities
{
    public class MovieActor
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }

        public Guid ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
