namespace BookStore.Api.Contracts
{
    public record BooksResponse(
        Guid Id,
        string Title,
        string Description,
        decimal Price,
        DateTime CreatedDate,
        DateTime ModifiedDate);
}
