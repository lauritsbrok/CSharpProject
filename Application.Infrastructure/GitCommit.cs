public class GitCommit
{
    public string Id { get; set; }

    public string Message { get; set; }
    public GitAuthor Author { get; set; }

    public GitRepo Repo { get; set; }
}