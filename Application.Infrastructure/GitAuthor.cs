public class GitAuthor
{
    public GitAuthor(string name, string email)
    {
        Name = name;
        Email = email;
        commits = new HashSet<GitCommit>();
    }

    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    public string Name { get; set; }

    [EmailAddress, Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; }

    public ICollection<GitCommit> commits { get; set; }

}