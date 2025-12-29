using System;
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

    public async Task DeleteBook(int id)
    {
        await bookRepository.DeleteBook(id);
    }

    public async Task<Book> PickNextRead()
    {
        var books = await GetAllBooksAsync();
        var unreadBooks = books.Where(b => b.Status == STATUS.ADDED).ToArray();
        var totalUnread = unreadBooks.Length;
        var random = new Random();
        var index = random.Next(0, totalUnread);
        return unreadBooks[index];
    }

    public async Task<Analitycs> GetAnalytics()
    {
        var books = await GetAllBooksAsync();

        var finishedBooks = books.Where(b => b.Status == STATUS.FINISHED).ToArray().Length;
        float result = finishedBooks * 100.0f / (float)books.Length;
        var overallProgress = new Tuple<int,int>(books.Count(), finishedBooks);
        var booksThisYearFinished = books.Where(b => b.Status == STATUS.FINISHED && b.LastModified.Year == DateTime.Now.Year).ToArray().Length; 
        return new Analitycs{
            OverallProgress = overallProgress,
            ProgressThisYear = booksThisYearFinished
        };
    }

    public async Task UpdateBookStatus(int bookId, UpdateRequest updateRequest)
    {
        await bookRepository.UpdateBookStatus(bookId, BookMapper.MapStatus(updateRequest.Status));
    }
}