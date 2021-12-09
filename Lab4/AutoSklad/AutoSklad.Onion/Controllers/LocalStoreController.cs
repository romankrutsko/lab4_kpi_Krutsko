using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoSklad.Core.LocalStore;
using AutoSklad.Orchestrators.LocalStore.Contract;
using Microsoft.AspNetCore.Mvc;
using LocalStore = AutoSklad.Orchestrators.LocalStore.Contract.LocalStore;

namespace AutoSklad.Onion.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class LocalStoreController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILocalStoreService _service;

        public LocalStoreController(ILocalStoreService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var stores = await _service.GetAsync();
            return Ok(_mapper.Map<List<LocalStore>>(stores));
        }

        [HttpGet("sklad/{skladId}/localstore/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var stores = await _service.GetByIdAsync(id);
            return Ok(_mapper.Map<LocalStore>(stores));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCount(int id, UpdateCount count)
        {
            await _service.UpdateCount(id, count.Count);
            return Ok(id);
        }

        [HttpPost("sklad/{skladId}/localstore")]
        public async Task<IActionResult> PostAsync(int skladId, LocalStore store)
        {
            var storeModel = _mapper.Map<Core.LocalStore.LocalStore>(store);
            storeModel.SkladId = skladId;
            var createdModel = await _service.AddAsync(storeModel);
            return Ok(_mapper.Map<LocalStore>(createdModel));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            await _service.RemoveById(id);
            return Ok();
        }
    }
}