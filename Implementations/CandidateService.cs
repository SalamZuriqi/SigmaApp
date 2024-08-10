using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using SigmaApplication.Entities;
using SigmaApplication.Interfaces;
using SigmaApplication.Models;

namespace SigmaApplication.Implementations
{
    public class CandidateService : ICandidateService
    {
        private readonly IGenericCRUDService<Candidate> _service;
        private readonly IValidator<CandidateModel> _validator;

        public CandidateService(IGenericCRUDService<Candidate> service, IValidator<CandidateModel> validator)
        {
            _service = service;
            _validator = validator;
        }
        public async Task<( List<ValidationFailure> Errors, CandidateModel Model)> Insert(CandidateModel model)
        {
            var resultValidator = _validator.Validate(model);
            if (!resultValidator.IsValid)
            {
                return ( resultValidator.Errors, null);
            }

            var candidate = model.ToEntity();
            await _service.CreateAsync(candidate);
            return ( null, model);
        }



        public async Task<( List<ValidationFailure> Errors, CandidateModel Model)> Update(long id, CandidateModel model)
        {
            var resultValidator = _validator.Validate(model);
            if (!resultValidator.IsValid)
            {
                return (resultValidator.Errors, null);
            }

            var existingCandidate = await _service.GetByIdAsync(id);
            if (existingCandidate == null)
            {
                var error = new ValidationFailure("Id", "This Candidate does not exist.");
                return (new List<ValidationFailure> { error }, null);
            }

            var candidate = model.ToEntity();
            await _service.UpdateAsync(id, candidate);
            return (null, model);
        }
    }
}
