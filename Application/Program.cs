namespace Program;

public class Program{

    public static void Main(String[] args){
        Console.WriteLine("Start");
        CommitFrequencyMode(@"C:\Users\chris\Desktop\IT-Universitet\Semester 3\Analysis, Design and Software Architecture\assignment-01");
        Console.WriteLine("Done");
        // Console.WriteLine("Enter github repo path");
        // var path = Console.ReadLine();
        // Console.WriteLine("Choose desired info");
        // Console.WriteLine("1) Commit Frequency Mode");
        // Console.WriteLine("2) Commit Frequency Mode");
        // int chosenMode = Console.Read();
        // switch (chosenMode) {
        //     case 1:
        //     CommitFrequencyMode(@"C:\Users\chris\Desktop\IT-Universitet\Semester 3\Analysis, Design and Software Architecture\assignment-01");
        //     break;
        //     case 2:
        //     CommitAuthorMode(path);
        //     break;
        // }
    }

    public static IEnumerable<Commit> CommitFrequencyMode(String path){
        using (var repo = new Repository(path))
            {
            Console.WriteLine(Repository.IsValid(path));
            var commits = repo.Branches.SelectMany(x => x.Commits)
                .GroupBy(x => x.Sha)
                .Select(x => x.First())
                .ToArray();;
            foreach (var commit in commits) {
            Console.WriteLine(commit + " " + commit.Author.When + " " + commit.Author.Name);
            }
        }
        return new List<Commit>();
    }

    public static IEnumerable<String> CommitAuthorMode(String path){
        throw new NotImplementedException();
    }
}
