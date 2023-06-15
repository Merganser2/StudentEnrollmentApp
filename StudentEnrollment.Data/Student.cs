namespace StudentEnrollment.Data
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public  DateTime DateOfBirth { get; set; }
        public string IdNumber { get; set; }
        public string PictureLink { get; set; }

        // For use with Repository pattern. A student can have multiple enrollments; an enrollment can have only one student.
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>(); // initializing so that it can't be null
    }
}