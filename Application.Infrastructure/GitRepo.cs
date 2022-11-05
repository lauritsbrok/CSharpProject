public class GitRepo
{
    public GitRepo(int id, string url)
    {
        Id = id;
        Url = url;
        this.commits = new HashSet<GitCommit>();
        this.authors = new HashSet<GitAuthor>();
    }

    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Url is required.")]
    public string Url { get; set; }
    public ICollection<GitCommit> commits { get; set; }

    public ICollection<GitAuthor> authors { get; set; }
}