namespace Domain;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsPaper { get; set; }
    public STATUS Status { get; set; } = STATUS.ADDED;
    public DateTime LastModified { get; set; } = DateTime.Now;
}