namespace BookStore.Core.models
{
    public class Book
    {
        public const int MAX_TITLE_LENGTH = 255;

        private Book(Guid id, string title, string description, decimal price, DateTime createdDate, DateTime modifiedDate, DateTime? deletedDate) 
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            DeletedDate = deletedDate;
        }

        public Guid Id { get; }

        public string Title { get; } = string.Empty;

        public string Description { get; } = string.Empty;

        public decimal Price { get; }

        public DateTime? DeletedDate { get; }

        public DateTime ModifiedDate { get; }

        public DateTime CreatedDate { get; }


        public static (Book book, string error) Create(Guid id, string title, string description, decimal price, DateTime createdDate, DateTime modifiedDate, DateTime? deletedDate)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                error = $"Заголовок не может быть пустым или длиннее {MAX_TITLE_LENGTH} символов";
            }

            var book = new Book(id, title, description, price, createdDate, modifiedDate, deletedDate);

            return (book, error);
        }
    }
}
