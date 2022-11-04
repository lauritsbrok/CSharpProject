public class Repo
{
    public int Id { get; set; }
    public ICollection<Commit> commits { get; set; }

    public ICollection<Author> authors { get; set; }
}