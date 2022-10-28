namespace Application;

using LibGit2Sharp;
using LibGit2Sharp.Core;

public class Commits {
    
    public static IEnumerable<String> getCommitsFrequency(){
        var repo = new Repository("/Users/lauritsbrok/Documents/Drev/ITU/Analysis, Design and Software Architecture/assignment-05");
        var commits = repo.Commits;
        foreach(Commit a in commits){
            yield return a.MessageShort;
        }
    }
}
