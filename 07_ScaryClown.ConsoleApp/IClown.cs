namespace ScaryClown.ConsoleApp;

internal interface IClown
{
    protected static Random _random = new();

    private static int _carCapacity = 12;

    string FunnyThingIHave { get; }

    public static int CarCapacity
    {
        get => _carCapacity;
        set
        {
            if (value > 10)
            {
                _carCapacity = value;
            }
            else
            {
                Console.Error.WriteLine($"Uwaga: pojemność autka, {value}, " + " jest za mała.");
            }
        }
    }

    void Honk();

    public static string ClownCarDescription()
        => $"Liczba klaunów w autku: {_random.Next(CarCapacity / 2, CarCapacity)}.";
}
