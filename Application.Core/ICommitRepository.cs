namespace Application.Core;

public interface ICommitRepository
{
    (Response Response, int CommitId) Create(CommitCreateDTO commit);
    CommitDTO? Find(int commitId);
    IReadOnlyCollection<CommitDTO> Read();
    Response Update(CommitUpdateDTO commit);
    Response Delete(int commitId, bool force = false);
}