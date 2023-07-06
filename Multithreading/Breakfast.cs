using Multithreading.Kitchen;
using Multithreading.Storage.Fridge;
using Multithreading.Storage.Pantry;
using Multithreading.Units;

namespace Multithreading;

internal class Breakfast
{
    public Breakfast(Coffee coffee, Juice juice, Egg[] egg, Bacon[] bacon, Toast[] toast)
    {
        Coffee = coffee;
        Juice = juice;
        Egg = egg;
        Bacon = bacon;
        Toast = toast;
    }

    internal Coffee Coffee { get; init; }
    internal Juice Juice { get; init; }
    internal Egg[] Egg { get; init; }
    internal Bacon[] Bacon { get; init; }
    internal Toast[] Toast { get; init; }
}