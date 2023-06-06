using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.Data.Configurations
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasData(
                new Course { Id = 1, Title = "ASP.Net Core Minimal API Development", Credits = 3 },
                new Course { Id = 2, Title = "Structured Query Language Basics", Credits = 4 },
                new Course { Id = 3, Title = "Underwater Basketry", Credits = 2 }
                );
        }
    }
}
