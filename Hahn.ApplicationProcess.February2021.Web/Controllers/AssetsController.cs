using System.Threading.Tasks;
using AutoMapper;
using DynamicCQ.Controllers;
using Hahn.ApplicationProcess.February2021.Domain.Containers.Wrappers;
using Hahn.ApplicationProcess.February2021.Domain.Models.Asset;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hahn.ApplicationProcess.February2021.Web.Controllers
{
    [Route("api/v1/assets")]
    public class AssetsController : DynamicCqControllerBase
    {
        public AssetsController(IMapper mapper, IMediator dispatcher) : base(mapper, dispatcher) {}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormioJson<AssetDto> dto) 
            => await this.Add(dto.data);
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id) 
            => await this.Find<AssetDto>(id);

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] FormioJson<AssetDto> dto) 
            => await this.Update(id, dto.data);
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
            => await this.Remove<AssetDto>(id);
    }
}