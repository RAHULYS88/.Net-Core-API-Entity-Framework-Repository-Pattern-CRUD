using EmployeeServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeServices.Repository
{
    public class DataAccessRepository : IDataAccess<Employee, int>
    {
        EmployeesDbContext ctx;
        public DataAccessRepository(EmployeesDbContext c)
        {
            ctx = c;
        }
        public int AddBook(Employee b)
        {
            ctx.employees.Add(b);
            int res = ctx.SaveChanges();
            return res;
        }

        public int DeleteBook(int id)
        {
            int res = 0;
            var book = ctx.employees.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                ctx.employees.Remove(book);
                res = ctx.SaveChanges();
            }
            return res;
        }

        public Employee GetBook(int id)
        {
            var book = ctx.employees.FirstOrDefault(b => b.Id == id);
            return book;
        }

        public IEnumerable<Employee> GetBooks()
        {
            var books = ctx.employees.ToList();
            return books;
        }

        public int UpdateBook(int id, Employee b)
        {
            int res = 0;
            var book = ctx.employees.Find(id);
            if (book != null)
            {
                //book.BookTitle = b.BookTitle;
                //book.AuthorName = b.AuthorName;
                //book.Publisher = b.Publisher;
                //book.Genre = b.Genre;
                //book.Price = b.Price;
                res = ctx.SaveChanges();
            }
            return res;
        }
    }
}

