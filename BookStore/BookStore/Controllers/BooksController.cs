using BookStore.Api.Contracts;
using BookStore.Business.Services;
using BookStore.Core.models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        [Route("/list")]
        public async Task<ActionResult<List<BooksResponse>>> GetBooks()
        {
            var books = await _booksService.GetAllBooks();

            var response = books.Select(b => new BooksResponse(b.Id, b.Title, b.Description, b.Price, b.CreatedDate, b.ModifiedDate));

            return Ok(response);
        }

        [HttpPost]
        [Route("/create")]
        public async Task<ActionResult<Guid>> CreateBook([FromBody] BookCreateRequest request)
        {
            var (book, error) = Book.Create(
                Guid.NewGuid(), 
                request.Title,
                request.Description,
                request.Price,
                DateTime.UtcNow,
                DateTime.UtcNow,
                null);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var bookId = await _booksService.CreateBook(book);

            return Ok(bookId);
        }

        [HttpPut]
        [Route("/delete")]
        public async Task<ActionResult<Guid>> DeleteBook(Guid id)
        {
            var bookId = await _booksService.DeleteBook(id);

            return Ok(bookId);
        }

        [HttpPut]
        [Route("/update")]
        public async Task<ActionResult<Guid>> UpdateBook(Guid id, [FromBody] BookCreateRequest request)
        {
           var bookId = await _booksService.UpdateBook(id, request.Title, request.Description, request.Price);

            return Ok(bookId);

        }
    }
}
