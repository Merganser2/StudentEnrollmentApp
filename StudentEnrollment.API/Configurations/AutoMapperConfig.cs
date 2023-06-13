using AutoMapper;
using StudentEnrollment.API.DTOs.Course;
using StudentEnrollment.Data;

namespace StudentEnrollment.API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<Course, CourseDto>().ReverseMap(); // Can go either direction
            CreateMap<Course, CreateCourseDto>().ReverseMap();
        }
    }
}
