namespace ScaryClown.ConsoleApp;

internal class FunnyFunny(string funnyThingIHave) : IClown
{
    private readonly string _funnyThingIHave = funnyThingIHave;

    public string FunnyThingIHave
        => _funnyThingIHave;

    public void Honk()
        => Console.WriteLine($"Cześć, dzieciaki! Mam {_funnyThingIHave}.");
}