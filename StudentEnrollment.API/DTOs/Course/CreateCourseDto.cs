namespace StudentEnrollment.API.DTOs.Course
{
    // For POST, don't want Id
    public class CreateCourseDto
    {
        public string Title { get; set; }

        public int Credits { get; set; }
    }

}
