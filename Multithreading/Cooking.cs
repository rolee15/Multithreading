using JetBrains.Annotations;
using Multithreading.Kitchen;
using Multithreading.Storage.Fridge;
using Multithreading.Storage.Pantry;

namespace Multithreading;

internal class Cooking
{
    private readonly Cook _cook;
    private readonly IKitchenwareProvider _kitchenwareProvider;
    
    public Cooking(Cook cook, IKitchenwareProvider kitchenwareProvider)
    {
        _cook = cook;
        _kitchenwareProvider = kitchenwareProvider;
    }
    
    internal Breakfast MakeBreakfast()
    {
        var coffee = PourCoffee();
        Console.WriteLine("coffee is ready");

        var eggs = FryEggs(2);
        Console.WriteLine("eggs are ready");

        var bacon = FryBacon(3);
        Console.WriteLine("bacon is ready");

        var toasts = ToastBread(2);
        ApplyButter(toasts[0]);
        ApplyJam(toasts[1]);
        Console.WriteLine("toast is ready");

        var oj = PourOj();
        Console.WriteLine("oj is ready");
        Console.WriteLine("Breakfast is ready!");
        
        return new Breakfast(coffee, oj, eggs, bacon, toasts);
    }

    [Pure]
    private Juice PourOj()
    {
        var glass = _kitchenwareProvider.GetGlass();
        
        Console.WriteLine("Pouring orange juice");
        var juice = new Juice();
        glass.PourUntilFull(juice);
        return juice;
    }

    private void ApplyJam(Toast toast)
    {
        Console.WriteLine("Putting jam on the toast");
        var spreadingTime = _cook.SpreadApplicationTime;
        Task.Delay(spreadingTime).Wait();
        toast.Spread = Spread.Jam;
    }

    private void ApplyButter(Toast toast)
    {
        Console.WriteLine("Putting butter on the toast");
        var spreadingTime = _cook.SpreadApplicationTime;
        Task.Delay(spreadingTime).Wait();
        toast.Spread = Spread.Butter;
    }

    private Toast[] ToastBread(int slices)
    {
        var toaster = _kitchenwareProvider.GetToaster();

        var toasts = new Toast[slices];
        for (var slice = 0; slice < slices; slice++)
        {
            Console.WriteLine("Putting a slice of bread in the toaster");
            toasts[slice] = new Toast();
        }
        var toastPreparationTime = _cook.ToastPreparationTime;
        Task.Delay(toastPreparationTime).Wait();
        
        Console.WriteLine("Start toasting...");
        var toastCookingTime = toaster.ManyToastsCookingTime(slices);
        Task.Delay(toastCookingTime).Wait();
        Console.WriteLine("Remove toast from toaster");

        return toasts;
    }

    private Bacon[] FryBacon(int slices)
    {
        var pan = _kitchenwareProvider.GetPan();
        
        if (!pan.IsWarm)
        {
            Console.WriteLine("Warming the pan...");
            var panWarmingTime = pan.WarmingTime;
            Task.Delay(panWarmingTime).Wait();
            pan.IsWarm = true;
        }
        
        var bacon = new Bacon[slices];
        for (var slice = 0; slice < slices; slice++)
        {
            Console.WriteLine($"putting a slice of bacon in the pan");
            bacon[slice] = new Bacon();
        }
        
        var baconPreparationTime = _cook.BaconPreparationTime;
        Task.Delay(baconPreparationTime).Wait();
        
        Console.WriteLine("cooking first side of bacon...");
        var baconCookingTime = _cook.BaconCookingTime;
        Task.Delay(baconCookingTime).Wait();
        
        for (var slice = 0; slice < slices; slice++)
        {
            Console.WriteLine("flipping a slice of bacon");
        }
        
        Console.WriteLine("cooking the second side of bacon...");
        Task.Delay(baconCookingTime).Wait();
        Console.WriteLine("Put bacon on plate");

        return new Bacon[slices];
    }

    private Egg[] FryEggs(int howMany)
    {
        var pan = _kitchenwareProvider.GetPan();

        if (!pan.IsWarm)
        {
            Console.WriteLine("Warming the pan...");
            var panWarmingTime = pan.WarmingTime;
            Task.Delay(panWarmingTime).Wait();
            pan.IsWarm = true;
        }

        Console.WriteLine($"cracking {howMany} eggs");
        var crackingEggsTime = _cook.ManyEggsPreparationTime(howMany);
        Task.Delay(crackingEggsTime).Wait();
        
        Console.WriteLine("cooking the eggs ...");
        var eggCookingTime = _cook.EggCookingTime;
        Task.Delay(eggCookingTime).Wait();
        
        Console.WriteLine("Put eggs on plate");
        
        return new Egg[howMany];
    }

    private Coffee PourCoffee()
    {
        var cup = _kitchenwareProvider.GetCup();
        
        Console.WriteLine("Pouring coffee");
        var coffee = new Coffee();
        cup.PourUntilFull(coffee);
        return coffee;
    }
}