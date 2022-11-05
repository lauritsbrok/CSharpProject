namespace Application.Infrastructure;

public class GitCommitRepository : ICommitRepository
{
    private readonly GitInsightContext _context;

    public GitCommitRepository(GitInsightContext context)
    {
        _context = context;
    }

    public (Response Response, int CommitId) Create(CommitCreateDTO commit)
    {
        throw new NotImplementedException();
    }

    public Response Delete(int commitId, bool force = false)
    {
        throw new NotImplementedException();
    }

    public CommitDTO? Find(int commitId)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyCollection<CommitDTO> Read()
    {
        throw new NotImplementedException();
    }

    public Response Update(CommitUpdateDTO commit)
    {
        throw new NotImplementedException();
    }
}