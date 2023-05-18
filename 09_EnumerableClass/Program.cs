using EnumerableClass;

static IEnumerable<string> SimpleEnumerable()
{
	yield return "jabłka";
	yield return "pomarańcze";
	yield return "banany";
	yield return "jednorożce";
}

foreach (var s in SimpleEnumerable())
{
	Console.WriteLine(s);
}

Console.WriteLine();

var sports = new ManualSportSequence();
foreach (var sport in sports)
{
	Console.WriteLine(sport);
}

Console.WriteLine();

var sports2 = new BetterSportSequence();
foreach (var sport in sports2)
{
	Console.WriteLine(sport);
}

Console.WriteLine();

var sequence = new BetterSportSequence();
Console.WriteLine(sequence[3]);

Console.WriteLine();

var powers = new PowersOfTwo();
foreach (var power in powers)
{
	Console.Write(power + " ");
}