﻿using CinemaManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Persistence.Configurations.Entities
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(
                new Genre
                {
                    Id = Guid.NewGuid(),
                    Name = "Phim Hành Động",
                    CreatedBy = "Administrator",
                    LastModifiedBy = "Administrator"
                },
                new Genre
                {
                    Id = Guid.NewGuid(),
                    Name = "Phim Phiêu Lưu",
                    CreatedBy = "Administrator",
                    LastModifiedBy = "Administrator"
                }
            );
        }
    }
}
