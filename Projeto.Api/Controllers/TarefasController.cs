using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Data.Dto;
using Projeto.Data.Interfaces;

namespace Projeto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;

        public TarefasController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        [HttpGet]
        [Route("/ListarTodas")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Projeto.Data.Dto.TarefaDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodasTarefas()
        {
            try
            {
                return Ok(_tarefaRepositorio.TodasTarefas());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("/ListarPorId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Projeto.Data.Dto.TarefaDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarPorId(int id)
        {
            try
            {
                return Ok(_tarefaRepositorio.ListarPorId(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("/CriarTarefa")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CriarTarefa(TarefaDto model)
        {
            try
            {
                return Ok(_tarefaRepositorio.CriarTarefa(model));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("/ApagarTarefa/{nome}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ApagarTarefa(string nome)
        {
            try
            {
                return Ok(_tarefaRepositorio.ApagarTarefa(new TarefaDto()
                {
                    Nome = nome
                }));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("/ApagarTarefaPorId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ApagarTarefa(int id)
        {
            try
            {
                return Ok(_tarefaRepositorio.ApagarTarefa(new TarefaDto()
                {
                    Id = id
                }));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPatch]
        [Route("/AtualizarTarefa")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AtualizarTarefa(TarefaAtualizarDto model)
        {
            try
            {
                return Ok(_tarefaRepositorio.AtualizarTarefa(model));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
