namespace Application.Infrastructure;

public class GitCommitRepository : IGitCommitRepository
{
    private readonly GitInsightContext _context;

    public GitCommitRepository(GitInsightContext context)
    {
        _context = context;
    }

    public (Response Response, string CommitId) Create(GitCommitCreateDTO commit)
    {
        throw new NotImplementedException();
    }

    public Response Delete(string commitId, bool force = false)
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