using System.Threading.Tasks;
using Dapper;
using Domain;

namespace Infrastructure;

public interface IBookRepository
{
    Task<Book[]> GetBooks();
    Task AddBook(Book book);
    Task UpdateBookStatus(int id, string status);
}
public class BookRepository(IDbConnectionFactory dbConnectionFactory):IBookRepository
{
    public async Task<Book[]> GetBooks()
    {
        using var dbConnection = await dbConnectionFactory.CreateConnectionAsync();
        var books = await dbConnection.QueryAsync<BookDto>("SELECT * FROM Books");
        return books.ToArray().Select(BookMapper.MapDto).ToArray();
    }

    public async Task AddBook(Book book)
    {
        var bookDto = BookMapper.MapDtoToBookDto(book);
        using var dbConnection = await dbConnectionFactory.CreateConnectionAsync();
        await dbConnection.ExecuteAsync(
            @"INSERT INTO books (title, author, isPaper, status)
      VALUES (@Title, @Author, @IsPaper, @Status)",
            bookDto);
    }

    public async Task UpdateBookStatus(int id, string status)
    {
        using var dbConnection = await dbConnectionFactory.CreateConnectionAsync();
        await dbConnection.ExecuteAsync(
            @"UPDATE books SET status = @Status WHERE id = @Id ", new{Status=status, Id=id}
    
    );
}
}