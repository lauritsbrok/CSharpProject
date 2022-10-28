namespace Application;

using LibGit2Sharp;
using LibGit2Sharp.Core;

public class Commits {

    public static Dictionary<String, Dictionary<String, int>> getCommitsFrequency(Repository repo){
        var commits = repo.Commits;

        var commitsByNameAndDateAndCount = new Dictionary<String, Dictionary<String, int>>();

        foreach(Commit a in commits){
            var commitName = a.Committer.Name;
            var commitDate = a.Committer.When.Date.ToString().Replace(" 00.00.00", "").Replace(".", "-");

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
}