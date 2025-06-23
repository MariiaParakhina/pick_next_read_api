namespace Domain;

public interface IBookDataProvider
{
    Task<IEnumerable<Book>> GetBooksAsync();
    Task AddBookAsync(IEnumerable<Book> books);
}

public class BookDataProvider : IBookDataProvider
{
    public Task<IEnumerable<Book>> GetBooksAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddBookAsync(IEnumerable<Book> books)
    {
        throw new NotImplementedException();
    }
}