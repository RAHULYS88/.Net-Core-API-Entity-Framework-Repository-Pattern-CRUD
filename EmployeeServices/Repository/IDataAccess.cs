using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeServices.Repository
{
    public interface IDataAccess<TEntity, U> where TEntity : class
    {
        IEnumerable<TEntity> GetBooks();
        TEntity GetBook(U id);
        int AddBook(TEntity b);
        int UpdateBook(U id, TEntity b);
        int DeleteBook(U id);
    }
}
