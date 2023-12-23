using System.Linq;
using DDD.Domain.Interfaces;
using DDD.Domain.Models;
using DDD.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public Usuario GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }

        public override IQueryable<Usuario> GetAll()
        {
            return base.GetAll()
                .Include(i => i.Escolaridade)
                .Include(i => i.UsuarioHistoricoEscolarCollection);
        }

        public override IQueryable<Usuario> GetByIdQuery(int id)
        {
            return base.GetByIdQuery(id)
                .Include(i => i.Escolaridade)
                .Include(i => i.UsuarioHistoricoEscolarCollection);
        }
    }
}
