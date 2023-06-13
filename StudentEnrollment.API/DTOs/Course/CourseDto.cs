namespace StudentEnrollment.API.DTOs.Course
{
    public class CourseDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }
    }

    // For POST, don't want Id
    public class CreateCourseDto
    {
        public string Title { get; set; }

        public int Credits { get; set; }
    }

    public class CourseDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

     //   public List<StudentDto> Students { get; set; } = new List<StudentDto>();
    }

}
