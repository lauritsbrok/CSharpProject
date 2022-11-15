

using Application.Infrastructure;

namespace Assignment.Infrastructure.Tests;

public class GitCommitRepositoryTests : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly GitInsightContext _context;
    private readonly GitCommitRepository _repository;

    private readonly GitRepo _gitRepo;
    private readonly GitAuthor _gitAuthor;

    
    public GitCommitRepositoryTests()
    {
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();
        var builder = new DbContextOptionsBuilder<GitInsightContext>().UseSqlite(_connection);
        _context = new GitInsightContext(builder.Options);
        _context.Database.EnsureCreated();

        _gitRepo = new GitRepo("repo1.dk");

        _gitAuthor = new GitAuthor("Author1","author1@test.com");

        var commit1 = new GitCommit("1", "working on test 1") {Id = 1, Author = _gitAuthor,Repo = _gitRepo};
        var commit2 = new GitCommit("2", "working on test 2") {Id = 2, Author = _gitAuthor,Repo = _gitRepo};

        _context.Commits.AddRange(commit1, commit2);
        _context.SaveChanges();

        _repository = new GitCommitRepository(_context);
    }

    [Fact]
    public void Create_New_Not_Existing_Commit_Returns_Created_And_New_Commit_Id()
    {
        var (response, createdId) = _repository.Create(new GitCommitCreateDTO("3", "working on test 3", new GitAuthorDTO(_gitAuthor.Name, _gitAuthor.Email), "repo1.dk"));

        response.Should().Be(Response.Created);

        createdId.Should().Be(3);
    }

    [Fact]
    public void Create_New_Existing_Commit_Returns_Conflict_And_Old_Commit_Id()
    {
        var (response, createdId) = _repository.Create(new GitCommitCreateDTO("2", "working on test 2", new GitAuthorDTO(_gitAuthor.Name, _gitAuthor.Email), "repo1.dk"));

        response.Should().Be(Response.Conflict);

        createdId.Should().Be(2);
    }

    [Fact]
    public void Deleting_Non_Existing_Commit_Returns_Conflict() { 
        var response = _repository.Delete("3");
        response.Should().Be(Response.Conflict);
    }

    [Fact]
    public void Deleting_Existing_Commit_Without_force_Returns_Conflict() { 
        var response = _repository.Delete("2");
        response.Should().Be(Response.Conflict);
    }

    [Fact]
    public void Deleting_Existing_Commit_With_force_Returns_Deleted() { 
        var response = _repository.Delete("2", true);
        response.Should().Be(Response.Deleted);
    }

    [Fact]
    public void Find_Non_Existing_Commit_Returns_Null() {
        var result = _repository.Find("3");
        result.Should().BeNull();
    }

    [Fact]
    public void Find_Existing_Commit_Returns_commit() {
        var result = _repository.Find("2");
        result!.commitId.Should().Be("2");
        result!.AuthorName.Should().Be("Author1");
    }

    [Fact]
    public void Read() => _repository.Read().Should().BeEquivalentTo(new[] { new GitCommitDTO("1", "working on test 1", "Author1", "repo1.dk"), new GitCommitDTO("2", "working on test 2", "Author1", "repo1.dk") });
    



    public void Dispose()
    {
        _context.Dispose();
        _connection.Close();
    }
}