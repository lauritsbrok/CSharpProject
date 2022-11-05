using System.ComponentModel.DataAnnotations.Schema;

public class GitCommit
{
    public GitCommit(string id, string message)
    {
        Id = id;
        Message = message;
    }

    [Key]
    public string Id { get; set; }

    public string Message { get; set; }

    [Required(ErrorMessage = "Author is required.")]
    public GitAuthor Author { get; set; }
    [Required(ErrorMessage = "Repo is required.")]
    public GitRepo Repo { get; set; }
}