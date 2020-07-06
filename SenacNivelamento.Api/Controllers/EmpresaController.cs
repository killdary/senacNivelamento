using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenacNivelamento.Api.Tools;
using SenacNivelamento.Application.Empresas.Commands;
using SenacNivelamento.Application.Empresas.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenacNivelamento.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : BaseController
    {
        public EmpresaController(IMediator mediator)
            : base(mediator)
        { }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEmpresaCommand request)
        {
            var response = await _mediator.Send(request);

            return Response(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateEmpresaCommand request)
        {
            var response = await _mediator.Send(request);

            return Response(response);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var query = new BuscarEmpresaPorIdQuery
            {
                Id = id
            };

            var response = await _mediator.Send(query);

            return Response(response);
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new BuscarEmpresaQuery();

            var response = await _mediator.Send(query);

            return Response(response);
        }


        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var command = new DeleteEmpresaCommand
            {
                Id = id
            };

            var response = await _mediator.Send(command);

            return Response(response);
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("imagem/{id:long}")]
        public async Task<ActionResult<object>> PostImagem([FromForm(Name = "imagem")] IFormFile imagem, long id)
        {
            try
            {
                var ferramentaImagem = new FerramentaImagem();
                var urlImagem = ferramentaImagem.Salvar(imagem, "empresa", id);
                if (!string.IsNullOrEmpty(urlImagem))
                {

                    var command = new UpdateEmpresaImagemCommand()
                    {
                        Id = id,
                        Imagem = urlImagem
                    };

                    var response = await _mediator.Send(command);

                    return Ok(response);
                }
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
