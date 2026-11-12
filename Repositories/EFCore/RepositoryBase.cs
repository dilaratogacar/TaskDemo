using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Repositories.EFCore
{
    //CRUD işlemlerini tek bir yerden yönetmek için kullanılan temel sınıf

    //Bu sınıf direkt kullanılamaz, sadece başka sınıflar miras alabilir.

    // Buradaki <T> ifadesi hangi entity ile çalışılacağını belirtir.(Book,Task,Sales)
    // where koşulundaki ifadede T'nin sadece sınıf olabileceği belirtildi.
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
        where T : class

    {
        //EF'in bağlantı yapısını yöneten sınıf
        //Protected olmasının nedeni sadece kendisi ve miras alan sınıfların erişme hakkının olması için
        protected readonly RepositoryContext _context;

        public RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }
        //Set<T>() kısımlarda işlem yapılması istenen tabloya erişim içindir.
        public void Create(T entity) => _context.Set<T>().Add(entity);

        public void Delete(T entity) => _context?.Set<T>().Remove(entity);

        //trackChangees bir kaydın bellekte takip edilip edilmeyeceğini belirler.
        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
            _context.Set<T>().AsNoTracking() : _context.Set<T>();

        //Func<T,bool> kısmında T tipinde yani erişilecek tabloyu al, bool döndür
        // Expression<Func<T, bool>> expression kısmı yazılan fonksiyonu SQL'e çevirir.
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
            _context.Set<T>().Where(expression).AsNoTracking() :
            _context.Set<T>().Where(expression);

        public void Update(T entity) => _context?.Set<T>().Update(entity);
    }
}
