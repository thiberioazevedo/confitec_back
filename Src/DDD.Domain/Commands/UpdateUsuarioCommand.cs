using System;
using DDD.Domain.Models;
using DDD.Domain.Validations;

namespace DDD.Domain.Commands
{
    public class UpdateUsuarioCommand : UsuarioCommand
    {
        public UpdateUsuarioCommand(int id, string nome, string sobrenome, string email, DateTime dataNascimento, int escolaridadeId)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            EscolaridadeId = escolaridadeId;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateUsuarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
