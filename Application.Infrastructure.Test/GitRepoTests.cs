
using System;
using System.Collections.Generic;
using Application.Infrastructure;

namespace Assignment.Infrastructure.Tests;

public class GitRepoRepositoryTests : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly GitInsightContext _context;
    private readonly GitRepoRepository _repository;

    private readonly GitRepo EmptyGitRepo;

    private readonly GitRepo NotEmptyGitRepo;
    
    public GitRepoRepositoryTests()
    {
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();
        var builder = new DbContextOptionsBuilder<GitInsightContext>().UseSqlite(_connection);
        _context = new GitInsightContext(builder.Options);
        _context.Database.EnsureCreated();

        EmptyGitRepo = new GitRepo("EmptyRepo.com") {Id = 1};
        NotEmptyGitRepo = new GitRepo("NotEmptyRepo.com") {Id = 2};
        NotEmptyGitRepo.Authors.Add(new GitAuthor("test", "test@test.com"));

        _context.Repos.AddRange(EmptyGitRepo,NotEmptyGitRepo);
        _context.SaveChanges();

        _repository = new GitRepoRepository(_context);
    }

    [Fact]
    public void Create_New_Not_Existing_Repo_Returns_Created()
    {
        var newRepo = new GitRepoCreateDTO("newRepo.com", null, null);
        var (response, repoId) = _repository.Create(newRepo);
        response.Should().Be(Created);
        repoId.Should().Be(NotEmptyGitRepo.Id + 1);
    }

    [Fact]
    public void Create_Existing_Repo_Returns_Conflict()
    {
        var newRepo = new GitRepoCreateDTO(EmptyGitRepo.Url, null, null);
        var (response, repoId) = _repository.Create(newRepo);
        response.Should().Be(Conflict);
        repoId.Should().Be(1);
    }

    [Fact]
    public void Deleting_Existing_Repo_With_No_Commits_Or_Authors_Without_Force_Returns_Deleted()
    {
        var response = _repository.Delete(1, false);
        response.Should().Be(Deleted);
    }

    [Fact]
    public void Deleting_Non_Existing_Repo_With_No_Commits_Or_Authors_Returns_Deleted()
    {
        var response = _repository.Delete(3, false);
        response.Should().Be(Conflict);
    }

    [Fact]
    public void Deleting_Existing_Repo_With_Commits_Or_Authors_Without_Force_Returns_ConFlict()
    {
        var response = _repository.Delete(2, false);
        response.Should().Be(Conflict);
    }

    [Fact]
    public void Deleting_Existing_Repo_With_Commits_Or_Authors_With_Force_Returns_Deleted()
    {
        var response = _repository.Delete(2, true);
        response.Should().Be(Deleted);
    }

    [Fact]
    public void Find_Existing_Repo_Returns_Repo()
    {
        var FoundRepo = _repository.Find(1);
        FoundRepo!.Url.Should().Be(EmptyGitRepo.Url);
    }

    [Fact]
    public void Find_Non_Existing_Repo_Returns_Null()
    {
        var FoundRepo = _repository.Find(3);
        FoundRepo.Should().Be(null);
    }

    [Fact]
    public void Read() {
        var read = _repository.Read();
        var emptyRepoCommits = new HashSet<string>();
        var emptyRepoAuthors = new HashSet<string>();
        var NotEmptyGitRepoCommits = new HashSet<string>();
        var NotEmptyGitRepoAuthors = new HashSet<string>();
        foreach (var author in NotEmptyGitRepo.Authors) {
            NotEmptyGitRepoAuthors.Add(author.Name);
        }
        var expected = new [] {new GitRepoDTO(EmptyGitRepo.Id, EmptyGitRepo.Url, emptyRepoCommits, emptyRepoAuthors), new GitRepoDTO(NotEmptyGitRepo.Id, NotEmptyGitRepo.Url, NotEmptyGitRepoCommits, NotEmptyGitRepoAuthors) };
        read.Should().BeEquivalentTo(expected);
    } 

    [Fact]
    public void Update_Non_Existing_Repo_Return_NotFound() {
        var NotExistingRepo = new GitRepoDTO(3, "NotExistingRepo.test", new HashSet<string>(), new HashSet<string>());
        var response = _repository.Update(NotExistingRepo);
        response.Should().Be(NotFound);
    } 

    [Fact]
    public void Update_Repo_Return_Updated() {
        // var ExistingRepo = NotEmptyGitRepo;
        // var newAuthor = new GitAuthor("updateAuthor", "update@update.dk");
        // ExistingRepo.Authors.Add(new GitAuthor("updateAuthor", "update@update.dk"));
        // var NotEmptyGitRepoAuthors = new HashSet<string>();
        // var NotEmptyGitRepoCommits = new HashSet<string>();
        // foreach (var author in ExistingRepo.Authors) {

        // }
        // var response = _repository.Update(new GitRepoDTO(ExistingRepo.Id, ExistingRepo.Url, NotEmptyGitRepoCommits, NotEmptyGitRepoAuthors));
        // var updateRepoDTO = _repository.Find(2);
        // response.Should().Be(Updated);
        // updateRepoDTO!.Authors.Should().Contain("updateAuthor");
    } 

    public void Dispose()
    {
        _context.Dispose();
        _connection.Close();
    }
}