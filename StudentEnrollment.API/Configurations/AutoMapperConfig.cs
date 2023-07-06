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
            // ReverseMap allows the mapping to go in either direction
            CreateMap<Course, CourseDto>().ReverseMap();  
            CreateMap<Course, CreateCourseDto>().ReverseMap();
            CreateMap<Course, CourseDetailsDto>()
                             .ForMember(q => q.Students,
                                        x => x.MapFrom(course => course.Enrollments.Select(s => s.Student)));

            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, CreateStudentDto>().ReverseMap();
            CreateMap<Student, StudentDetailsDto>().ForMember(q => q.Courses,
                                                              x => x.MapFrom(student => student.Enrollments.Select(c => c.Course)));

            CreateMap<Enrollment, EnrollmentDto>().ReverseMap();
            CreateMap<Enrollment, CreateEnrollmentDto>().ReverseMap();
        }
    }
}
