using System;
using DDD.Domain.Validations;

namespace DDD.Domain.Commands
{
    public class AddUsuarioHistoricoEscolarCommand : UsuarioHistoricoEscolarCommand
    {
        public AddUsuarioHistoricoEscolarCommand(int anexoId, int usuarioId, string nome)
        {
            this.AnexoId = anexoId;
            this.UsuarioId = usuarioId;
            this.Nome = nome;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddUsuarioHistoricoEscolarCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
