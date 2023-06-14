using AutoMapper;
using StudentEnrollment.API.DTOs.Course;
using StudentEnrollment.API.DTOs.Enrollment;
using StudentEnrollment.API.DTOs.Student;
using StudentEnrollment.Data;

namespace StudentEnrollment.API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<Course, CourseDto>().ReverseMap(); // Can go either direction
            CreateMap<Course, CreateCourseDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap(); // Can go either direction
            CreateMap<Student, CreateStudentDto>().ReverseMap();
            CreateMap<Enrollment, EnrollmentDto>().ReverseMap(); // Can go either direction
            CreateMap<Enrollment, CreateEnrollmentDto>().ReverseMap();
        }
    }
}
