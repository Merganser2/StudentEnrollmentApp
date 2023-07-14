using FluentValidation;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using StudentEnrollment.API.DTOs.Course;
using StudentEnrollment.API.DTOs.Student;
using StudentEnrollment.Data.Contracts;

namespace StudentEnrollment.API.DTOs.Enrollment
{
    public class EnrollmentDto
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        public virtual CourseDto Course { get; set; }
        public virtual StudentDto Student { get; set; }
    }

    public class EnrollmentDtoValidator : AbstractValidator<EnrollmentDto>
    {
        public EnrollmentDtoValidator(ICourseRepository courseRepository, IStudentRepository studentRepository)
        {
            Include((IValidator<EnrollmentDto>)new CreateEnrollmentDtoValidator(courseRepository, studentRepository));
        }
    }
}
