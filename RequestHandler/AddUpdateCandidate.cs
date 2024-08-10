using MediatR;
using SigmaApplication.Interfaces;
using SigmaApplication.Models;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SigmaApplication.RequestHandler
{
    public class AddUpdateCandidateHandler : IRequestHandler<CandidateModel, ( List<ValidationFailure> Errors, CandidateModel Model)>
    {
        private readonly ICandidateService _service;

        public AddUpdateCandidateHandler(ICandidateService service) => _service = service;

        public async Task<(List<ValidationFailure> Errors, CandidateModel Model)> Handle(CandidateModel model, CancellationToken cancellationToken)
        {
            if (model.Id == 0)
            {
                return await _service.Insert(model);
            }
            else
            {
                return await _service.Update(model.Id, model);
            }
        }
    }
}
