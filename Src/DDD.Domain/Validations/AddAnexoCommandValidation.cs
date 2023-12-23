using DDD.Domain.Commands;

namespace DDD.Domain.Validations
{
    public class AddAnexoCommandValidation : AnexoValidation<AnexoCommand>
    {
        public AddAnexoCommandValidation()
        {
            ValidaNome();
            ValidaFormato();
        }
    }
}
