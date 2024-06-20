using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Interfaces
{
    public interface IUnitOfWork
    {
        public ILmsRepository<TEntity> Repository<TEntity>() where TEntity : class;

        bool Complete();
    }
}
