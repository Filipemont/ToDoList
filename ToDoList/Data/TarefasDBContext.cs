using Microsoft.EntityFrameworkCore;
using ToDoList.Data.Map;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class TarefasDBContext : DbContext
    {
        public TarefasDBContext(DbContextOptions<TarefasDBContext> options) : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuario {  get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
