using ChapterTest.Models;

namespace ChapterTest.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Login(string Email, string Senha);
    }
}
