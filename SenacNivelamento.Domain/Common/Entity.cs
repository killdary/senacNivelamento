using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace SenacNivelamento.Domain.Common
{
    public abstract class Entity
    {
        public long Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }

        [IgnoreDataMember, NotMapped, JsonIgnore]
        public ValidationResult ValidationResult { get; set; }

        protected Entity()
        {
            DataCriacao = DateTime.Now;
            DataAtualizacao = DateTime.Now;
            ValidationResult = new ValidationResult();
        }

        protected void AddNotification(string propertyName, string errorMessage)
        {
            ValidationResult.Errors.Add(new ValidationFailure(propertyName, errorMessage));
        }

        protected void AddNotification(IList<ValidationFailure> erros)
        {
            if (!(erros is null) && erros.Any())
            {
                foreach (var erro in erros)
                {
                    ValidationResult.Errors.Add(erro);
                }
            }
        }

        protected void ClearNotification()
        {
            ValidationResult.Errors.Clear();
        }
    }
}
