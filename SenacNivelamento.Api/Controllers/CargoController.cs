using MediatR;
using Microsoft.AspNetCore.Mvc;
using SenacNivelamento.Application.Cargos.Commands;
using SenacNivelamento.Application.Cargos.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenacNivelamento.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CargoController : BaseController
    {
        public CargoController(IMediator mediator)
            : base(mediator)
        { }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCargoCommand request)
        {
            var response = await _mediator.Send(request);

            return Response(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateCargoCommand request)
        {
            var response = await _mediator.Send(request);

            return Response(response);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var query = new BuscarCargoPorIdQuery
            {
                Id = id
            };

            var response = await _mediator.Send(query);

            return Response(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new BuscarListaCargoQuery();

            var response = await _mediator.Send(query);

            return Response(response);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var command = new DeleteCargoCommand
            {
                Id = id
            };

            var response = await _mediator.Send(command);

            return Response(response);
        }
    }
}
