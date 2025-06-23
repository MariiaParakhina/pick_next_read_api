namespace Infrastructure;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsPaper { get; set; }
    public string Status { get; set; }
}