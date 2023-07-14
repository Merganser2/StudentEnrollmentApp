using FluentValidation;

namespace StudentEnrollment.API.DTOs.Course
{
    public class CourseDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }
    }

    public class CourseDtoValidator : AbstractValidator<CreateCourseDto>
    {
        public CourseDtoValidator()
        {
            Include(new CreateCourseDtoValidator());
        }
    }
}
