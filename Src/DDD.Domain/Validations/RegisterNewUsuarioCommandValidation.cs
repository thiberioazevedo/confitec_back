using DDD.Domain.Commands;

namespace DDD.Domain.Validations
{
    public class RegisterNewUsuarioCommandValidation : UsuarioValidation<RegisterNewUsuarioCommand>
    {
        public RegisterNewUsuarioCommandValidation()
        {
            ValidaNome();
            ValidaDataNascimento();
            ValidaEmail();
        }
    }
}
