using System;
using DDD.Domain.Commands;
using FluentValidation;

namespace DDD.Domain.Validations
{
    public abstract class UsuarioValidation<T> : AbstractValidator<T> where T : UsuarioCommand
    {
        protected void ValidaNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Certifique-se de ter digitado o Nome")
                .Length(2, 20).WithMessage("O Nome deve ter entre 2 e 20 caracteres");
        }

        protected void ValidaDataNascimento()
        {
            RuleFor(c => c.DataNascimento)
                .NotEmpty()
                .Must(HaveMinimumAge)
                .WithMessage("A idade do usuário não pode ser menor que 15 anos na data do cadastro");
        }

        protected void ValidaEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }

        protected void ValidaId()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0);
        }

        protected static bool HaveMinimumAge(DateTime dataNascimento)
        {
            return dataNascimento <= DateTime.Now.AddYears(-15);
        }
    }
}
