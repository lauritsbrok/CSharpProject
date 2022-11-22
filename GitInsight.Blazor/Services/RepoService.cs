public class RepoService : IRepoService
{
    private readonly HttpClient _httpClient;
    public RepoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    async Task<IEnumerable<string>> IRepoService.GetCommitFrequencyList(string username, string repoName)
    {
        return await _httpClient.GetFromJsonAsync<string[]>($"CommitFrequency/{username}/{repoName}");
    }

    Task<IEnumerable<string>> IRepoService.GetCommitAuthorList()
    {
        throw new NotImplementedException();
    }
}