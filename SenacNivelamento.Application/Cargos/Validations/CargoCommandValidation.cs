using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacNivelamento.Application.Cargos.Validations
{
    public class CargoCommandValidation<T>: AbstractValidator<T> where T : CargoCommand
    {
        protected void ValidarId()
        {
            RuleFor(c => c.Id)
                .NotNull().WithMessage("Campo id não pode ser nulo.")
                .NotEmpty().WithMessage("Campo id é obrigatório.");
        }
        protected void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotNull().WithMessage("Campo descrição não pode ser nulo.")
                .NotEmpty().WithMessage("Campo descrição é obrigatório.");
        }

        protected void ValidarSigla()
        {
            RuleFor(c => c.Sigla)
                .NotNull().WithMessage("Campo sigla não pode ser nulo.")
                .NotEmpty().WithMessage("Campo sigla é obrigatório.");
        }
    }
}
