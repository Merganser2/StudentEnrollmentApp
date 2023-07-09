using AutoMapper;
using StudentEnrollment.API.DTOs.Course;
using StudentEnrollment.Data.Contracts;
using StudentEnrollment.Data;
using Microsoft.AspNetCore.Identity;

namespace StudentEnrollment.API.Endpoints
{
    public static class AuthenticationEndpoints
    {
        public static void MapAuthenticationEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapPost("/api/login", async (LoginDto loginDto, UserManager<SchoolEnrollmentUser> userManager) =>
            {
                // For now using email and user name interchangeably
                var user = await userManager.FindByEmailAsync(loginDto.UserName);
                if (user is null)
                {
                    return Results.Unauthorized();
                }

                bool isValidCredentials = await userManager.CheckPasswordAsync(user, loginDto.Password);
                if (!isValidCredentials)
                {
                    return Results.Unauthorized();
                }

                // generate token here...

                return Results.Ok();
            })
            .WithTags("Authentication")
            .WithName("Login")
            .Produces<Course>(StatusCodes.Status200OK);
        }
    }

    public class LoginDto
    {
        public  string UserName { get; set; }
        public string Password { get; set; }
    }
}
