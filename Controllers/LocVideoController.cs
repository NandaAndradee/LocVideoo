using LocVideo.ApplicationCore;
using LocVideo.ApplicationCore.Interfaces.Sevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocVideo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1")]
    public class LocVideoController : ControllerBase
    {
        private readonly IClientService _clientService;

        public LocVideoController(IClientService clientService)
        {
            _clientService = clientService;
        }

        /// <summary>
        /// Cria um cadastro de cliente
        /// </summary>
        /// <response code="201">Cadastro realizado com sucesso</response>
        /// <response code="400">Cadastro não foi realizado</response>

        [ProducesResponseType(typeof(ClientLoc), 201)]
        [HttpPost]
        public async Task<IActionResult> CreateClient(ClientLocDto clientLoc)
        {
            var created = await _clientService.CreateClient(clientLoc);

            if (created != null)
                return Created("", created);

            return BadRequest();

        }
    }
}
