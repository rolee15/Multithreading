using Multithreading;
using Multithreading.Kitchen;

var cook = new Cook(
    baconPreparationTime: TimeSpan.FromSeconds(20),
    baconCookingTime: TimeSpan.FromMinutes(5),
    eggPreparationTime: TimeSpan.FromSeconds(10),
    eggCookingTime: TimeSpan.FromMinutes(5),
    toastPreparationTime: TimeSpan.FromMinutes(2),
    spreadApplicationTime: TimeSpan.FromSeconds(30), 
    juicePreparationTime: TimeSpan.FromSeconds(5),
    coffeePreparationTime: TimeSpan.FromSeconds(10));

var kitchenwareProvider = new DefaultKitchenwareProvider();

var cooking = new Cooking(cook, kitchenwareProvider);
var breakfast = cooking.MakeBreakfast();

Console.WriteLine("Breakfast is ready!");


