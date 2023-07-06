using Multithreading.Storage;
using Multithreading.Units;

namespace Multithreading.Kitchen;

public record Glass(FluidVolume Capacity) : LiquidContainer(Capacity)
{
    public static Glass Default => new(FluidVolume.FromFluidOunces(14));
}