using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacNivelamento.Domain.Notifications
{
    public interface INotification
    {
        [System.Runtime.Serialization.IgnoreDataMember]
        ValidationResult ValidationResult { get; }
        bool IsValid();
    }
}
