namespace StudentEnrollment.Data
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }
        public int Credits { get; set; }

        // For use with Repository pattern. A course can have multiple enrollments; an enrollment can have only one course.
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>(); // initializing so that it can't be null
    }

}