public class GitRepoRepository : IGitRepoRepository
{
    private readonly GitInsightContext _context;

    public GitRepoRepository(GitInsightContext context)
    {
        _context = context;
    }

    public (Response Response, int RepoId) Create(GitRepoCreateDTO repo)
    {
        throw new NotImplementedException();
    }

    public Response Delete(int repoId, bool force = false)
    {
        throw new NotImplementedException();
    }

    public GitRepoDTO? Find(int repoId)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyCollection<GitRepoDTO> Read()
    {
        throw new NotImplementedException();
    }

    public Response Update(GitRepoDTO repo)
    {
        throw new NotImplementedException();
    }
}