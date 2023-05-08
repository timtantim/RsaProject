using Microsoft.EntityFrameworkCore;
using RsaProject.DbContexts;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RsaProject.RepositoryService
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public ApplicationDbContext ApplicationDbContext { get; set; }

        public RepositoryBase(ApplicationDbContext applicationDbContext) {
            ApplicationDbContext = applicationDbContext;
        }
        public T Create(T entity)
        {
            ApplicationDbContext.Set<T>().Add(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            ApplicationDbContext.Set<T>().Remove(entity);   
        }

        public IQueryable<T> FindAll()
        {
            return ApplicationDbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return ApplicationDbContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            ApplicationDbContext.Set<T>().Update(entity);
        }
    }
}
