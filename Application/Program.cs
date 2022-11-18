using System.Globalization;
using Application.Core;
using Microsoft.EntityFrameworkCore;

namespace Program;

public class Program{

    public static void Main(String[] args){
        var factory = new GitInsightContextFactory();
        using var context = factory.CreateDbContext(args);
        context.Database.Migrate();
        var repoRepository = new GitRepoRepository(context);
        var commitRepository = new GitCommitRepository(context);
        var authorRepository = new GitAuthorRepository(context);
        Console.WriteLine("Enter github repo path");
        var repoUrl = Console.ReadLine();
        var (response, id) = repoRepository.Create(new GitRepoCreateDTO(repoUrl, null, null));
        
        if(Repository.IsValid(repoUrl)) {
            using (var repo = new Repository(repoUrl))
            {
                HashSet<GitAuthorDTO> authors = new HashSet<GitAuthorDTO>();
                HashSet<GitCommitDTO> commits = new HashSet<GitCommitDTO>();
                foreach (var commit in repo.Commits) {
                    if(repoUrl is not null) {
                        commitRepository.Create(new GitCommitCreateDTO(commit.Id.ToString(), commit.MessageShort, new GitAuthorDTO(commit.Author.Name, commit.Author.Email), repoUrl));
                    }
                    var (res, autid) = authorRepository.Create(new GitAuthorCreateDTO(commit.Author.Name, commit.Author.Email));
                    commits.Add(new GitCommitDTO(commit.Id.ToString(), commit.MessageShort, commit.Author.Name, repoUrl));
                    authors.Add(new GitAuthorDTO(commit.Author.Name, commit.Author.Email));
                }
                repoRepository.Update(new GitRepoDTO(id, repoUrl, commits, authors));
            }
        }
    }
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
}
