using JetBrains.Annotations;
using Multithreading.Storage;
using Multithreading.Units;

namespace Multithreading.Kitchen;

public record Cup(FluidVolume Capacity) : LiquidContainer(Capacity)
{
    public static Cup Default => new(FluidVolume.FromFluidOunces(12));
}