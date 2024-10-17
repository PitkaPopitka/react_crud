namespace BookStore.Api.Contracts
{
    public record BookCreateRequest(
        string Title,
        string Description,
        decimal Price);
}
