using System;
using System.Linq;  
using System.Linq.Expressions;                                                                                                                                                          
using Library_Management_SYS.Application.Interfaces;
using Library_Management_SYS.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_SYS.Repository
{
    public class RepositoryBase<T>  : IRepositoryBase<T>  where T : class
    {
        public RepositoryBase(LibraryDbContext context) {
            LibraryDbContext = context;
        }
        protected LibraryDbContext LibraryDbContext { get; set; }
        public IQueryable<T> FindAll()
        {
            return LibraryDbContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return LibraryDbContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            LibraryDbContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            LibraryDbContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            LibraryDbContext.Set<T>().Remove(entity);
        }
    }
}
