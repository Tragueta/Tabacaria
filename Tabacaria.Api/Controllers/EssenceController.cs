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

        /// <summary>
        /// Insert an essence
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        //[HttpPost]
        //public async Task<ActionResult<Response<EssenceEntity>>> CreateEssence(CreateEssenceCommand request) => await CreateRequest<EssenceEntity>(request);

        //[HttpGet]
        //public async Task<ActionResult<Response<IEnumerable<EssenceEntity>>>> GetAllEssences() => await CreateRequest<IEnumerable<EssenceEntity>>(new GetEssenceQuery());

        //[Route("testando")]
        //[HttpPost]
        //public async Task<ActionResult<Response<EssenceEntity>>> RemoverTestando(RemoverTesteComando comando) => await CreateRequest<EssenceEntity>(comando);

        [HttpPost]
        public async Task<ActionResult<Response>> CreateEssence(CreateEssenceCommand request) => await CreateRequest(request);

        [HttpGet]
        public async Task<ActionResult<Response>> GetAllEssences() => await CreateRequest(new GetEssenceQuery());

        [Route("testando")]
        [HttpPost]
        public async Task<ActionResult<Response>> RemoverTestando(RemoverTesteComando comando) => await CreateRequest(comando);
    }
}