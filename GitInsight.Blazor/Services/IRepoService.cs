public interface IRepoService
{
    Task<IEnumerable<string>>? GetCommitFrequencyList(string username, string repoName);

    Task<IEnumerable<string>>? GetCommitAuthorList();
}