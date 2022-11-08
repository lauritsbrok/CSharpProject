using Microsoft.AspNetCore.Mvc;

namespace GitInsightAPI;

[ApiController]
[Route("[controller]")]
public class CommitFrequencyController : ControllerBase
{

    [HttpGet("{user}/{repo}")]
    public IEnumerable<String> GetCommitFrequency(string user, string repo)
    {
        GitInsight.cloneRepo(user, repo);
        var repoPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)+ "/" + repo + "/";
        return GitInsight.CommitFrequencyMode(repoPath);
    }
}
