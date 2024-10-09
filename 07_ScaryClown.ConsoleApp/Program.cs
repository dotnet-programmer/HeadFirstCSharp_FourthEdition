using ScaryClown.ConsoleApp;

IClown.CarCapacity = 18;
Console.WriteLine(IClown.ClownCarDescription());

IClown fingersTheClown = new ScaryScary("wielkie czerwone nosy", 14);

fingersTheClown.Honk();

if (fingersTheClown is IScaryClown iScaryClownReference)
{
    iScaryClownReference.ScareAdults();
}