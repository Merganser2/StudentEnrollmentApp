using FluentValidation;

namespace StudentEnrollment.API.DTOs.Student
{
    public class StudentDto : CreateStudentDto
    {
        public int Id { get; set; }
    }

    public class StudentDtoValidator : AbstractValidator<CreateStudentDto>
    {
        public StudentDtoValidator()
        {
            Include(new CreateStudentDtoValidator());
        }
    }
}
