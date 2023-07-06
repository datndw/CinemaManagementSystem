using CinemaManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Persistence.Configurations.Entities
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasData(
                new Actor
                {
                    Id = Guid.NewGuid(),
                    Name = "Cao Quynh Anh",
                    Description = "Xinh gai, code gioi :))",
                    BirthDate = DateTime.Now,
                    Gender = "Female",
                    ImageUrl = "",
                    CreatedBy = "Administrator",
                    LastModifiedBy = "Administrator"
                }
            );
        }
    }
}
