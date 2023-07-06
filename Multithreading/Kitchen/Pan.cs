namespace Multithreading.Kitchen;

public record Pan(TimeSpan WarmingTime)
{
    public bool IsWarm { get; set; }
    public static Pan Default => new(TimeSpan.FromMinutes(1));
}