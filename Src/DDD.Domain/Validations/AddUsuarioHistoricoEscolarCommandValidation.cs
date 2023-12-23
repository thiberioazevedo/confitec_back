using DDD.Domain.Commands;

namespace DDD.Domain.Validations
{
    public class AddUsuarioHistoricoEscolarCommandValidation : UsuarioHistoricoEscolarValidation<AddUsuarioHistoricoEscolarCommand>
    {
        public AddUsuarioHistoricoEscolarCommandValidation()
        {
            ValidaAnexoId();
            ValidaUsuarioId();
            ValidaNome();
        }
    }
}
