namespace Application;

public class TestClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine(args[0]);
        var commits = Commits.getCommitsFrequency();
        foreach(String a in commits){
            Console.WriteLine(a);
        }

    }

}