namespace Application.Infrastructure;

public class GitCommitRepository : IGitCommitRepository
{
    private readonly GitInsightContext _context;

    public GitCommitRepository(GitInsightContext context)
    {
        _context = context;
    }

    public (Response Response, string commitId) Create(GitCommitCreateDTO commit)
    {
        var entity = _context.Commits.FirstOrDefault(g => g.Id == g.Message);
        Response response;
        if(entity is null) {
            entity = new GitCommit(commit.Id, commit.Message);
            try {
                _context.Commits.Add(entity);
                _context.SaveChanges();
                response = Response.Created;
            } catch (Microsoft.EntityFrameworkCore.DbUpdateException) {
                response = Response.Conflict;
            }
        } else {
            response = Response.Conflict;
        }

        return (response, entity.Id);
    }

    public Response Delete(int commitId, bool force = false)
    {
        throw new NotImplementedException();
    }

    public Response Delete(string commitId, bool force = false)
    {
        throw new NotImplementedException();
    }

    public GitCommitDTO? Find(int commitId)
    {
        throw new NotImplementedException();
    }

    public GitCommitDTO? Find(string commitId)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyCollection<GitCommitDTO> Read()
    {
        throw new NotImplementedException();
    }

    public Response Update(GitCommitUpdateDTO commit)
    {
        throw new NotImplementedException();
    }
}