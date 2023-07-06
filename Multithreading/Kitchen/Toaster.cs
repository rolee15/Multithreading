namespace Multithreading.Kitchen;

internal record Toaster(TimeSpan ToastingTime)
{
    public static Toaster Default => new(TimeSpan.FromMinutes(3));

    public TimeSpan ManyToastsCookingTime(int slices)
    {
        var remainder = slices % 2;
        var toastCount = slices / 2 + remainder;
        return TimeSpan.FromTicks(ToastingTime.Ticks * toastCount);
    }
}