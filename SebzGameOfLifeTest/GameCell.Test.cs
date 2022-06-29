using SebzGameOfLife;

namespace SebzGameOfLifeTest;

public class GameCellTest
{
    private void CreateNeighboursFor(GameCell cell, int amount, bool isAlive = true)
    {
        for (var i = 0; i < amount; i++)
        {
            cell.Neighbours.Add(new GameCell(0, 0, isAlive));
        }
    }

    [Fact]
    public void Should_be_alive_when_created_alive()
    {
        var sut = new GameCell(0, 0, true);
        Assert.True(sut.IsAlive);
    }

    [Fact]
    public void Should_be_alive1_when_created_alive()
    {
        var sut = new GameCell(1, 1, true);
        Assert.True(sut.IsAlive);
    }

    [Fact]
    public void Should_be_dead_when_created_dead()
    {
        var sut = new GameCell(0, 0, false);
        Assert.False(sut.IsAlive);
    }

    [Theory]
    [InlineData(true, 2)]
    [InlineData(true, 3)]
    [InlineData(false, 3)]
    public void With_Given_IsAlive_State_And_Given_Amount_Of_Neighbours_Alive_IsAliveNext_IsTrue(bool isAlive, int aliveNeighboursAmount)
    {
        var sut = new GameCell(2, 2, isAlive);

        CreateNeighboursFor(sut, aliveNeighboursAmount);

        sut.CalculateNextState();

        Assert.True(sut.IsAliveNext);
    }

    [Theory]
    [InlineData(true, 0)]
    [InlineData(true, 1)]
    [InlineData(true, 4)]
    [InlineData(true, 5)]
    [InlineData(true, 6)]
    [InlineData(true, 7)]
    [InlineData(true, 8)]
    [InlineData(false, 0)]
    [InlineData(false, 1)]
    [InlineData(false, 2)]
    [InlineData(false, 4)]
    [InlineData(false, 5)]
    [InlineData(false, 6)]
    [InlineData(false, 7)]
    [InlineData(false, 8)]
    public void With_Given_IsAlive_State_And_Given_Amount_Of_Neighbours_Alive_IsAliveNext_IsFalse(bool isAlive, int aliveNeighboursAmount)
    {
        var sut = new GameCell(2, 2, isAlive);

        CreateNeighboursFor(sut, aliveNeighboursAmount);

        sut.CalculateNextState();

        Assert.False(sut.IsAliveNext);
    }
}