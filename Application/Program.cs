namespace Program;

public class Program{

    public static void Main(String[] args){
        Console.WriteLine("Enter github repo path");
        var path = Console.ReadLine();
        Console.WriteLine("Choose desired info");
        Console.WriteLine("1) Commit Frequency Mode");
        Console.WriteLine("2) Commit Frequency Mode");
        int chosenMode = int.Parse(Console.ReadLine()!);
        switch (chosenMode) {
            case 1:
            var commitList = CommitFrequencyMode(path!);
            foreach (String commit in commitList) {
                Console.WriteLine(commit);
            }
            break;
            case 2:
            CommitAuthorMode(path!);
            break;
        }
    }

    public static IEnumerable<String> CommitFrequencyMode(String path){
        if(Repository.IsValid(path)){
            var commitDict = new Dictionary<String, int>();
            var listCommit = new List<String>();
            using (var repo = new Repository(path))
                {
                Console.WriteLine(Repository.IsValid(path));
                var commits = repo.Branches.SelectMany(x => x.Commits)
                    .GroupBy(x => x.Sha)
                    .Select(x => x.First())
                    .ToArray();
                foreach (var commit in commits) {
                    var commitDate = commit.Author.When.Date.ToString().Replace(" 00:00:00", "");
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

    public static IEnumerable<String> CommitAuthorMode(String path){
        if(Repository.IsValid(path)){
            using (var repo = new Repository(path))
                {
                Console.WriteLine(Repository.IsValid(path));
                var commits = repo.Branches.SelectMany(x => x.Commits)
                    .GroupBy(x => x.Sha)
                    .Select(x => x.First())
                    .ToArray();;
                foreach (var commit in commits) {
                    var commitName = commit;
                    var commitDate = commit.Author.When;
                    var commitAuthor = commit.Author.Name;
                    Console.WriteLine(commit + " " + commit.Author.When + " " + commit.Author.Name);
                }
            }
            return new List<String>();
        }
        throw new ArgumentException();
    }
}
