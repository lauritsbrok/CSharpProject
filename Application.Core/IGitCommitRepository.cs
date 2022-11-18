namespace Application.Core;

public interface IGitCommitRepository
{
    (Response Response, int Id) Create(GitCommitCreateDTO commit);
    GitCommitDTO? Find(string commitId);
    IReadOnlyCollection<GitCommitDTO> Read();
    Response Delete(string commitId, bool force = false);
}