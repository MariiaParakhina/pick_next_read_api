using System.Threading.Tasks;
using Core;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controller;

[ApiController]
[Route("api/books")]
public class BooksController(BookService bookService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var books = await bookService.GetAllBooksAsync();
        return Ok(books);
    }

    [HttpPost]
    public async Task<IActionResult> AddBook(Book book)
    {
        await bookService.AddBookAsync(book);
        return Ok();
    }

    [HttpGet("pick")]
    public async Task<IActionResult> PickBook()
    {
        var book = await bookService.PickNextRead();
        return Ok(book);
    }

    [HttpGet("analytics")]
    public async Task<IActionResult> GetAnalytics()
    {
        var analytics = await bookService.GetAnalytics();
        return Ok(analytics);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBookStatus([FromQuery] int id, [FromBody] UpdateRequest update)
    {
        await bookService.UpdateBookStatus(id, update);
        return Ok();
    }
}