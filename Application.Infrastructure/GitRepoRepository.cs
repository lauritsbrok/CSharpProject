public class GitRepoRepository : IGitRepoRepository
{
    private readonly GitInsightContext _context;

    public GitRepoRepository(GitInsightContext context)
    {
        _context = context;
    }

    public (Response Response, int RepoId) Create(GitRepoCreateDTO repo)
    {
        var entity = _context.Repos.FirstOrDefault(r => r.Url == repo.Url);
        Response response;
        if(entity is null) {
            entity = new GitRepo(repo.Url);
            try {
                _context.Repos.Add(entity);
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

    public Response Delete(int repoId, bool force = false)
    {
        var entity = _context.Repos.FirstOrDefault(r => r.Id == repoId);
        Response response;
        if(entity != null) {
            var repoIsEmpty = entity.Authors.Count == 0 && entity.Commits.Count == 0;
            if(force || repoIsEmpty) {
                try {
                _context.Repos.Remove(entity);
                _context.SaveChanges();
                response = Response.Deleted;
            } catch (Microsoft.EntityFrameworkCore.DbUpdateException) {
                response = Response.Conflict;
            }
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
                     let commits = r.Commits.Select(c => c.Id).ToHashSet()
                     let authors = r.Authors.Select(a => a.Name).ToHashSet()
                     select new GitRepoDTO(r.Id, r.Url, commits, authors);
        return Repo.FirstOrDefault();
    }

    public IReadOnlyCollection<GitRepoDTO> Read()
    {
        var Repos = 
            from r in _context.Repos
            orderby r.Id
            let commits = r.Commits.Select(c => c.Id).ToHashSet()
            let authors = r.Authors.Select(a => a.Name).ToHashSet()
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
            entity.Authors = UpdateAuthor(repo.Authors).ToHashSet();
            entity.Commits = UpdateCommits(repo.Commits).ToHashSet();

            _context.SaveChangesAsync();

        return Response.Updated;
        
    }

    private IEnumerable<GitCommit> UpdateCommits(IEnumerable<string> commitIds)
    {
        var existing = _context.Commits.Where(c => commitIds.Contains(c.Id)).ToDictionary(c => c.Id);
        foreach (var commit in commitIds)
        {
            existing.TryGetValue(commit, out var foundCommit);

            yield return foundCommit!;
        }
    }

    private IEnumerable<GitAuthor> UpdateAuthor(IEnumerable<string> authorNames)
    {
        var existing = _context.Authors.Where(a => authorNames.Contains(a.Name)).ToDictionary(a => a.Name);
        foreach (var author in authorNames)
        {
            existing.TryGetValue(author, out var foundAuthor);

            yield return foundAuthor!;
        }
    }
}