namespace Application.Core;

public interface IAuthorRepository
{
    (Response Response, int AuthorId) Create(AuthorCreateDTO user);
    AuthorDTO? Find(int authorId);
    IReadOnlyCollection<AuthorDTO> Read();
    Response Update(AuthorUpdateDTO author);
    Response Delete(int authorId, bool force = false);
}