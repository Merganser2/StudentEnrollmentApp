using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using StudentEnrollment.Data;
using StudentEnrollment.API.DTOs.Course;
using AutoMapper;

namespace StudentEnrollment.API.Endpoints;

public static class CourseEndpoints
{
    public static void MapCourseEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Course").WithTags(nameof(Course));

        group.MapGet("/", async (StudentEnrollmentDbContext db, IMapper mapper) =>
        {
            var courses = await db.Courses.ToListAsync();
            return mapper.Map<List<CourseDto>>(courses);
        })
        .WithName("GetAllCourses")
        .WithOpenApi()
        .Produces<List<CourseDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, StudentEnrollmentDbContext db, IMapper mapper) =>
        {
            return await db.Courses.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Course model
                    ? Results.Ok(mapper.Map<CourseDto>(model))
                    : Results.NotFound();
        })
        .WithName("GetCourseById")
        .WithOpenApi()
        .Produces<List<CourseDto>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", async (int id, CourseDto courseDto, StudentEnrollmentDbContext db, IMapper mapper) =>
        {
            var course = mapper.Map<Course>(courseDto);

            var affected = await db.Courses
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Title, course.Title)
                  .SetProperty(m => m.Credits, course.Credits)
                );

            return affected == 1 ? Results.Ok() : Results.NotFound();
        })
        .WithName("UpdateCourse")
        .WithOpenApi()
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (CreateCourseDto courseDto, StudentEnrollmentDbContext db, IMapper mapper) =>
        {
            var course = mapper.Map<Course>(courseDto);

            db.Courses.Add(course);
            await db.SaveChangesAsync();
            return Results.Created($"/api/Course/{course.Id}", course);
        })
        .WithName("CreateCourse")
        .WithOpenApi()
        .Produces<Course>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (int id, StudentEnrollmentDbContext db) =>
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
