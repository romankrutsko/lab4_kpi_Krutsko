using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoSklad.Core.GlobalSklad;
using AutoSklad.Orchestrators.GlobalSklad.Contract;
using Microsoft.AspNetCore.Mvc;
using GlobalSklad = AutoSklad.Orchestrators.GlobalSklad.Contract.GlobalSklad;

namespace AutoSklad.Onion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GlobalSkladController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISkladService _service;

        public GlobalSkladController(ISkladService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var sklad = await _service.GetByIdAsync(id);
            return Ok(_mapper.Map<GlobalSklad>(sklad));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCountOnSklad count)
        {
            await _service.Update(id, count.Count);
            return Ok(id);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> PostAsync(GlobalSklad store)
        {
            var skladModel = _mapper.Map<Core.GlobalSklad.GlobalSklad>(store);
            var createdModel = await _service.AddAsync(skladModel);
            return Ok(_mapper.Map<GlobalSklad>(createdModel));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            await _service.RemoveById(id);
            return Ok();
        }
    }
}