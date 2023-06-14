using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using StudentEnrollment.Data;
using StudentEnrollment.API.DTOs.Student;
using AutoMapper;
using StudentEnrollment.API.DTOs.Course;

namespace StudentEnrollment.API.Endpoints;

public static class StudentEndpoints
{
    public static void MapStudentEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Student").WithTags(nameof(Student));

        group.MapGet("/", async (StudentEnrollmentDbContext db, IMapper mapper) =>
        {
            var students = await db.Students.ToListAsync();
            return mapper.Map<List<StudentDto>>(students);
        })
        .WithName("GetAllStudents")
        .WithOpenApi()
        .Produces<List<StudentDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async  (int id, StudentEnrollmentDbContext db, IMapper mapper) =>
        {
            return await db.Students.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Student model
                    ? Results.Ok(mapper.Map<StudentDto>(model))
                    : Results.NotFound();
        })
        .WithName("GetStudentById")
        .WithOpenApi()
        .Produces<StudentDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", async  (int id, StudentDto studentDto, StudentEnrollmentDbContext db, IMapper mapper) =>
        {
            var student = mapper.Map<Student>(studentDto);

            var affected = await db.Students
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.FirstName, student.FirstName)
                  .SetProperty(m => m.LastName, student.LastName)
                  .SetProperty(m => m.DateOfBirth, student.DateOfBirth)
                  .SetProperty(m => m.IdNumber, student.IdNumber)
                  .SetProperty(m => m.PictureLink, student.PictureLink)
                );

            return affected == 1 ? Results.Ok() : Results.NotFound();
        })
        .WithName("UpdateStudent")
        .WithOpenApi()
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (CreateStudentDto studentDto, StudentEnrollmentDbContext db, IMapper mapper) =>
        {
            var student = mapper.Map<Student>(studentDto);

            db.Students.Add(student);
            await db.SaveChangesAsync();
            return Results.Created($"/api/Student/{student.Id}",student);
        })
        .WithName("CreateStudent")
        .WithOpenApi()
        .Produces<Student>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async  (int id, StudentEnrollmentDbContext db) =>
        {
            var affected = await db.Students
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? Results.Ok() : Results.NotFound();
        })
        .WithName("DeleteStudent")
        .WithOpenApi()
        .Produces<Student>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
