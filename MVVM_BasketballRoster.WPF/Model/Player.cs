namespace BasketballRoster.WPF.Model;

internal class Player(string name, int number, bool starter)
{
	public string Name { get; private set; } = name;
	public int Number { get; private set; } = number;
	public bool Starter { get; private set; } = starter;
}