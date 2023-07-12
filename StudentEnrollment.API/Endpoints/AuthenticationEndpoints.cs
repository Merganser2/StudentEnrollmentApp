﻿using AutoMapper;
using StudentEnrollment.API.DTOs.Course;
using StudentEnrollment.Data.Contracts;
using StudentEnrollment.Data;
using Microsoft.AspNetCore.Identity;
using StudentEnrollment.API.DTOs.Authentication;
using StudentEnrollment.Api.Services;

namespace StudentEnrollment.API.Endpoints
{
    public static class AuthenticationEndpoints
    {
        public static void MapAuthenticationEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapPost("/api/login", async (LoginDto loginDto, IAuthManager authManager) =>
            {
                var response = await authManager.Login(loginDto);
                if (response is null) 
                {
                    return Results.Unauthorized();
                }
                return Results.Ok(response);
            })
            .WithTags("Authentication")
            .WithName("Login")
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status401Unauthorized);
        }
    }
}
