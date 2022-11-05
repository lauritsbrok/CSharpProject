namespace Application.Core;
public interface IGitRepoRepository
{
    (Response Response, int RepoId) Create(GitRepoCreateDTO repo);
    GitRepoDTO? Find(int repoId);
    IReadOnlyCollection<GitRepoDTO> Read();
    Response Update(GitRepoDTO repo);
    Response Delete(int repoId, bool force = false);
}