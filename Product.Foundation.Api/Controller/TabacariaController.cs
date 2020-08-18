using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tabacaria.Domain.Utils.HttpUtils;

namespace Product.Foundation.Api.Controller
{
    public class TabacariaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TabacariaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<ActionResult> CreateRequest<T>(object requestObject) where T : class
        {
            var response = await _mediator.Send(requestObject);

            var castObject = (Response<T>)response;

            if (!castObject.Success)
                return BadRequest(castObject);

            return Ok(castObject);
        }
    }
}
