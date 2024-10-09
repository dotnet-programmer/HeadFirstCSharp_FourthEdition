namespace ScaryClown.ConsoleApp;

internal class ScaryScary(string funnyThing, int scaryThingCount) : FunnyFunny(funnyThing), IScaryClown
{
    private readonly int _scaryThingCount = scaryThingCount;

    public string ScaryThingIHave
        => $"pająki - {_scaryThingCount}";

    public void ScareLittleChildren()
        => Console.WriteLine($"Ha! Mam was! Zobaczcie moje {ScaryThingIHave}!");
}