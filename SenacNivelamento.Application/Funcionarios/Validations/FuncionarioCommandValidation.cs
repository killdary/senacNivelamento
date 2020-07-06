using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacNivelamento.Application.Funcionarios.Validations
{
    public class FuncionarioCommandValidation<T> : AbstractValidator<T> where T : FuncionarioCommand
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
                .NotNull().WithMessage("Campo nome não pode ser nulo.")
                .NotEmpty().WithMessage("Campo nome é obrigatório.");
        }

        protected void ValidarEmpresa()
        {
            RuleFor(c => c.EmpresaId)
                .NotNull().WithMessage("Campo empresaId não pode ser nulo.")
                .NotEmpty().WithMessage("Campo empresaId é obrigatório.")
                .GreaterThan(0).WithMessage("Campo empresaId deve ser maior que 0.");
        }

        protected void ValidarCargo()
        {
            RuleFor(c => c.CargoId)
                .NotNull().WithMessage("Campo cargoId não pode ser nulo.")
                .NotEmpty().WithMessage("Campo cargoId é obrigatório.")
                .GreaterThan(0).WithMessage("Campo cargoId deve ser maior que 0.");
        }

        protected void ValidaLogradouro()
        {
            RuleFor(c => c.Logradouro)
                .NotNull().WithMessage("Campo logradouro não pode ser nulo.")
                .NotEmpty().WithMessage("Campo logradouro é obrigatório.");
        }

        protected void ValidaNumero()
        {
            RuleFor(c => c.Numero)
                .NotNull().WithMessage("Campo número não pode ser nulo.")
                .NotEmpty().WithMessage("Campo número é obrigatório.")
                .LessThanOrEqualTo(0).WithMessage("Campo número não pode ser menor que 0.");
        }

        protected void ValidaBairro()
        {
            RuleFor(c => c.Bairro)
                .NotNull().WithMessage("Campo bairro não pode ser nulo.")
                .NotEmpty().WithMessage("Campo bairro é obrigatório.");
        }

        protected void ValidaCidade()
        {
            RuleFor(c => c.Cidade)
                .NotNull().WithMessage("Campo cidade não pode ser nulo.")
                .NotEmpty().WithMessage("Campo cidade é obrigatório.");
        }

        protected void ValidaEstado()
        {
            RuleFor(c => c.Estado)
                .NotNull().WithMessage("Campo estado não pode ser nulo.")
                .NotEmpty().WithMessage("Campo estado é obrigatório.");
        }

        protected void ValidaCep()
        {
            RuleFor(c => c.Cep)
                .NotNull().WithMessage("Campo cep não pode ser nulo.")
                .NotEmpty().WithMessage("Campo cep é obrigatório.");
        }

        protected void ValidaPais()
        {
            RuleFor(c => c.Pais)
                .NotNull().WithMessage("Campo país não pode ser nulo.")
                .NotEmpty().WithMessage("Campo país é obrigatório.");
        }

        protected void ValidaLogin()
        {
            RuleFor(c => c.Login)
                .NotNull().WithMessage("Campo login não pode ser nulo.")
                .NotEmpty().WithMessage("Campo login é obrigatório.");
        }

        protected void ValidaSenha()
        {
            RuleFor(c => c.Senha)
                .NotNull().WithMessage("Campo senha não pode ser nulo.")
                .NotEmpty().WithMessage("Campo senha é obrigatório.");
        }
        protected void ValidarImagem()
        {
            RuleFor(c => c.Imagem)
                .NotNull().WithMessage("Campo imagem não pode ser nulo.")
                .NotEmpty().WithMessage("Campo imagem é obrigatório.");
        }
        protected void ValidarCpf()
        {
            RuleFor(c => c.Cpf)
                .NotNull().WithMessage("Campo imagem não pode ser nulo.")
                .NotEmpty().WithMessage("Campo imagem é obrigatório.");
        }

    }
}
