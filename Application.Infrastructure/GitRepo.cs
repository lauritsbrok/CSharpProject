public class GitRepo
{
    public GitRepo(string url)
    {
        Url = url;
        this.Commits = new HashSet<GitCommit>();
        this.Authors = new HashSet<GitAuthor>();
    }

    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Url is required.")]
    public string Url { get; set; }
    public ICollection<GitCommit> Commits { get; set; }

    public ICollection<GitAuthor> Authors { get; set; }
}