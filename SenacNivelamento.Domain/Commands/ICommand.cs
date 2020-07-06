using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SenacNivelamento.Domain.Commands
{
    public interface ICommand : IRequest
    {
        [IgnoreDataMember]
        ValidationResult ValidationResult { get; set; }
    }
    public interface ICommand<out TResult> : IRequest<TResult> where TResult: ICommandResult
    {
        [IgnoreDataMember]
        ValidationResult ValidationResult { get; set; }
    }
}
