using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;
using ToDoList.Repositorios.Interfaces;

namespace ToDoList.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly TarefasDBContext _db;
        public UsuarioRepositorio(TarefasDBContext data)
        {
            _db = data;
        }

        public async Task<List<UsuarioModel>> BuscarUsuarios()
        {
            return await _db.Usuario.ToListAsync();
        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _db.Usuario.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            _db.Usuario.Add(usuario);
            _db.SaveChanges();
            return usuario;
        }
        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if(usuarioPorId == null)
            {
                throw new Exception($"Usuario para o Id: {id} não foi encontrado no banco de dados");
            }
            usuarioPorId.Name = usuario.Name;
            usuarioPorId.Email = usuario.Email;

            _db.Usuario.Update(usuarioPorId);
            _db.SaveChanges();
            return usuarioPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o Id: {id} não foi encontrado no banco de dados");
            }
            _db.Usuario.Remove(usuarioPorId);
            _db.SaveChanges();
            return true;
           
        }
    }
}
