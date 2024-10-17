using BookStore.Core.models;
using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _context;

        public BookRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> Get()
        {
            var bookEntities = await _context.Books
                                            .AsNoTracking()
                                            .Where(b => b.DeletedDate == null)
                                            .ToListAsync();

            var books = bookEntities
                                .Select(b => Book.Create(b.Id, b.Title, b.Description, b.Price, b.CreatedDate, b.ModifiedDate, b.DeletedDate).book)
                                .ToList();

            return books;
        }

        public async Task<Guid> Create(Book book)
        {
            var bookEntity = new BookEntity
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Price = book.Price,
                CreatedDate = book.CreatedDate,
                ModifiedDate = book.ModifiedDate
            };


            await _context.Books.AddAsync(bookEntity);
            await _context.SaveChangesAsync();

            return bookEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string title, string description, decimal prce)
        {
            await _context.Books
                        .Where(b => b.Id == id)
                        .ExecuteUpdateAsync(s => s
                            .SetProperty(b => b.Title, b => title)
                            .SetProperty(b => b.Description, b => description)
                            .SetProperty(b => b.Price, b => prce)
                            .SetProperty(b => b.ModifiedDate, b => DateTime.UtcNow));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Books
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.DeletedDate, b => DateTime.UtcNow));

            return id;
        }
    }
}
