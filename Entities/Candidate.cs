namespace SigmaApplication.Entities
{
    public class Candidate : Entity<long>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? LinkedInURL { get; set; }
        public string? GitHubURL { get; set; }
        public string Description { get; set; }
        public TimeOnly? TimeIntervalFrom { get; set; }
        public TimeOnly? TimeIntervalTo { get; set; }
    }
}
