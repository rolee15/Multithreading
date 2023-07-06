using Multithreading.Storage;
using Multithreading.Units;

namespace Multithreading.Kitchen;

public interface ILiquidContainer
{
    FluidVolume Capacity { get; init; }
    FluidVolume CurrentVolume { get; }
    bool IsFull { get; }
    bool IsEmpty { get; }
    void PourUntilFull(IDrinkable drinkable);
}