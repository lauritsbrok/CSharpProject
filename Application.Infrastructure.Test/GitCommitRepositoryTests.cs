

using Application.Infrastructure;

namespace Assignment.Infrastructure.Tests;

public class GitCommitRepositoryTests : IDisposable
{
    // private readonly SqliteConnection _connection;
    // private readonly GitInsightContext _context;
    // private readonly GitCommitRepository _repository;
    
    // public GitCommitRepositoryTests()
    // {
    //     _connection = new SqliteConnection("Filename=:memory:");
    //     _connection.Open();
    //     var builder = new DbContextOptionsBuilder<GitInsightContext>().UseSqlite(_connection);
    //     _context = new GitInsightContext(builder.Options);
    //     _context.Database.EnsureCreated();

    //     var commit1 = new GitCommit("1", "Working on test1");

    //     var commit2 = new GitCommit("2", "Working on test2");

    //     _context.Commits.AddRange(commit1, commit2);
    //     _context.SaveChanges();

    //     _repository = new GitCommitRepository(_context);
    // }

    // [Fact]
    // public void Create_New_Not_Existing_Commit_Returns_Created()
    // {
    //     var newCommit = new GitCommitCreateDTO("3", "Working on test2", "author", "repo");
    //     var (response, commitId) = _repository.Create(newCommit);
    //     response.Should().Be(Created);
    //     commitId.Should().Be("3");
    // }

    public void Dispose()
    {
        // _context.Dispose();
        // _connection.Close();
    }
}