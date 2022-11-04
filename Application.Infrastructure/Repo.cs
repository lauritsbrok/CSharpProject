public class Repo
{
    public int Id { get; set; }

    public string Url { get; set; }
    public ICollection<Commit> commits { get; set; }

    public ICollection<Author> authors { get; set; }
}