using Microsoft.AspNetCore.Mvc;

namespace GitInsightAPI;

[ApiController]
[Route("[controller]")]
public class CommitAuthorController : ControllerBase
{

    [HttpGet("{user}/{repo}")]
    public Dictionary<String, Dictionary<String, int>> GetCommitAuthor(string user, string repo)
    {
        GitInsight.cloneRepo(user, repo);
        var repoPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)+ "/" + repo + "/";
        return GitInsight.CommitAuthorMode(repoPath);
    }
}
