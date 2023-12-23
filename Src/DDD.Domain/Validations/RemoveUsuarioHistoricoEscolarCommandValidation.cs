using DDD.Domain.Commands;

namespace DDD.Domain.Validations
{
    public class RemoveUsuarioHistoricoEscolarCommandValidation : UsuarioHistoricoEscolarValidation<RemoveUsuarioHistoricoEscolarCommand>
    {
        public RemoveUsuarioHistoricoEscolarCommandValidation()
        {
            ValidaId();
        }
    }
}
