namespace zeaploy.Helpers
{
    public class JobTypes
    {
        // All job types
        public const string FullTime = "Full-time";
        public const string PartTime = "Part-time";
        public const string Internship = "Internship";

        // Job types that are displayed
        public static readonly ICollection<string> types = new string[] {
            FullTime,
            PartTime,
            Internship,
        };
    }
}
