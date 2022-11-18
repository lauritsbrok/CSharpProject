namespace Application.Infrastructure;

public class GitAuthorRepository : IGitAuthorRepository
{
    private readonly GitInsightContext _context;

    public GitAuthorRepository(GitInsightContext context)
    {
        _context = context;
    }

    public (Response Response, int AuthorId) Create(GitAuthorCreateDTO author)
    {
        var entity = _context.Authors.FirstOrDefault(a => a.Name == author.Name);
        Response response;
        if(entity is null) {
            entity = new GitAuthor(author.Name, author.Email);
            _context.Authors.Add(entity);
            _context.SaveChanges();
            response = Response.Created;
        } else {
            response = Response.Conflict;
        }
        return (response, entity!.Id);
    }

    public Response Delete(int authorId, bool force = false)
    {
        var entity = _context.Authors.FirstOrDefault(u => u.Id == authorId);
        Response response;
        if(entity != null && (entity.commits.Count == 0 || force)) {
            _context.Authors.Remove(entity);
            _context.SaveChanges();
            response = Response.Deleted;

        } else {
            response = Response.Conflict;
        }

        return response;
    }

    public GitAuthorDTO? Find(int authorId)
    {
        var Author = from u in _context.Authors
                     where u.Id == authorId
                     select new GitAuthorDTO(u.Name, u.Email);
        return Author.FirstOrDefault();
    }

    public IReadOnlyCollection<GitAuthorDTO> Read()
    {
        var Authors = 
            from u in _context.Authors
            orderby u.Name
            select new GitAuthorDTO(u.Name, u.Email);

        return Authors.ToArray();
    }

    public Response Update(GitAuthorUpdateDTO author)
    {
        var entity = _context.Authors.FirstOrDefault(u => u.Id == author.Id);
        Response response;
        if(entity == null) {
            response = Response.NotFound;
        } else {
            entity.Name = author.Name;
            entity.Email = author.Email;
            try
            {
                _context.SaveChanges();
                response = Response.Updated;
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                response = Response.Conflict;
            }
        }
        return response;
    }
}