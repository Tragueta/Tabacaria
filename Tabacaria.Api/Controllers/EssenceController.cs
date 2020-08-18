using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.Foundation.Api.Controller;
using System;
using System.Threading.Tasks;
using Tabacaria.Domain.Commands;
using Tabacaria.Domain.Entities;
using Tabacaria.Domain.Utils.HttpUtils;

namespace Tabacaria.Api.Controllers
{
    [ApiController]
    [Route("api/essence")]
    [Consumes("application/json")]
    public class EssenceController : TabacariaController
    {
        private readonly IMediator _mediator;

        public EssenceController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Insert an essence
        /// </summary>
        /// <param name="essenceVM"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Response<EssenceEntity>>> CreateEssence(CreateEssenceCommand request)
        {
            try
            {
                return await CreateRequest<EssenceEntity>(request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
    }
}