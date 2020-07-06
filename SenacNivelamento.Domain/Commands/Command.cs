using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace SenacNivelamento.Domain.Commands
{
    public abstract class Command<TResult>: ICommand<TResult> where TResult : ICommandResult
    {
        [IgnoreDataMember, JsonIgnore]
        public ValidationResult ValidationResult{ get; set; }

        public abstract bool IsValid();
    }
}
