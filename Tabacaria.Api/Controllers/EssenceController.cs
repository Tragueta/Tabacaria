using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Tabacaria.Api.ViewModels;
using Tabacaria.Domain.Commands;
using Tabacaria.Domain.DTOs;

namespace Tabacaria.Api.Controllers
{
    [ApiController]
    [Route("api/essence")]
    [Consumes("application/json")]
    public class EssenceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public EssenceController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Insert an essence
        /// </summary>
        /// <param name="essenceVM"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateEssence(EssenceViewModel essenceVM)
        {
            try
            {
                var response = await _mediator.Send(new CreateEssenceCommand(_mapper.Map<EssenceDTO>(essenceVM)));

                if (!response.Success)
                    return BadRequest(response.Message);

                return Ok(response.ResponseObject);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
    }
}