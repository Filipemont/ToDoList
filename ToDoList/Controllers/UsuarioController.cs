using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Repositorios.Interfaces;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarUsuarioPorId(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> CadastraUsuario([FromBody] UsuarioModel usuario)
        {
            UsuarioModel novoUsuario = await _usuarioRepositorio.Adicionar(usuario);
            return Ok(novoUsuario);
        }

        [HttpPut]
        public async Task<ActionResult<UsuarioModel>> AtualizaUsuario([FromBody]UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioAtualizado = await _usuarioRepositorio.Atualizar(usuario, id);
            return Ok(usuarioAtualizado);
        }

        [HttpDelete]
        public async Task<ActionResult<UsuarioModel>> DeletaUsuario(int id)
        {
            bool apagado = await _usuarioRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
