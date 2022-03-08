using ChapterTest.Models;
using ChapterTest.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChapterTest.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_usuarioRepository.Listar());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Usuario usuarioProcurado = _usuarioRepository.BuscarPorId(id);

                if (usuarioProcurado == null)
                {
                    return NotFound();
                }
                return Ok(usuarioProcurado);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario u)
        {
            try
            {
                _usuarioRepository.Cadastrar(u);

                return Ok("Usuario Cadastrado");

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario u)
        {
            try
            {
                _usuarioRepository.Atualizar(id, u);

                return Ok("Usuario Atualizado");

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _usuarioRepository.Deletar(id);

                return Ok("Usuario Deletado");

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
