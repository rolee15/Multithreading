using Multithreading.Units;

namespace Multithreading.Kitchen;

internal interface IKitchenwareProvider
{
    Cup GetCup();
    Glass GetGlass();
    Pan GetPan();
    Toaster GetToaster();
}

internal class DefaultKitchenwareProvider : IKitchenwareProvider
{
    public Cup GetCup()
    {
        return Cup.Default;
    }
    
    public Glass GetGlass()
    {
        return Glass.Default;
    }
    
    public Pan GetPan()
    {
        return Pan.Default;
    }
    
    public Toaster GetToaster()
    {
        return Toaster.Default;
    }
}