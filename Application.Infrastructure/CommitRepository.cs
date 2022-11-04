namespace Application.Infrastructure;

public class CommitRepository : ICommitRepository
{
    private readonly GitInsightContext _context;

    public CommitRepository(GitInsightContext context)
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