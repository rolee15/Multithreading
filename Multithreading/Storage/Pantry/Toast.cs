namespace Multithreading.Storage.Pantry;

internal record Toast
{
    public Spread Spread { get; set; } = Spread.None;
}