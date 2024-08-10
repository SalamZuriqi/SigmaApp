using FluentValidation.Results;
using SigmaApplication.Models;

namespace SigmaApplication.Interfaces
{
    public interface ICandidateService
    {
        public Task<( List<ValidationFailure> Errors, CandidateModel Model)> Insert(CandidateModel model);
        public Task<( List<ValidationFailure> Errors, CandidateModel Model)> Update(long id, CandidateModel model);
    }
   
}
