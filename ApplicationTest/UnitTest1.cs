namespace Application.Tests;
using Application;

[TestClass]
public class UnitTest1
{
    [Fact]
    public void FrequencyTest()
    {
        // Given
        var path = "PathToGit";
        var expectedOutput = new List<String>(){
            "1 2017-12-08",
            "6 2017-12-26",
            "12 2018-01-01",
            "13 2018-01-02",
            "10 2018-01-14",
            "7 2018-01-17",
            "5 2018-01-18"
        };
        // When
        var actualOutput = Program.CommitFrequency(path);

        // Then
        expectedOutput.Should().BeEquivalentTo(actualOutput);
    }

    [Fact]
    public void AutherTest()
    {
        // Given
        var path = "PathToGit";
        var expectedOutput = new List<String>(){
        "Marie Beaumin",
            "1 2017-12-08",
            "6 2017-12-26",
            "12 2018-01-01",
            "13 2018-01-02",
            "10 2018-01-14",
            "7 2018-01-17",
            "5 2018-01-18"
        };

        // When
        var actualOutput = Program.CommitFrequency(path);

        // Then
        expectedOutput.Should().BeEquivalentTo(actualOutput);
    }
}