namespace Application.Tests;

using System.IO.Compression;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Program;

public class UnitTest1
{
    String path;

    public UnitTest1(){
        if(!Directory.Exists("../../../../assignment-05")){
            ZipFile.ExtractToDirectory("../../../../assignment-05.zip", "../../../../");
        }
        path = "../../../../assignment-05";
    }   

    [Fact]
    public void TestCommitFrequencyMode()
    {
        // Arrange
        var excepted = new List<String>() {
            "3 11-10-2022",
            "2 07-10-2022",
            "3 06-10-2022",
            "2 25-09-2022",
            "2 21-10-2021",
            "3 15-10-2021",
            "2 04-10-2021",
            "1 03-10-2021",
            "1 02-10-2021",
            "1 24-09-2021",
            "2 10-10-2022"
        };

        // Act
        var actual = Program.CommitFrequencyMode(path);
    
        // Assert
        actual.Should().BeEquivalentTo(excepted);
    }

    [Fact]
    public void TestCommitAuthorMode()
    {
        // Arrange
        var expected = new Dictionary<String, Dictionary<String, int>>();
        var datecommits1 = new Dictionary<String, int>();
        var datecommits2 = new Dictionary<String, int>();
        var datecommits3 = new Dictionary<String, int>();
        var datecommits4 = new Dictionary<String, int>();
        var datecommits5 = new Dictionary<String, int>();
        datecommits1.Add("11-10-2022", 4);
        expected.Add("Laurits Brok", datecommits1);
        datecommits2.Add("07-10-2022", 2);
        expected.Add("mbjn", datecommits2);
        datecommits3.Add("07-10-2022", 2);
        expected.Add("HelgeCPH", datecommits3);
        datecommits4.Add("06-10-2022", 4);
        datecommits4.Add("25-09-2022", 2);
        datecommits4.Add("21-10-2021", 2);
        datecommits4.Add("04-10-2021", 2);
        datecommits4.Add("03-10-2021", 1);
        datecommits4.Add("02-10-2021", 1);
        datecommits4.Add("24-09-2021", 1);
        expected.Add("Rasmus Lystr??m", datecommits4);
        datecommits5.Add("15-10-2021", 4);
        expected.Add("GitHub Enterprise", datecommits5);

        // Act
        var actual = Program.CommitAuthorMode(path);
    
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

}