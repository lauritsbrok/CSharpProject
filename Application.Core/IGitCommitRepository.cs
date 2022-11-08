namespace Application.Core;

public interface IGitCommitRepository
{
    (Response Response, string commitId) Create(GitCommitCreateDTO commit);
    GitCommitDTO? Find(string commitId);
    IReadOnlyCollection<GitCommitDTO> Read();
    Response Update(GitCommitUpdateDTO commit);
    Response Delete(string commitId, bool force = false);
}