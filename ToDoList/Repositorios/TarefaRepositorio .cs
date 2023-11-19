using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;
using ToDoList.Repositorios.Interfaces;

namespace ToDoList.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly TarefasDBContext _db;
        public TarefaRepositorio(TarefasDBContext data)
        {
            _db = data;
        }

        public async Task<List<TarefaModel>> BuscarTarefas()
        {
            return await _db.Tarefas.ToListAsync();
        }
        public async Task<TarefaModel> BuscarPorId(int id)
        {
            return await _db.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
            await _db.Tarefas.AddAsync(tarefa);
            await _db.SaveChangesAsync();
            return tarefa;
        }
        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);
            if(tarefaPorId == null)
            {
                throw new Exception($"Tarefa para o Id: {id} não foi encontrado no banco de dados");
            }
            tarefaPorId.Name = tarefa.Name;
            tarefaPorId.Description = tarefa.Description;
            tarefaPorId.Status = tarefa.Status;
            tarefaPorId.UsuarioId = tarefa.UsuarioId;

            _db.Tarefas.Update(tarefaPorId);
            await _db.SaveChangesAsync();
            return tarefaPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);
            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa para o Id: {id} não foi encontrado no banco de dados");
            }
            _db.Tarefas.Remove(tarefaPorId);
            await _db.SaveChangesAsync();
            return true;
           
        }
    }
}
