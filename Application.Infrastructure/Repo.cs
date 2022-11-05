public class GitRepo
{
    public int Id { get; set; }

    public string Url { get; set; }
    public ICollection<GitCommit> commits { get; set; }

    public ICollection<GitAuthor> authors { get; set; }
}