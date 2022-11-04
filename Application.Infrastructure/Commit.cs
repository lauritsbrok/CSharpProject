public class Commit
{
    public int Id { get; set; }

    public string Message { get; set; }
    public Author Author { get; set; }

    public Repo Repo { get; set; }
}