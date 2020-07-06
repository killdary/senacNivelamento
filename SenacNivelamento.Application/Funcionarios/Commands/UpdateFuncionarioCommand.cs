using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class UpdateFuncionarioCommand : FuncionarioCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new UpdateFuncionarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        public class UpdateFuncionarioCommandHandler : IRequestHandler<UpdateFuncionarioCommand, FuncionarioCommandResult>
        {
            private readonly IFuncionarioWritingRepository _funcionarioContext;
            private readonly ICargoWritingRepository _cargoContext;
            private readonly IEmpresaWritingRepository _empresaContext;

            public UpdateFuncionarioCommandHandler(
                IFuncionarioWritingRepository funcionarioContext,
                ICargoWritingRepository cargoContext,
                IEmpresaWritingRepository empresaContext)
            {
                _funcionarioContext = funcionarioContext;
                _cargoContext = cargoContext;
                _empresaContext = empresaContext;
            }

            public async Task<FuncionarioCommandResult> Handle(UpdateFuncionarioCommand request, CancellationToken cancellationToken)
            {
                if (!request.IsValid())
                {
                    var response = new FuncionarioCommandResult();
                    response.CopyErrorsFromValidations(request.ValidationResult);
                    return response;
                }

                var entity = await _funcionarioContext.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (entity == null)
                {
                    var response = new FuncionarioCommandResult();
                    response.AddNotification(nameof(Funcionario), "Funcionário não foi encontrado");
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

                entity.Nome = request.Nome;
                entity.Login = request.Login;
                entity.Logradouro = request.Logradouro;
                entity.Numero = request.Numero;
                entity.Bairro = request.Bairro;
                entity.Cidade = request.Cidade;
                entity.Estado = request.Estado;
                entity.Cep = request.Cep;
                entity.Pais = request.Pais;
                entity.Empresa = empresa;
                entity.Cargo = cargo;



                if (!entity.Senha.Equals(request.Senha))
                {
                    byte[] data = Encoding.ASCII.GetBytes(request.Senha);
                    data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                    entity.Senha = Encoding.ASCII.GetString(data); ;
                }


                _funcionarioContext.Update(entity);
                await _funcionarioContext.SaveChangesAsync(cancellationToken);

                return new FuncionarioCommandResult()
                {
                    Id = entity.Id
                };
            }
        }
    }
}
