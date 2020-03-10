# RandomEnumerableExtensions

[![NuGet version (SoftCircuits.RandomEnumerableExtensions)](https://img.shields.io/nuget/v/SoftCircuits.RandomEnumerableExtensions.svg?style=flat-square)](https://www.nuget.org/packages/SoftCircuits.RandomEnumerableExtensions/)

```
Install-Package SoftCircuits.RandomEnumerableExtensions
```

## Overview

The RandomEnumerableExtensions class library defines `Random()` and `Shuffle()` methods. The methods are implemented as extension methods and so they are available as methods on any collection that implements `IEnumerable<T>` when the library is referenced and visible (via `using` statement).

The `Random()` method returns one item randomly chosen from the collection. The `Shuffle()` method reorders the collection . If the collection implements `IList<T>`, the items are shuffled in place. Otherwise, the collection is copied and shuffled.

Both the `Random` and `Shuffle` methods accept a parameter of type `System.Random`. If this parameter is not supplied, both functions will create their own. However, allocating your own instance of `System.Random` and then passing it to these functions may provide better performance and possibly a little more randomness.

## Examples

The code below demonstrates the random extension methods. It starts by creating a list with sequential integers and displays that list. Next, it prints randomly chosen items from the list. And, finally, it shuffles the entire list and prints the shuffled list.

```cs
static void Main(string[] args)
{
    // Create ordered list
    List<int> list = new List<int>();
    for (int i = 1; i <= 10; i++)
        list.Add(i);

    // Create psuedo-random number generator
    Random rand = new Random();

    // Print original list
    Console.WriteLine("Original List:");
    Console.WriteLine(String.Join("\r\n", list));
    Console.WriteLine();

    // Print random items from the list
    Console.WriteLine("Random Elements:");
    Console.WriteLine(list.Random(rand));
    Console.WriteLine(list.Random(rand));
    Console.WriteLine(list.Random(rand));
    Console.WriteLine(list.Random(rand));
    Console.WriteLine(list.Random(rand));
    Console.WriteLine();

    // Shuffle and print list
    list.Shuffle(rand);
    Console.WriteLine("Shuffled List:");
    Console.WriteLine(String.Join("\r\n", list));
    Console.WriteLine();

    Console.ReadKey();
}
```
