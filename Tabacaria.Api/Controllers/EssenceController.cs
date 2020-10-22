using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.Foundation.Api.Controller;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tabacaria.Domain.Commands;
using Tabacaria.Domain.Entities;
using Tabacaria.Domain.Queries;
using Tabacaria.Domain.Utils.HttpUtils;

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
        [HttpPost]
        public async Task<ActionResult<Response<EssenceEntity>>> CreateEssence(CreateEssenceCommand request) => await CreateRequest<EssenceEntity>(request);

        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<EssenceEntity>>>> GetAllEssences() => await CreateRequest<IEnumerable<EssenceEntity>>(new GetEssenceQuery());

        [Route("testando")]
        [HttpPost]
        public async Task<ActionResult<Response<EssenceEntity>>> RemoverTestando(RemoverTesteComando comando) => await CreateRequest<EssenceEntity>(comando);
    }
}