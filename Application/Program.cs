using LibGit2Sharp;

namespace Application;

public class TestClass
{
    public static void Main(string[] args)
    {
        var repo = new Repository("/Users/lauritsbrok/Documents/Drev/ITU/Analysis, Design and Software Architecture/assignment-05");
        var dict = Commits.getCommitsFrequency(repo);

        foreach(var a in dict)
        {
            Console.WriteLine(a.Key);
            foreach(var b in a.Value){
                Console.WriteLine("      " + b.Value.ToString() + " " + b.Key);
            }
            Console.WriteLine();

        }

    }

}