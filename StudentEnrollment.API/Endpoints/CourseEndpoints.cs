using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using StudentEnrollment.Data;
using StudentEnrollment.API.DTOs.Course;
using AutoMapper;
using StudentEnrollment.Data.Contracts;
using StudentEnrollment.API.DTOs.Enrollment;

namespace StudentEnrollment.API.Endpoints;

public static class CourseEndpoints
{
    public static void MapCourseEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Course").WithTags(nameof(Course));

        group.MapGet("/", async (ICourseRepository repo, IMapper mapper) =>
        {
            var courses = await repo.GetAllAsync();
            return mapper.Map<List<CourseDto>>(courses);
        })
        .WithName("GetAllCourses")
        .WithOpenApi()
        .Produces<List<CourseDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, ICourseRepository repo, IMapper mapper) =>
        {
            return await repo.GetAsync(id)
              is Course model ? Results.Ok(mapper.Map<CourseDto>(model))
                                  : Results.NotFound();
        })
        .WithName("GetCourseById")
        .WithOpenApi()
        .Produces<List<CourseDto>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapGet("/GetStudents/{id}", async (int id, ICourseRepository repo, IMapper mapper) =>
        {
            return await repo.GetStudentList(id)
              is Course model ? Results.Ok(mapper.Map<CourseDetailsDto>(model))
                                  : Results.NotFound();
        })
        .WithName("GetCourseDetailsById")
        .WithOpenApi()
        .Produces<List<CourseDetailsDto>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);


        group.MapPut("/{id}", async (int id, CourseDto courseDto, ICourseRepository repo, IMapper mapper) =>
        {
            var foundModel = await repo.GetAsync(id);
            if (foundModel == null)
            {
                return Results.NotFound();
            }

            //update model properties here
            mapper.Map(courseDto, foundModel);
            await repo.UpdateAsync(foundModel);

            return Results.NoContent();
        })
        .WithName("UpdateCourse")
        .WithOpenApi()
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (CreateCourseDto courseDto, ICourseRepository repo, IMapper mapper) =>
        {
            var course =  mapper.Map<Course>(courseDto);

            await repo.AddAsync(course);
            return Results.Created($"/api/Course/{course.Id}", course);
        })
        .WithName("CreateCourse")
        .WithOpenApi()
        .Produces<Course>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (int id, ICourseRepository repo) =>
        {
            return await repo.DeleteAsync(id) ? Results.NoContent() : Results.NotFound();
        })
        .WithName("DeleteCourse")
        .WithOpenApi()
        .Produces<Course>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
