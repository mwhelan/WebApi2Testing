using System.Collections.Generic;
using TestableWebApi.Core.Model;

namespace TestableWebApi.Core.Queries
{
    public class FindUserBySearchTextQueryHandler : IQueryHandler<FindUserBySearchTextQuery, User[]>
    {
        public User[] Handle(FindUserBySearchTextQuery query)
        {
            return new User[]{new User(){Name="Michael"}};
        }
    }

    public class AllBooksQueryHandler
    {
        private readonly IBookRepository _bookRepository;
        private readonly BookResourceMapper _bookResourceMapper;

        public AllBooksQueryHandler(IBookRepository bookRepository, BookResourceMapper bookResourceMapper)
        {
            _bookRepository = bookRepository;
            _bookResourceMapper = bookResourceMapper;
        }

        public BookCatalogResource Query()
        {
            var books = _bookRepository.GetAll();
            BookCatalogResource resource = new BookCatalogResource();
            resource.Catalog = new List<BookResource>();
            foreach (var book in books)
            {
                resource.Catalog.Add(_bookResourceMapper.MapToResouce(book));
            }
            return resource;
        }
    }
    public class BookResourceMapper
    {
        public BookResource MapToResouce(Book book)
        {
            BookResource resource = new BookResource();
            resource.Id = book.Id;
            resource.Title = book.Title;
            resource.Author = book.Author;
            resource.Description = book.Description;
            return resource;
        }
    }


    public class BookCatalogResource
    {
        public IList<BookResource> Catalog { get; set; }
    }

    public class BookResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string CoverFilename { get; set; }
    }

}