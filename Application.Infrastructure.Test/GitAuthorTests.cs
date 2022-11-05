
using Application.Infrastructure;

namespace Assignment.Infrastructure.Tests;

public class GitAuthorRepositoryTests
{
    private readonly SqliteConnection _connection;
    private readonly GitInsightContext _context;
    private readonly GitAuthorRepository _repository;
    
    public GitAuthorRepositoryTests()
    {
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();
        var builder = new DbContextOptionsBuilder<GitInsightContext>().UseSqlite(_connection);
        _context = new GitInsightContext(builder.Options);
        _context.Database.EnsureCreated();

        var bob = new GitAuthor("Bob", "bob@mail.com") {Id = 1};

        var tim = new GitAuthor("Tim", "tim@mail.com") {Id = 2};

        _context.Authors.AddRange(bob, tim);
        _context.SaveChanges();

        _repository = new GitAuthorRepository(_context);
    }

    [Fact]
    public void Create()
    {
        var (response, createdId) = _repository.Create(new GitAuthorCreateDTO("Lisa", "lisa@mail.com"));

        response.Should().Be(Response.Created);

        createdId.Should().Be(3);
    }

    [Fact]
    public void Delete()
    {
        var response = _repository.Delete(2);

        response.Should().Be(Deleted);

        var entity = _context.Authors.Find(2);

        entity.Should().BeNull();
    }

    [Fact]
    public void Find() => _repository.Find(2).Should().Be(new GitAuthorDTO(2, "Tim", "tim@mail.com"));

    [Fact]
    public void Find_Non_Existing() => _repository.Find(42).Should().BeNull();

    [Fact]
    public void Read() => _repository.Read().Should().BeEquivalentTo(new[] { new GitAuthorDTO(1, "Bob", "bob@mail.com"), new GitAuthorDTO(2, "Tim", "tim@mail.com") });

    [Fact]
    public void Update_Non_Existing() => _repository.Update(new GitAuthorUpdateDTO(42, "Tim", "tim@mail.com")).Should().Be(NotFound);

    [Fact]
    public void Update_Conflict()
    {
        var response = _repository.Update(new GitAuthorUpdateDTO(2, "Bob", "bob@mail.com"));

        response.Should().Be(Conflict);

        var entity = _context.Authors.Find(2)!;

        entity.Name.Should().Be("Bob");
    }

    [Fact]
    public void Update()
    {
        var response = _repository.Update(new GitAuthorUpdateDTO(2, "Timmy", "timmy@gmail.com"));

        response.Should().Be(Updated);

        var entity = _context.Authors.Find(2)!;

        entity.Name.Should().Be("Timmy");
    }
}