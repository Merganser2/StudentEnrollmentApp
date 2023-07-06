namespace StudentEnrollment.API.DTOs.Student
{
    public class CreateStudentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdNumber { get; set; }
        public string PictureLink { get; set; }
    }

}
