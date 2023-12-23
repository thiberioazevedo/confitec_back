using System;
using DDD.Domain.Validations;

namespace DDD.Domain.Commands
{
    public class RemoveUsuarioHistoricoEscolarCommand : UsuarioHistoricoEscolarCommand
    {
        public RemoveUsuarioHistoricoEscolarCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveUsuarioHistoricoEscolarCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
