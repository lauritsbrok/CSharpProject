namespace Application.Tests;
using Program;

public class UnitTest1
{
    [Fact]
    public void TestCommitFrequencyMode()
    {
        // Arrange
        var path = "GITHUBPATH";
        var excepted = new List<String>() {
            "1 2017-12-08",
            "6 2017-12-26",
            "12 2018-01-01",
            "13 2018-01-02",
            "10 2018-01-14",
            "7 2018-01-17",
            "5 2018-01-18"
        };

        // Act
        var actual = Program.CommitFrequencyMode(path);
    
        // Assert
        excepted.Should().BeEquivalentTo(actual);
    }

    [Fact]
    public void TestCommitAuthorMode()
    {
        // Arrange
        var path = "GITHUBPATH";
        var excepted = new List<String>() {
            "Marie Beaumin",
                "1 2017-12-08",
                "6 2017-12-26",
                "12 2018-01-01",
                "13 2018-01-02",
                "10 2018-01-14",
                "7 2018-01-17",
                "5 2018-01-18",
            "Maxime Kauta",
                "5 2017-12-06",
                "3 2017-12-07",
                "1 2018-01-01",
                "10 2018-01-02",
                "21 2018-01-03",
                "1 2018-01-04",
                "5 2018-01-05" 
        };

        // Act
        var actual = Program.CommitAuthorMode(path);
    
        // Assert
        excepted.Should().BeEquivalentTo(actual);
    }
}