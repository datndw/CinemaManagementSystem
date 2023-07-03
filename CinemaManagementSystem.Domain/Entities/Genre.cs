﻿using CinemaManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Domain.Entities
{
    public class Genre : BaseDomainEntity
    {
        public string Name { get; set; }
    }
}
