using ChapterTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ChapterTest.Contexts
{
    public class ChapterContexts : DbContext
    {
        public ChapterContexts()
        {
        }
        public ChapterContexts(DbContextOptions<ChapterContexts> options) : base(options)
        {
        }
        // vamos utilizar esse método para configurar o banco de dados
        protected override void
        OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // cada provedor tem sua sintaxe para especificação
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-S6ORD9H\\SQLEXPRESS; initial catalog = Chapter;Integrated Security = true");
            }
        }
        // dbset representa as entidades que serão utilizadas nas operações de leitura, criação, atualização e deleção
        public DbSet<Livro> Livros { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
