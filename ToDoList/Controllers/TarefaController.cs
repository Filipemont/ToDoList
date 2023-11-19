using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Repositorios.Interfaces;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;

        public TarefaController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> ListarTarefas()
        {
            List<TarefaModel> tarefas = await _tarefaRepositorio.BuscarTarefas();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> BuscarTarefaPorId(int id)
        {
            TarefaModel tarefa = await _tarefaRepositorio.BuscarPorId(id);
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<TarefaModel>> CadastraTarefa([FromBody] TarefaModel tarefa)
        {
            TarefaModel novaTarefa = await _tarefaRepositorio.Adicionar(tarefa);
            return Ok(novaTarefa);
        }

        [HttpPut]
        public async Task<ActionResult<TarefaModel>> AtualizaUsuario([FromBody] TarefaModel tarefa, int id)
        {
            TarefaModel tarefaAtualizada = await _tarefaRepositorio.Atualizar(tarefa, id);
            return Ok(tarefaAtualizada);
        }

        [HttpDelete]
        public async Task<ActionResult<TarefaModel>> DeletaUsuario(int id)
        {
            bool apagado = await _tarefaRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
