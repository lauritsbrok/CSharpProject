namespace Application.Infrastructure;

public class GitCommitRepository : IGitCommitRepository
{
    private readonly GitInsightContext _context;

    public GitCommitRepository(GitInsightContext context)
    {
        _context = context;
    }

    public (Response Response, int Id) Create(GitCommitCreateDTO commit)
    {
        var entity = _context.Commits.FirstOrDefault(c => c.CommitHash == commit.commitId);
        Response response;
        if(entity is null) {
            entity = new GitCommit(commit.commitId, commit.Message);
            entity.Author = CreateOrUpdateAuthor(commit.Author);
            entity.Repo = CreateOrUpdateRepo(commit.RepoUrl);
            _context.Commits.Add(entity);
            _context.SaveChanges();
            response = Response.Created;
        } else {
            response = Response.Conflict;
        }
        return (response, entity!.Id);
    }

    public Response Delete(string commitId, bool force = false)
    {
        Response response;
        var entity = _context.Commits.FirstOrDefault(c => c.CommitHash == commitId);
        if(entity != null && force) {
            _context.Commits.Remove(entity);
            _context.SaveChanges();
            response = Response.Deleted;
        } else {
            response = Response.Conflict;
        }

        return response;
    }

    public GitCommitDTO? Find(string commitId)
    {
        var commit = from c in _context.Commits
                     where c.CommitHash == commitId
                     select new GitCommitDTO(c.CommitHash, c.Message, c.Author.Name, c.Repo.Url);
        return commit.FirstOrDefault();
    }

    public IReadOnlyCollection<GitCommitDTO> Read()
    {
        var Commits = 
            from c in _context.Commits
            orderby c.CommitHash
            select new GitCommitDTO(c.CommitHash, c.Message, c.Author.Name, c.Repo.Url);

        return Commits.ToArray();
    }


    private GitAuthor CreateOrUpdateAuthor(GitAuthorDTO author)
    {
        var foundAuthor = _context.Authors.Where(a => a.Email == author.Email).FirstOrDefault();
        return foundAuthor ?? new GitAuthor(author.Name, author.Email);
    }

    private GitRepo CreateOrUpdateRepo(string repoUrl)
    {
        var foundRepo = _context.Repos.Where(r => r.Url == repoUrl).FirstOrDefault();
        return foundRepo ?? new GitRepo(repoUrl);
    }
}