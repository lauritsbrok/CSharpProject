namespace Application.Core;
public interface IRepoRepository
{
    (Response Response, int RepoId) Create(RepoCreateDTO repo);
    RepoDTO? Find(int repoId);
    IReadOnlyCollection<RepoDTO> Read();
    Response Update(RepoDTO repo);
    Response Delete(int repoId, bool force = false);
}