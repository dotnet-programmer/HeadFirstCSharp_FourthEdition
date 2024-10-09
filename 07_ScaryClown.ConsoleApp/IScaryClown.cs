namespace ScaryClown.ConsoleApp;

internal interface IScaryClown : IClown
{
    string ScaryThingIHave { get; }

    void ScareLittleChildren();

    void ScareAdults()
    {
        Console.WriteLine($@"Jestem pradawnym złem prześladującym Cię we snach.
Spójrz na mój przerażający naszyjnik z {_random.Next(4, 10)} palcami moich ofiar.

A, byłbym zapomniał...");
        ScareLittleChildren();
    }
}