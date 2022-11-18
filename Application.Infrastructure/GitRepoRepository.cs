public class GitRepoRepository : IGitRepoRepository
{
    private readonly GitInsightContext _context;
    private readonly iGitCommitRepository _gitCommitRepository;
    private readonly iGitAuthorRepository _gitAuthorRepository;

    public GitRepoRepository(GitInsightContext context)
    {
        _context = context;
    }

    public GitRepoRepository(GitInsightContext context, iGitCommitRepository gitCommitRepository, iGitAuthorRepository gitAuthorRepository)
    {
        _context = context;
        _gitCommitRepository = gitCommitRepository;
        _gitAuthorRepository = gitAuthorRepository;
    }

    public (Response Response, int RepoId) Create(GitRepoCreateDTO repo)
    {
        var entity = _context.Repos.FirstOrDefault(r => r.Url == repo.Url);
        Response response;
        if(entity is null) {
            entity = new GitRepo(repo.Url);
            if(repo.Commits != null) {
                entity.Commits = CreateOrUpdateCommits(repo.Commits).ToHashSet();
            }
            if(repo.Authors is not null) {
                entity.Authors = CreateOrUpdateAuthors(repo.Authors).ToHashSet();
            }
            _context.Repos.Add(entity);
            _context.SaveChanges();
            response = Response.Created;
        } else {
            response = Response.Conflict;
        }

        return (response, entity.Id);
    }

    public Response Delete(int repoId, bool force = false)
    {
        var entity = _context.Repos.FirstOrDefault(r => r.Id == repoId);
        Response response;
        if(entity != null) {
            var repoIsEmpty = entity.Authors.Count == 0 && entity.Commits.Count == 0;
            if(force || repoIsEmpty) {
                _context.Repos.Remove(entity);
                _context.SaveChanges();
                response = Response.Deleted;
            } else {
                response = Response.Conflict;
            }
        } else {
            response = Response.Conflict;
        }
        return response;
    }

    public GitRepoDTO? Find(int repoId)
    {
        var Repo = from r in _context.Repos
                     where r.Id == repoId
                     let commits = r.Commits.Select(c => new GitCommitDTO(c.CommitHash, c.Message, c.Author.Name, c.Repo.Url)).ToHashSet()
                     let authors = r.Authors.Select(a => new GitAuthorDTO(a.Name, a.Email)).ToHashSet()
                     select new GitRepoDTO(r.Id, r.Url, commits, authors);
        return Repo.FirstOrDefault();
    }

    public IReadOnlyCollection<GitRepoDTO> Read()
    {
        var Repos = 
            from r in _context.Repos
            orderby r.Id
            let commits = r.Commits.Select(c => new GitCommitDTO(c.CommitHash, c.Message, c.Author.Name, c.Repo.Url)).ToHashSet()
            let authors = r.Authors.Select(a => new GitAuthorDTO(a.Name, a.Email)).ToHashSet()
            select new GitRepoDTO(r.Id, r.Url, commits, authors);

        return Repos.ToArray();
    }

    public Response Update(GitRepoDTO repo)
    {
        var entity = _context.Repos.Find(repo.Id);

        if (entity is null)
        {
            return Response.NotFound;
        }
            entity.Id = repo.Id;
            entity.Url = repo.Url;
            entity.Authors = CreateOrUpdateAuthors(repo.Authors).ToHashSet();
            entity.Commits = CreateOrUpdateCommits(repo.Commits).ToHashSet();

            _context.SaveChangesAsync();

        return Response.Updated;
        
    }

    private IEnumerable<GitCommit> CreateOrUpdateCommits(IEnumerable<GitCommitDTO> commits)
    {
        var existing = new Dictionary<int, GitAuthor>();
        foreach (var commit in commits) {
            var foundCommit = _context.Commits.Where(c => c.CommitHash == commit.commitId).FirstOrDefault();

            yield return foundCommit ?? new GitCommit(commit.commitId, commit.Message);
        }
    }

    private IEnumerable<GitAuthor> CreateOrUpdateAuthors(IEnumerable<GitAuthorDTO> authors)
    {
        var existing = new Dictionary<int, GitAuthor>();
        foreach (var author in authors) {
            var foundAuthor = _context.Authors.Where(a => a.Email == author.Email).FirstOrDefault();
            if (foundAuthor is null) {
                gitAuthorRepository.Create()

            }
            yield return foundAuthor ?? new GitAuthor(author.Name, author.Email);
        }
    }
}