using BookStore.Core.models;
using BookStore.Data.Repository;

namespace BookStore.Business.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBookRepository _bookRepository;

        public BooksService(IBookRepository booksRepository)
        {
            _bookRepository = booksRepository;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _bookRepository.Get();
        }

        public async Task<Guid> CreateBook(Book book)
        {
            return await _bookRepository.Create(book);
        }

        public async Task<Guid> UpdateBook(Guid id, string title, string description, decimal price)
        {
            return await _bookRepository.Update(id, title, description, price);
        }

        public async Task<Guid> DeleteBook(Guid id)
        {
            return await _bookRepository.Delete(id);
        }
    }
}
