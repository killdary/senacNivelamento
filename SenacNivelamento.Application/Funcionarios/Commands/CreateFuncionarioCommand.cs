using MediatR;
using SenacNivelamento.Application.Cargos;
using SenacNivelamento.Application.Cargos.Repositories;
using SenacNivelamento.Application.Common.Interfaces;
using SenacNivelamento.Application.Empresas.Repositories;
using SenacNivelamento.Application.Funcionarios.Repositories;
using SenacNivelamento.Application.Funcionarios.Validations;
using SenacNivelamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SenacNivelamento.Application.Funcionarios.Commands
{
    public class CreateFuncionarioCommand : FuncionarioCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new CreateFuncionarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        public class CreateFuncionarioCommandHandler : IRequestHandler<CreateFuncionarioCommand, FuncionarioCommandResult>
        {
            private readonly IFuncionarioWritingRepository _funcionarioContext;
            private readonly ICargoWritingRepository _cargoContext;
            private readonly IEmpresaWritingRepository _empresaContext;

            public CreateFuncionarioCommandHandler(
                IFuncionarioWritingRepository funcionarioContext,
                ICargoWritingRepository cargoContext,
                IEmpresaWritingRepository empresaContext)
            {
                _funcionarioContext = funcionarioContext;
                _cargoContext = cargoContext;
                _empresaContext = empresaContext;
            }

            public async Task<FuncionarioCommandResult> Handle(CreateFuncionarioCommand request, CancellationToken cancellationToken)
            {
                if (!request.IsValid())
                {
                    var response = new FuncionarioCommandResult();
                    response.CopyErrorsFromValidations(request.ValidationResult);
                    return response;
                }

                var cargo = await _cargoContext.FirstOrDefaultAsync(x => x.Id == request.CargoId);
                if (cargo == null)
                {
                    var response = new FuncionarioCommandResult();
                    response.AddNotification(nameof(Cargo), "Cargo informado não encontrado.");
                    return response;
                }

                var empresa = await _empresaContext.FirstOrDefaultAsync(x => x.Id == request.EmpresaId);
                if (empresa == null)
                {
                    var response = new FuncionarioCommandResult();
                    response.AddNotification(nameof(Empresa), "Empresa informada não encontrada.");
                    return response;
                }

                var entity = new Funcionario
                {
                    Nome = request.Nome,
                    Cpf = request.Cpf,
                    Login = request.Login,
                    Logradouro = request.Logradouro,
                    Numero = request.Numero,
                    Bairro = request.Bairro,
                    Cidade = request.Cidade,
                    Estado = request.Estado,
                    Cep = request.Cep,
                    Pais = request.Pais,
                    Empresa = empresa,
                    Cargo = cargo
                };

                byte[] data = Encoding.ASCII.GetBytes(request.Senha);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                entity.Senha = Encoding.ASCII.GetString(data); ;

                _funcionarioContext.Add(entity);
                await _funcionarioContext.SaveChangesAsync(cancellationToken);

                return new FuncionarioCommandResult()
                {
                    Id = entity.Id
                };
            }
        }
    }
}
