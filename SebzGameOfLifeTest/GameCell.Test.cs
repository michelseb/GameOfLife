using SebzGameOfLife;

namespace SebzGameOfLifeTest;

public class GameCellTest
{
    [Fact]
    public void Should_be_alive_when_created_alive()
    {
        var sut = new GameCell(0, 0, true);
        Assert.True(sut.IsAlive);
    }
}