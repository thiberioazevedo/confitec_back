using System;
using DDD.Domain.Models;
using DDD.Domain.Validations;

namespace DDD.Domain.Commands
{
    public class AddAnexoCommand : AnexoCommand
    {
        public AddAnexoCommand(string nome, string formato, byte[] arquivo)
        {
            Nome = nome;
            Formato = formato;
            Arquivo = arquivo;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddAnexoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
