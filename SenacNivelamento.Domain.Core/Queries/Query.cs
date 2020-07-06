using System;
using System.Collections.Generic;
using System.Text;

namespace SenacNivelamento.Domain.Core.Queries
{
    public abstract class Query<TResult> : IQuery<TResult> where TResult : IQueryResult
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Offset => PageIndex * PageSize;
        public string Sort { get; set; }
    }
}
