namespace Assignment1.Tests;

public class IteratorsTests
{
    [Fact]
    public void Flatten_given_3_lists_returns_1_list()
    {
        // Arrange
        int[] list = { int[] {1,2,3}, int[] {4,5,6}, int[] {7,8,9} };

        // Act
        var flatten = Iterators.Flatten(list)

        // Assert
        flatten.Should().BeEquivalentTo(new[] {1,2,3,4,5,6,7,8,9});
    }
}