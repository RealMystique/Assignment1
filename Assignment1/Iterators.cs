namespace Assignment1;

public static class Iterators
{
    public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items){
        Console.WriteLine("Hej");
        foreach(var IEnumerable in items){
            foreach(var item in IEnumerable){
                yield return item;
            }
        }
    }

    public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate) => throw new NotImplementedException();


    public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate) {
        foreach (var item in items)
        {
            if (predicate){
                yield return item;
            }
        }
    }
}