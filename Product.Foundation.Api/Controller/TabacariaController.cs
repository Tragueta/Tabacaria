using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tabacaria.Foundation.Domain.Entites;

namespace Tabacaria.Foundation.Api.Controller
{
    public class TabacariaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TabacariaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<ActionResult> CreateRequest(object requestObject)
        {
            try
            {
                var response = _mediator.Send(requestObject).GetAwaiter().GetResult() as Response;

                if (response == null || !response.Success)
                    return BadRequest(response);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response(false, ex.Message, null));
            }
        }

        //protected async Task<ActionResult> CreateRequest<T>(object requestObject) where T : class
        //{
        //    try
        //    {
        //        var response = (Response<T>)_mediator.Send(requestObject).GetAwaiter().GetResult();

        //        if (!response.Success)
        //            return BadRequest(response);

        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new Response<T>(false, ex.Message, null));
        //    }
        //}
    }
}
