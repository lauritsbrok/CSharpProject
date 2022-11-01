namespace GildedRose.Tests;

public class ProgramTests
{   
    Program program = new Program();
    public ProgramTests(){
         program.Items = new List<Item> {
                new Generic { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new AgedBrie { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Sulfuras { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new BackstagePass { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
                new Conjured { Name = "Conjured Item", SellIn = 10, Quality = 30 }
         };
    }

    [Fact]
    public void TestUpdateQualityForGenericSellIn5()
    {   
        var testItem = new Item { Name = "+5 Dexterity Vest", SellIn = 5, Quality = 15 };

        for (var i = 0; i < 5; i++) {
            program.UpdateQuality();
        }

        Assert.Equal(
            testItem.Name + testItem.SellIn + testItem.Quality,
            program.Items[0].Name + program.Items[0].SellIn + program.Items[0].Quality
        );
    }

    [Fact]
    public void TestUpdateQualityForGenericSellIn5x()
    {   
        var testItem = new Item { Name = "+5 Dexterity Vest", SellIn = 5, Quality = 15 };

        for (var i = 0; i < 5; i++) {
            program.UpdateQuality();
        }

        Assert.Equal(
            testItem.Name + testItem.SellIn + testItem.Quality,
            program.Items[0].Name + program.Items[0].SellIn + program.Items[0].Quality
        );
    }

    [Fact]
    public void TestUpdateQualityForGenericSellIn15()
    {   
        var testItem = new Item { Name = "+5 Dexterity Vest", SellIn = -5, Quality = 0 };

        for (var i = 0; i < 15; i++) {
            program.UpdateQuality();
        }

        Assert.Equal(
            testItem.Name + testItem.SellIn + testItem.Quality,
            program.Items[0].Name + program.Items[0].SellIn + program.Items[0].Quality
        );
    }

    [Fact]
    public void TestUpdateQualityForGenericSellIn12()
    {   
        var testItem = new Item { Name = "+5 Dexterity Vest", SellIn = -2, Quality = 6 };

        for (var i = 0; i < 12; i++) {
            program.UpdateQuality();
        }

        Assert.Equal(
            testItem.Name + testItem.SellIn + testItem.Quality,
            program.Items[0].Name + program.Items[0].SellIn + program.Items[0].Quality
        );
    }

    [Fact]
    public void TestUpdateQualityForGenericSellIn30()
    {   
        var testItem = new Item { Name = "+5 Dexterity Vest", SellIn = -20, Quality = 0 };

        for (var i = 0; i < 30; i++) {
            program.UpdateQuality();
        }

        Assert.Equal(
            testItem.Name + testItem.SellIn + testItem.Quality,
            program.Items[0].Name + program.Items[0].SellIn + program.Items[0].Quality
        );
    }

    [Fact]
    public void TestUpdateQualityForConjuredSellIn5()
    {   
        var testItem = new Item { Name = "Conjured Item", SellIn = 5, Quality = 20 };

        for (var i = 0; i < 5; i++) {
            program.UpdateQuality();
        }

        Assert.Equal(
            testItem.Name + testItem.SellIn + testItem.Quality,
            program.Items[4].Name + program.Items[4].SellIn + program.Items[4].Quality
        );
    }

    [Fact]
    public void TestUpdateQualityForConjuredSellIn12()
    {   
        var testItem = new Item { Name = "Conjured Item", SellIn = -2, Quality = 2 };

        for (var i = 0; i < 12; i++) {
            program.UpdateQuality();
        }

        Assert.Equal(
            testItem.Name + testItem.SellIn + testItem.Quality,
            program.Items[4].Name + program.Items[4].SellIn + program.Items[4].Quality
        );
    }

    [Fact]
    public void TestUpdateQualityForConjuredSellIn20()
    {   
        var testItem = new Item { Name = "Conjured Item", SellIn = -10, Quality = 0 };

        for (var i = 0; i < 20; i++) {
            program.UpdateQuality();
        }

        Assert.Equal(
            testItem.Name + testItem.SellIn + testItem.Quality,
            program.Items[4].Name + program.Items[4].SellIn + program.Items[4].Quality
        );
    }

    [Fact]
    public void TestUpdateQualityForBrie()
    {   
        var testItem = new Item { Name = "Aged Brie", SellIn = -3, Quality = 8 };

        for (var i = 0; i < 5; i++) {
            program.UpdateQuality();
        }

        Assert.Equal(
            testItem.Name + testItem.SellIn + testItem.Quality,
            program.Items[1].Name + program.Items[1].SellIn + program.Items[1].Quality
        );
    }

    [Fact]
    public void TestUpdateQualityForBrieSellIn1()
    {   
        var testItem = new Item { Name = "Aged Brie", SellIn = 1, Quality = 1 };

        for (var i = 0; i < 1; i++) {
            program.UpdateQuality();
        }

        Assert.Equal(
            testItem.Name + testItem.SellIn + testItem.Quality,
            program.Items[1].Name + program.Items[1].SellIn + program.Items[1].Quality
        );
    }

    [Fact]
    public void TestUpdateQualityForSulfuras()
    {   
        var testItem = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };

        for (var i = 0; i < 5; i++) {
            program.UpdateQuality();
        }

        Assert.Equal(
            testItem.Name + testItem.SellIn + testItem.Quality,
            program.Items[2].Name + program.Items[2].SellIn + program.Items[2].Quality
        );
    }

    [Fact]
    public void TestUpdateQualityForBackstagePassesWhenSellIn11()
    {   
        var testItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 24 };

        for (var i = 0; i < 4; i++) {
            program.UpdateQuality();
        }

        Assert.Equal(
            testItem.Name + testItem.SellIn + testItem.Quality,
            program.Items[3].Name + program.Items[3].SellIn + program.Items[3].Quality
        );
    }

    [Fact]
    public void TestUpdateQualityForBackstagePassesWhenSellIn6()
    {   
        var testItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 33 };

        for (var i = 0; i < 9; i++) {
            program.UpdateQuality();
        }

        Assert.Equal(
            testItem.Name + testItem.SellIn + testItem.Quality,
            program.Items[3].Name + program.Items[3].SellIn + program.Items[3].Quality
        );
    }

    [Fact]
    public void TestUpdateQualityForBackstagePassesWhenSellIn1()
    {   
        var testItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 47 };

        for (var i = 0; i < 14; i++) {
            program.UpdateQuality();
        }

        Assert.Equal(
            testItem.Name + testItem.SellIn + testItem.Quality,
            program.Items[3].Name + program.Items[3].SellIn + program.Items[3].Quality
        );
    }

    [Fact]
    public void TestUpdateQualityForBackstagePassesWhenSellIn0()
    {   
        var testItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 50 };

        for (var i = 0; i < 15; i++) {
            program.UpdateQuality();
        }

        Assert.Equal(
            testItem.Name + testItem.SellIn + testItem.Quality,
            program.Items[3].Name + program.Items[3].SellIn + program.Items[3].Quality
        );
    }

    [Fact]
    public void TestUpdateQualityForBackstagePassesWhenSellInMinus1()
    {   
        var testItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 0 };

        for (var i = 0; i < 16; i++) {
            program.UpdateQuality();
        }

        Assert.Equal(
            testItem.Name + testItem.SellIn + testItem.Quality,
            program.Items[3].Name + program.Items[3].SellIn + program.Items[3].Quality
        );
    }

    [Fact]
    public async Task AfterExecutionConsoleOutputShouldBeCorrect()  {

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        Program.Main(new string[0]);

        string text = stringWriter.GetStringBuilder().ToString();

        await File.WriteAllTextAsync("actual.txt", text);

        var act = File.ReadAllBytes("actual.txt");
        var exp = File.ReadAllBytes("../../../expected.txt");

        act.Should().BeEquivalentTo(exp);
    }
}