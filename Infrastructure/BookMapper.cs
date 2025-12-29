using Domain;

namespace Infrastructure;

public static class BookMapper
{
    public static Book MapDto(BookDto dto)
    {
        return new Book
        {
            Id = dto.Id,
            Title = dto.Title,
            Author = dto.Author,
            IsPaper = dto.IsPaper,
            Status = MapStatus(dto.Status),
            LastModified = dto.LastModified,
        };
    }

    public static BookDto MapDtoToBookDto(Book book)
    {
        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            IsPaper = book.IsPaper,
            Status = MapStatus(book.Status),
            LastModified = book.LastModified
        };
    }

    public static STATUS MapStatus(string status)
    {
        switch (status)
        {
            case nameof(STATUS.FINISHED): return STATUS.FINISHED;
            case nameof(STATUS.ADDED): return STATUS.ADDED;
            case nameof(STATUS.STARTED): return STATUS.STARTED;
            default: return STATUS.ADDED;
        }

        ;
    }

    public static string MapStatus(STATUS status)
    {
        switch (status)
        {
            case STATUS.FINISHED: return nameof(STATUS.FINISHED);
            case STATUS.ADDED: return nameof(STATUS.ADDED);
            case STATUS.STARTED: return nameof(STATUS.STARTED);
            default: return nameof(STATUS.ADDED);
        }

        ;
    }
}