public class Author
{
    public Author(string name, string email)
    {
        Name = name;
        Email = email;
        commits = new HashSet<Commit>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public ICollection<Commit> commits { get; set; }

}