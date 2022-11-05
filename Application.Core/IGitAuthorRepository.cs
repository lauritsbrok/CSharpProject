namespace Application.Core;

public interface IGitAuthorRepository
{
    (Response Response, int AuthorId) Create(GitAuthorCreateDTO user);
    GitAuthorDTO? Find(int authorId);
    IReadOnlyCollection<GitAuthorDTO> Read();
    Response Update(GitAuthorUpdateDTO author);
    Response Delete(int authorId, bool force = false);
}