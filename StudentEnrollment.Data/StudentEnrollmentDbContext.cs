using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using StudentEnrollment.Data;
using StudentEnrollment.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.Data
{
    //
    // The bridge to the database
    //
    public class StudentEnrollmentDbContext : IdentityDbContext
    {
        public StudentEnrollmentDbContext(DbContextOptions<StudentEnrollmentDbContext> options) : base(options)
        {
                
        }

        //public StudentEnrollmentDbContext(DbContextOptions options) : base(options)
        //{
        //}

        // Add Default Data
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CourseConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }

        // Create the Data Tables (Entities)
        //  Following convention of pluralizing property name for the set of data, of which
        //  the type is a single record
        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

    }
}

// This factory class is a workaround for an issue Entity Framework has in finding the
// context, something that Trevoir thinks is a bug (and now wondering if it has been
// fixed, based on the different error I am getting with the same code, later versions of EF/Core)
public class StudentEnrollmentDbContextFactory : IDesignTimeDbContextFactory<StudentEnrollmentDbContext>
{
    public StudentEnrollmentDbContext CreateDbContext(string[] args)
    {
        // For now just get from appsettings
        //string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        // Get connection string
        DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<StudentEnrollmentDbContext>();
        string connectionString = config.GetConnectionString("StudentEnrollmentDbConnection");
        optionsBuilder.UseSqlServer(connectionString);

        return new StudentEnrollmentDbContext((DbContextOptions<StudentEnrollmentDbContext>)optionsBuilder.Options);
    }
}