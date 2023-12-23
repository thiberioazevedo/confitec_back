using DDD.Domain.Commands;

namespace DDD.Domain.Validations
{
    public class RemoveUsuarioCommandValidation : UsuarioValidation<RemoveUsuarioCommand>
    {
        public RemoveUsuarioCommandValidation()
        {
            ValidaId();
        }
    }
}
