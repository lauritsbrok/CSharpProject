namespace Program;

public class Program{

    public static void Main(String[] args){


        /////////////////

        NPGSQL.doStuff(NPGSQL.CreateDataSource());
        return;
        /////////////////

        Console.WriteLine("Enter github repo path");
        var path = Console.ReadLine();
        Console.WriteLine("Choose desired info");
        Console.WriteLine("1) Commit Frequency Mode");
        Console.WriteLine("2) Commit Author Mode");
        int chosenMode = int.Parse(Console.ReadLine()!);
        switch (chosenMode) {
            case 1:
            var commitList = CommitFrequencyMode(path!);
            foreach (String commit in commitList) {
                Console.WriteLine(commit);
            }
            break;

            case 2:
            var dict = CommitAuthorMode(path!);

            foreach(var a in dict) {
                Console.WriteLine(a.Key);
                foreach(var b in a.Value){
                    Console.WriteLine("      " + b.Value.ToString() + " " + b.Key);
                }
                Console.WriteLine();
            }
            break;
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
                    var commitDate = commit.Author.When.Date.ToString().Replace(" 00.00.00", "").Replace(".", "-");
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
