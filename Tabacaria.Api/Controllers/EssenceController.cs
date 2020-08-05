using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public EssenceController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Insert an essence
        /// </summary>
        /// <param name="essenceVM"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> InsertEssence(EssenceViewModel essenceVM)
        {
            var myDTO = _mapper.Map<EssenceDTO>(essenceVM);
            var essenceCommand = new InsertEssenceCommand(myDTO);

            return null;
        }
    }
}