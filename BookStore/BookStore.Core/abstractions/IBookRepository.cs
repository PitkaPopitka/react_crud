using BookStore.Core.models;

namespace BookStore.Data.Repository
{
    public interface IBookRepository
    {
        Task<Guid> Create(Book book);
        Task<Guid> Delete(Guid id);
        Task<List<Book>> Get();
        Task<Guid> Update(Guid id, string title, string description, decimal prce);
    }
}