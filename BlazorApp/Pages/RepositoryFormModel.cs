using System.ComponentModel.DataAnnotations;
public class RepositoryFormModel
{
    [Required]
    public string? Username { get; set; }
    public string? RepositoryName { get; set; }
}