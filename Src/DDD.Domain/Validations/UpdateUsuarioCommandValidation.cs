using DDD.Domain.Commands;

namespace DDD.Domain.Validations
{
    public class UpdateUsuarioCommandValidation : UsuarioValidation<UpdateUsuarioCommand>
    {
        public UpdateUsuarioCommandValidation()
        {
            ValidaId();
            ValidaNome();
            ValidaDataNascimento();
            ValidaEmail();
        }
    }
}
