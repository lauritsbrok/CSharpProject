using System.ComponentModel.DataAnnotations.Schema;

public class GitCommit
{
    [Key]
    public string Id { get; set; }

    public string Message { get; set; }

    [Required(ErrorMessage = "Author is required.")]
    public GitAuthor Author { get; set; }
    [Required(ErrorMessage = "Repo is required.")]
    public GitRepo Repo { get; set; }
}