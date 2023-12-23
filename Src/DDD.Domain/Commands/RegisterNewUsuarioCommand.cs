using System;
using DDD.Domain.Models;
using DDD.Domain.Validations;

namespace DDD.Domain.Commands
{
    public class RegisterNewUsuarioCommand : UsuarioCommand
    {
        public RegisterNewUsuarioCommand(string nome, string sobrenome, string email, DateTime birthDate, int escolaridadeId)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = birthDate;
            EscolaridadeId = escolaridadeId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewUsuarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
