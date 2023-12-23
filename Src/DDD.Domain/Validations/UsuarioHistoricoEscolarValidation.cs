using System;
using DDD.Domain.Commands;
using FluentValidation;

namespace DDD.Domain.Validations
{
    public abstract class UsuarioHistoricoEscolarValidation<T> : AbstractValidator<T> where T : UsuarioHistoricoEscolarCommand
    {
        protected void ValidaId()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0)
                .WithMessage("O id deve ser maior que zero");
        }

        protected void ValidaAnexoId()
        {
            RuleFor(c => c.AnexoId)
                .GreaterThan(0)
                .WithMessage("O AnexoId deve ser maior que zero");

        }

        protected void ValidaUsuarioId()
        {
            RuleFor(c => c.UsuarioId)
                .GreaterThan(0)
                .WithMessage("O UsuarioId deve ser maior que zero");
        }

        protected void ValidaNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("Certifique-se de ter digitado o Nome");
        }
    }
}
