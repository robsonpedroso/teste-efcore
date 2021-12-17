using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestEFCore.Domain.Contracts.Applications;
using TestEFCore.Domain.DTO;

namespace TestEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientApplication _clientApp;

        public ClientController(ILogger<ClientController> logger,
            IClientApplication clientApp)
        {
            _logger = logger;
            _clientApp = clientApp;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _clientApp.Get());
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _clientApp.Find(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Client client)
        {
            await _clientApp.Insert(client);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Client client)
        {
            if (client.Id != id)
            {
                client.Id = id;
            }

            await _clientApp.Update(client);
            return Ok();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _clientApp.Delete(id);
            return Ok();
        }
    }
}
