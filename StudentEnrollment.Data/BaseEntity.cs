namespace StudentEnrollment.Data
{
    // Later may convert this and derived classes to records,
    //  to make them less mutable and enforce property creation on construction

    public abstract class BaseEntity // Entity = Model = Table
    {
        public int Id { get; set; }
        public  DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        // For now setting these to empty string by default
        public string CreatedBy { get; set; } = string.Empty;
        public string ModifiedBy { get; set;} = string.Empty;
    }
}