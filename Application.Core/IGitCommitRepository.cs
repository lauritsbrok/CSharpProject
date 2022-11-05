namespace Application.Core;

public interface IGitCommitRepository
{
    (Response Response, int CommitId) Create(GitCommitCreateDTO commit);
    GitCommitDTO? Find(int commitId);
    IReadOnlyCollection<GitCommitDTO> Read();
    Response Update(GitCommitUpdateDTO commit);
    Response Delete(int commitId, bool force = false);
}