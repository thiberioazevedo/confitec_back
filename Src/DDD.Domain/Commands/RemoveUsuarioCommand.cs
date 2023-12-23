using System;
using DDD.Domain.Validations;

namespace DDD.Domain.Commands
{
    public class RemoveUsuarioCommand : UsuarioCommand
    {
        public RemoveUsuarioCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveUsuarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
