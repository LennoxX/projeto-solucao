using Microsoft.EntityFrameworkCore;
using Solucao.Domain.Response;
using Solucao.Repositories.Context;
using Solucao.Repositories.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Solucao.Repositories.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            _context.Set<T>().AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public T GetById(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().SingleOrDefault(predicate);
        }

        public Page<T> GetPaged(int pageNumber, int pageSize)
        {
           

            IQueryable<T> tmpList = GetAll();
            Page<T> Pageable = new Page<T>();
            Pageable.Content = tmpList.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            Pageable.Size = Pageable.Content.Count();
            Pageable.TotalElements = tmpList.Count();
            Pageable.PageIndex = pageNumber;
            Pageable.TotalPages =(int)Math.Ceiling(decimal.Divide(Pageable.TotalElements, pageSize));

            return Pageable;
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
