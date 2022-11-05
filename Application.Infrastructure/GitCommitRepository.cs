namespace Application.Infrastructure;

public class GitCommitRepository : IGitCommitRepository
{
    private readonly GitInsightContext _context;

    public GitCommitRepository(GitInsightContext context)
    {
        _context = context;
    }

    public (Response Response, int CommitId) Create(GitCommitCreateDTO commit)
    {
        throw new NotImplementedException();
    }

    public Response Delete(int commitId, bool force = false)
    {
        throw new NotImplementedException();
    }

    public GitCommitDTO? Find(int commitId)
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