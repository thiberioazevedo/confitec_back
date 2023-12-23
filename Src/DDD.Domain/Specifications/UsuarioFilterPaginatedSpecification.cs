using DDD.Domain.Models;

namespace DDD.Domain.Specifications
{
    public class UsuarioFilterPaginatedSpecification : BaseSpecification<Usuario>
    {
        public UsuarioFilterPaginatedSpecification(int skip, int take)
            : base(i => true)
        {
            ApplyPaging(skip, take);
        }
    }
}
