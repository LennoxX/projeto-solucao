using Solucao.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Solucao.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        Page<T> GetPaged(int page, int size);

        T GetById(Expression<Func<T, bool>> predicate);

        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);
    }
}
