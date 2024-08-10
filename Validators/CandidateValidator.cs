using FluentValidation;
using SigmaApplication.Models;

namespace SigmaApplication.Validators
{
    public class CandidateValidator : AbstractValidator<CandidateModel>
    {
        public CandidateValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull().WithMessage("First Name must not be null.")
                .NotEmpty().WithMessage("First Name is required.");

            RuleFor(x => x.LastName)
               .NotNull().WithMessage("Last Name must not be null.")
               .NotEmpty().WithMessage("Last Name is required.");

            RuleFor(x => x.Email)
             .NotNull().WithMessage("Email must not be null.")
             .NotEmpty().WithMessage("Email is required.");

            RuleFor(x => x.Description)
             .NotNull().WithMessage("Description must not be null.")
             .NotEmpty().WithMessage("Description is required.");
        }
    }
}