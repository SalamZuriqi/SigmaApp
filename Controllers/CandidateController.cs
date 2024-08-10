using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SigmaApplication.Models;

namespace SigmaApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CandidateController(
          IMediator _mediator
            )
        {
            this._mediator = _mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CandidateModel>> AddOrUpdate([FromBody] CandidateModel model)
        {
            var result = await _mediator.Send(model);

            if (!result.Errors.IsNullOrEmpty())
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Model);
        }
    }
}
