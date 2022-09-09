namespace Assignment1.Tests;

public class IteratorsTests
{
    [Fact]
    public void Flatten_given_3_lists_returns_1_list()
    {
       var a1 = new List<int> { 1,2,3};
       var a2 = new List<int> { 4,5, 6, 7 };
       var a3 = new List<int> {8,9 };
        // Arrange
        List<List<int>> lists = new List<List<int>>();
        lists.Add(a1);
        lists.Add(a2);
        lists.Add(a3);

        // Act
        var flatten = Iterators.Flatten(lists);

        // Assert
        flatten.Should().BeEquivalentTo(new[] {1,2,3,4,5,6,7,8,9});
    }

    [Fact]
    public void Filter_using_modulo_as_predicate_returns_list_of_2_and_4()
    {
        int[] numbers = { 1, 2, 3, 4, 5,};

       /* public static bool isEven(int numb){
            if (numb % 2 = 0){
                return true;
            }
            else return false;
        }*/

        Iterators.Filter(numbers, isEven);

        Assert.Equal(new int[] {2, 4}, Iterators.Filter(numbers, isEven));
    }

    public static bool isEven(int numb){
            if (numb % 2 == 0){
                return true;
            }
            else return false;
    }


}