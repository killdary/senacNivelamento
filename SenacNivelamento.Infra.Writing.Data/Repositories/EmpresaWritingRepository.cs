using SenacNivelamento.Application.Empresas.Repositories;
using SenacNivelamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacNivelamento.Infra.Writing.Data.Repositories
{
    public class EmpresaWritingRepository : BaseRepository<Empresa>, IEmpresaWritingRepository
    {
        public EmpresaWritingRepository(WritingContext context) : base(context)
        {
        }
    }
}
