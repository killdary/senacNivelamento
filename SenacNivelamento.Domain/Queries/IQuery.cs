using MediatR;
using SenacNivelamento.Domain.Core.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacNivelamento.Domain.Queries
{
    public interface IQuery : IRequest
    { }

    public interface IQuery<out TResult> : IRequest<TResult> where TResult : IQueryResult
    { }
}
