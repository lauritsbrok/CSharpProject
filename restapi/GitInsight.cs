using System.Globalization;
using LibGit2Sharp;

namespace GitInsightAPI;

/*

How to start API:
Terminal: dotnet run

How to use API through browser:
https://localhost:7092/CommitFrequency/lauritsbrok/assignment-05 (or use any other repo [usernameORgroupname/repository-name])
https://localhost:7092/CommitAuthor/lauritsbrok/assignment-05 (or use any other repo [usernameORgroupname/repository-name])

How to use API via terminal:
1.  Open a new terminal and run:
    httprepl https://localhost:7092
    You might need to run the following if you get errors:
    export PATH="$PATH:/Users/lauritsbrok/.dotnet/tools"
    dotnet dev-certs https --trust

2.  Type 'ls' to show API's
3.  Type 'cd CommitAuthor' or 'cd CommitFrequency' to navigate to API
4.  Type 'get lauritsbrok/assignment-05' (or use any other repo [usernameORgroupname/repository-name])

*/

public class GitInsight{

    public static IEnumerable<String> CommitFrequencyMode(String path){
        if(Repository.IsValid(path)){
            var commitDict = new Dictionary<String, int>();
            var listCommit = new List<String>();
            using (var repo = new Repository(path))
                {
                var commits = repo.Branches.SelectMany(x => x.Commits)
                    .GroupBy(x => x.Sha)
                    .Select(x => x.First())
                    .ToArray();
                foreach (var commit in commits) {
                    var commitDate = commit.Author.When.Date.ToString("d", new CultureInfo("da-DK"));
                    commitDate = commitDate.Replace(".", "-");
                    if(commitDict.ContainsKey(commitDate)) {
                        commitDict[commitDate] += 1;
                    } else {
                        commitDict.Add(commitDate, 1);
                    }
                }
                listCommit = commitDict.Select(pair => new String(pair.Value + " " + pair.Key)).ToList();
            }
            return listCommit;
        }
        throw new ArgumentException();
    }

    public static Dictionary<String, Dictionary<String, int>> CommitAuthorMode(String path){
        var repo = new Repository(path);
        var commits = repo.Commits;
        Console.WriteLine(repo.Network.Remotes.First().Url);

        var commitsByNameAndDateAndCount = new Dictionary<String, Dictionary<String, int>>();

        foreach(Commit a in commits){
            var commitName = a.Committer.Name;
            var commitDate = a.Author.When.Date.ToString("d", new CultureInfo("da-DK"));
            commitDate = commitDate.Replace(".", "-");

            Dictionary<String, int> currentDict;
            if(!commitsByNameAndDateAndCount.TryGetValue(commitName, out currentDict)){
                var dict = new Dictionary<String, int>();
                dict.Add(commitDate, 1);
                commitsByNameAndDateAndCount.Add(commitName, dict);
            }

            int count;
            commitsByNameAndDateAndCount[commitName].TryGetValue(commitDate, out count);
            commitsByNameAndDateAndCount[commitName][commitDate] = count + 1;
        }
        return commitsByNameAndDateAndCount;
    }

    public static void cloneRepo(string user, string repo){
        var repoPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)+ "/" + repo + "/";
        if(!Directory.Exists(repoPath)){
            Repository.Clone("https://github.com/" + user + "/" + repo + ".git", repoPath);
        } else {
            Repository repository = new Repository(repoPath);

            PullOptions pullOptions = new PullOptions()
            {
                MergeOptions = new MergeOptions()
                {
                    FastForwardStrategy = FastForwardStrategy.Default
                }
            };
            var signature = new Signature("GitInsight", "nomail@gitinsight.com", new DateTimeOffset(DateTime.Now));
            Commands.Pull(repository, signature, pullOptions);    
        }
    }
}
