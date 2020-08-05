using AW.Business.Services.Requests.Contracts.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace AW.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithdrawController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WithdrawController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet,Route("Ping")]
        public IActionResult Ping()
        {
            return Ok("Pong");
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(long))]
        public async Task<IActionResult> Create([FromBody] CreateRequest model, CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(model));
        }

    }
}
