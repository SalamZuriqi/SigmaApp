using FluentValidation.Results;
using MediatR;

namespace SigmaApplication.Models
{
    public class CandidateModel : IRequest<( List<ValidationFailure> Errors, CandidateModel Model)>
    {
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? LinkedInURL { get; set; }
        public string? GitHubURL { get; set; }
        public string? Description { get; set; }
        public TimeOnly? TimeIntervalFrom { get; set; }
        public TimeOnly? TimeIntervalTo { get; set; }
    }
}
