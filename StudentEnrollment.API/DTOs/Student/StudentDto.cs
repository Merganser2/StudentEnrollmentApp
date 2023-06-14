namespace StudentEnrollment.API.DTOs.Student
{
    public class StudentDto : CreateStudentDto
    {
        public int Id { get; set; }
    }

    public class CreateStudentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdNumber { get; set; }
        public string PictureLink { get; set; }
    }

}
