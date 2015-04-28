using System.Collections.Generic;

namespace TestableWebApi.Core.Model
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book Get(int bookId);
        Book Add(Book book);
        bool Delete(int bookId);
    }


}