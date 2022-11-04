namespace Application.Infrastructure;

public class AuthorRepository : IAuthorRepository
{
    private readonly GitInsightContext _context;

    public AuthorRepository(GitInsightContext context)
    {
        _context = context;
    }

    public (Response Response, int AuthorId) Create(AuthorCreateDTO user)
    {
        throw new NotImplementedException();
    }

    public Response Delete(int authorId, bool force = false)
    {
        throw new NotImplementedException();
    }

    public AuthorDTO? Find(int authorId)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyCollection<AuthorDTO> Read()
    {
        throw new NotImplementedException();
    }

    public Response Update(AuthorUpdateDTO author)
    {
        throw new NotImplementedException();
    }
}