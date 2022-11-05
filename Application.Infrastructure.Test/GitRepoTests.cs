
using Application.Infrastructure;

namespace Assignment.Infrastructure.Tests;

public class GitRepoRepositoryTests
{
    private readonly SqliteConnection _connection;
    private readonly GitInsightContext _context;
    private readonly GitAuthorRepository _repository;
    
    public GitRepoRepositoryTests()
    {
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();
        var builder = new DbContextOptionsBuilder<GitInsightContext>().UseSqlite(_connection);
        _context = new GitInsightContext(builder.Options);
        _context.Database.EnsureCreated();

        var TestGitRepo = new GitRepo("TestRepo.com") {Id = 1};

        _context.Authors.AddRange(bob, tim);
        _context.SaveChanges();

        _repository = new GitAuthorRepository(_context);
    }

    [Fact]
    public void Create()
    {

    }
}