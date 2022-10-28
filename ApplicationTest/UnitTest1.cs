
namespace ApplicationTest;
using Application;

public class UnitTest1
{
    [Fact]
    public void TestName()
    {
        // Given
        var commits = new List<String>(){
            "1 2017-12-08",
            "1 2017-12-26"
        };

        // When
        var actualCommits = Commits.getCommitsFrequency();

        // Then
        Assert.Equal(actualCommits, commits);
    }
}