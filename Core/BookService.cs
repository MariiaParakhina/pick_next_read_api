using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Infrastructure;

namespace Core;

public class BookService(IBookRepository bookRepository)
{
    public async Task<Book[]> GetAllBooksAsync()
    { 
        return await bookRepository.GetBooks();
    }

    public async Task AddBookAsync(Book book)
    {
        await bookRepository.AddBook(book);
    }

    public async Task<Book> PickNextRead()
    {
        var books = await GetAllBooksAsync();
        var unreadBooks = books.Where(b=> b.Status==STATUS.ADDED).ToArray();
        var totalUnread = unreadBooks.Length;
        var random = new Random();
        var index = random.Next(0, totalUnread);
        return unreadBooks[index];
    }

    public async Task<string> GetAnalytics()
    {
        var books = await GetAllBooksAsync();
        
        var finishedBooks = books.Where(b => b.Status==STATUS.FINISHED).ToArray().Length;
        
        return $"Books read {finishedBooks} from {books.Count()}. So far {finishedBooks/books.Count() * 100}%";
        
    }

    public async Task UpdateBookStatus(int bookId, UpdateRequest updateRequest)
    {
        await bookRepository.UpdateBookStatus(bookId, BookMapper.MapStatus(updateRequest.Status));
    }
}