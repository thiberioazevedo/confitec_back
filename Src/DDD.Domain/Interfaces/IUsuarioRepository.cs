using DDD.Domain.Models;

namespace DDD.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario GetByEmail(string email);
    }
}
