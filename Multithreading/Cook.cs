namespace Multithreading;

public class Cook
{
    public Cook(TimeSpan baconPreparationTime,
        TimeSpan baconCookingTime,
        TimeSpan eggPreparationTime,
        TimeSpan eggCookingTime,
        TimeSpan toastPreparationTime,
        TimeSpan juicePreparationTime,
        TimeSpan coffeePreparationTime, TimeSpan spreadApplicationTime)
    {
        BaconPreparationTime = baconPreparationTime;
        BaconCookingTime = baconCookingTime;
        _eggPreparationTime = eggPreparationTime;
        EggCookingTime = eggCookingTime;
        ToastPreparationTime = toastPreparationTime;
        SpreadApplicationTime = spreadApplicationTime;
        JuicePreparationTime = juicePreparationTime;
        CoffeePreparationTime = coffeePreparationTime;
    }

    public TimeSpan BaconPreparationTime { get; }
    public TimeSpan BaconCookingTime { get; }
    public TimeSpan ManyEggsPreparationTime(int eggCount) =>
        TimeSpan.FromTicks(_eggPreparationTime.Ticks * eggCount);
    public TimeSpan EggCookingTime { get; }
    public TimeSpan ToastPreparationTime { get; }
    public TimeSpan SpreadApplicationTime { get; }
    public TimeSpan JuicePreparationTime { get; }
    public TimeSpan CoffeePreparationTime { get; }
    
    private readonly TimeSpan _eggPreparationTime;

}
