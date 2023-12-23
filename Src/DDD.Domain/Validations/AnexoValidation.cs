using System;
using DDD.Domain.Commands;
using FluentValidation;

namespace DDD.Domain.Validations
{
    public abstract class AnexoValidation<T> : AbstractValidator<T> where T : AnexoCommand
    {
        protected void ValidaNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Certifique-se de ter digitado o Nome")
                .Length(5, 50).WithMessage("O Nome deve ter entre 5 e 50 caracteres");
        }

        protected void ValidaFormato()
        {
            RuleFor(c => c.Formato)
                .NotEmpty().WithMessage("Certifique-se de ter digitado o formato")
                .Length(3, 4).WithMessage("O formato deve ter entre 3 e 4 caracteres");
        }
    }
}
