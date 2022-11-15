using System.ComponentModel.DataAnnotations.Schema;

public class GitCommit
{
    public GitCommit(string commitHash, string message)
    {
        CommitHash = commitHash;
        Message = message;
    }

    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "CommitHash is required.")]
    public string CommitHash { get; set; }

    public string Message { get; set; }

    [Required(ErrorMessage = "Author is required.")]
    public GitAuthor Author { get; set; }
    [Required(ErrorMessage = "Repo is required.")]
    public GitRepo Repo { get; set; }
}