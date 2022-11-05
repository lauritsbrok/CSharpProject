public class GitRepoRepository : IRepoRepository
{
    private readonly GitInsightContext _context;

    public GitRepoRepository(GitInsightContext context)
    {
        _context = context;
    }

    public (Response Response, int RepoId) Create(RepoCreateDTO repo)
    {
        throw new NotImplementedException();
    }

    public Response Delete(int repoId, bool force = false)
    {
        throw new NotImplementedException();
    }

    public RepoDTO? Find(int repoId)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyCollection<RepoDTO> Read()
    {
        throw new NotImplementedException();
    }

    public Response Update(RepoDTO repo)
    {
        throw new NotImplementedException();
    }
}