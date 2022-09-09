namespace Assignment1.Tests;

public class IteratorsTests
{
    [Fact]
    public void Filter_using_modulo_as_predicate_returns_list_of_2_and_4()
    {
        int[] numbers = { 1, 2, 3, 4, 5};
        public static bool isEven(int numb){
            if (numb % 2 = 0){
                return true;
            }
            else retun false;
        }

        Iterators.Filter(numbers, isEven);

        Assert.Equal({2, 4}, Iterators.Filter(numbers, isEven););
    }


}