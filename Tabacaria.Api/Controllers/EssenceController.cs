using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tabacaria.Domain.Commands;
using Tabacaria.Domain.Queries;
using Tabacaria.Foundation.Api.Controller;
using Tabacaria.Foundation.Domain.Entites;

namespace Tabacaria.Api.Controllers
{
    [ApiController]
    [Route("api/essence")]
    [Consumes("application/json")]
    public class EssenceController : TabacariaController
    {
        public EssenceController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        public async Task<ActionResult<Response>> CreateEssence(CreateEssenceCommand request) => await CreateRequest(request);

        [HttpGet]
        public async Task<ActionResult<Response>> GetAllEssences() => await CreateRequest(new GetEssenceQuery());

    }
}