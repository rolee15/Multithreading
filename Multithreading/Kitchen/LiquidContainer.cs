using JetBrains.Annotations;
using Multithreading.Storage;
using Multithreading.Units;

namespace Multithreading.Kitchen;

public abstract record LiquidContainer(FluidVolume Capacity) : ILiquidContainer
{
    public FluidVolume CurrentVolume { get; private set; } = FluidVolume.Zero;
    public bool IsFull { get; private set; }
    public bool IsEmpty { get; private set; } = true;
    private IDrinkable? Contents { get; set; }

    [PublicAPI]
    public void PourUntilFull(IDrinkable drinkable)
    {
        var volumeLeft = Capacity - CurrentVolume;
        Pour(drinkable, volumeLeft);
    }

    [PublicAPI]
    public void Pour(IDrinkable drinkable, FluidVolume volume)
    {
        if (IsFull)
        {
            throw new InvalidOperationException("The cup is already full.");
        }

        if (!IsEmpty && drinkable.GetType() != Contents?.GetType())
        {
            throw new InvalidOperationException("The cup already contains a different drink.");
        }
        
        if (volume > Capacity - CurrentVolume)
        {
            throw new InvalidOperationException("The cup is too small.");
        }

        Contents = drinkable;
        CurrentVolume += volume;
        IsFull = CurrentVolume == Capacity;
        IsEmpty = CurrentVolume == FluidVolume.Zero;
    }
    
    [PublicAPI]
    public void DrinkAll()
    {
        Drink(CurrentVolume);
    }
    
    [PublicAPI]
    public void Drink(FluidVolume volume)
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("The cup is empty.");
        }

        if (volume > CurrentVolume)
        {
            throw new InvalidOperationException("Not enough fluid to drink.");
        }

        CurrentVolume -= volume;
        IsFull = CurrentVolume == Capacity;
        IsEmpty = CurrentVolume == FluidVolume.Zero;
        if (IsEmpty) Contents = null;
    }
}