using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        //IBookRepository Book { get; }
        ITaskRepository Task { get; }
        ICategoriesRepository Categories { get; }
        IStatusRepository Status { get; }
        //IPublisherRepository Publisher { get; }
        //ICommentRepository Comment { get; }


        void Save();
    }
}

/*
 * IRepositoryBase<T> (interface)
        │
        ▼
RepositoryBase<T> (abstract class)
        │
        ▼
IBookRepository (interface)   ← entity’ye özel sözleşme
        │
        ▼
BookRepository (class)        ← entity’ye özel implementasyon
        │
        ▼
IRepositoryManager (interface)← tüm repository’leri birleştiren sözleşme
        │
        ▼
RepositoryManager (class)     ← repository’leri expose eder, dışarı aktarır + SaveChanges()
        │
        ▼
Controller (API katmanı)      ← sadece IRepositoryManager üzerinden erişir
 * 
 * 
 * */