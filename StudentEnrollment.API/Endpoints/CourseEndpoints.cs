using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using StudentEnrollment.Data;
namespace StudentEnrollment.API.Endpoints;

public static class CourseEndpoints
{
    public static void MapCourseEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Course").WithTags(nameof(Course));

        group.MapGet("/", async (StudentEnrollmentDbContext db) =>
        {
            return await db.Courses.ToListAsync();
        })
        .WithName("GetAllCourses")
        .WithOpenApi()
        .Produces<List<Course>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async  (int id, StudentEnrollmentDbContext db) =>
        {
            return await db.Courses.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Course model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetCourseById")
        .WithOpenApi()
        .Produces<Course>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", async  (int id, Course course, StudentEnrollmentDbContext db) =>
        {
            var affected = await db.Courses
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Title, course.Title)
                  .SetProperty(m => m.Credits, course.Credits)
                  .SetProperty(m => m.Id, course.Id)
                  .SetProperty(m => m.CreatedDate, course.CreatedDate)
                  .SetProperty(m => m.ModifiedDate, course.ModifiedDate)
                  .SetProperty(m => m.CreatedBy, course.CreatedBy)
                  .SetProperty(m => m.ModifiedBy, course.ModifiedBy)
                );

            return affected == 1 ? Results.Ok() : Results.NotFound();
        })
        .WithName("UpdateCourse")
        .WithOpenApi()
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (Course course, StudentEnrollmentDbContext db) =>
        {
            db.Courses.Add(course);
            await db.SaveChangesAsync();
            return Results.Created($"/api/Course/{course.Id}",course);
        })
        .WithName("CreateCourse")
        .WithOpenApi()
        .Produces<Course>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async  (int id, StudentEnrollmentDbContext db) =>
        {
            var affected = await db.Courses
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? Results.Ok() : Results.NotFound();
        })
        .WithName("DeleteCourse")
        .WithOpenApi()
        .Produces<Course>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
