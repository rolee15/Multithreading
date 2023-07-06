using JetBrains.Annotations;

namespace Multithreading.Units;

public readonly record struct FluidVolume(uint Milliliters)
{
    [PublicAPI]
    public static FluidVolume FromLiters(uint liters) => new(liters * 1000);
    
    [PublicAPI]
    public static FluidVolume FromDeciliters(uint deciliters) => new(deciliters * 100);
    
    [PublicAPI]
    public static FluidVolume FromCentiliters(uint centiliters) => new(centiliters * 10);
    
    [PublicAPI]
    public static FluidVolume FromMilliliters(uint milliliters) => new(milliliters);
    
    [PublicAPI]
    public static FluidVolume FromGallons(uint gallons) => new(gallons * 3785);

    [PublicAPI]
    public static FluidVolume FromQuarts(uint quarts) => new(quarts * 946);
    
    [PublicAPI]
    public static FluidVolume FromPints(uint pints) => new(pints * 473);
    
    [PublicAPI]
    public static FluidVolume FromCups(uint cups) => new(cups * 240);
    
    [PublicAPI]
    public static FluidVolume FromFluidOunces(uint fluidOunces) => new(fluidOunces * 30);
    
    [PublicAPI]
    public static FluidVolume Zero => new(0);
    
    [PublicAPI]
    public double ToLiters() => Milliliters / 1000d;
    
    [PublicAPI]
    public double ToDeciliters() => Milliliters / 100d;
    
    [PublicAPI]
    public double ToCentiliters() => Milliliters / 10d;
    
    [PublicAPI]
    public double ToMilliliters() => Milliliters;
    
    [PublicAPI]
    public double ToGallons() => Milliliters / 3785d;
    
    [PublicAPI]
    public double ToQuarts() => Milliliters / 946d;
    
    [PublicAPI]
    public double ToPints() => Milliliters / 473d;
    
    [PublicAPI]
    public double ToCups() => Milliliters / 240d;
    
    [PublicAPI]
    public double ToFluidOunces() => Milliliters / 30d;
    
    [PublicAPI]
    public static FluidVolume operator +(FluidVolume left, FluidVolume right) => new(left.Milliliters + right.Milliliters);
    
    [PublicAPI]
    public static FluidVolume operator -(FluidVolume left, FluidVolume right) => new(left.Milliliters - right.Milliliters);
    
    [PublicAPI]
    public static FluidVolume operator *(FluidVolume left, uint right) => new(left.Milliliters * right);
    
    [PublicAPI]
    public static FluidVolume operator *(uint left, FluidVolume right) => new(left * right.Milliliters);
    
    [PublicAPI]
    public static FluidVolume operator /(FluidVolume left, uint right) => new(left.Milliliters / right);
    
    [PublicAPI]
    public static FluidVolume operator /(uint left, FluidVolume right) => new(left / right.Milliliters);
    
    [PublicAPI]
    public static bool operator >(FluidVolume left, FluidVolume right) => left.Milliliters > right.Milliliters;
    
    [PublicAPI]
    public static bool operator <(FluidVolume left, FluidVolume right) => left.Milliliters < right.Milliliters; 
    
}