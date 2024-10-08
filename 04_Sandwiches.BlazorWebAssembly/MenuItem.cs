namespace Sandwiches.BlazorWebAssembly;

public class MenuItem
{
	private static readonly Random _randomizer = new();

	public string[] Proteins = ["Wołowina", "Salami", "Indyk", "Szynka", "Pastrami", "Tofu"];
	public string[] Condiments = ["musztarda żółta", "musztarda brązowa", "musztarda miodowa", "majonez", "przyprawy", "sos francuski"];
	public string[] Breads = ["ryżowe", "białe", "pszenne", "pumpernikiel", "bułka"];

	public string Description = string.Empty;
	public string Price = string.Empty;

	public void Generate()
	{
		string randomProtein = Proteins[_randomizer.Next(Proteins.Length)];
		string randomCondiment = Condiments[_randomizer.Next(Condiments.Length)];
		string randomBread = Breads[_randomizer.Next(Breads.Length)];
		Description = randomProtein + " i " + randomCondiment + ". Pieczywo: " + randomBread + ".";

		decimal bucks = _randomizer.Next(1, 10);
		decimal cents = _randomizer.Next(1, 100);
		decimal price = bucks + (cents * .01M);
		Price = price.ToString("c");
	}
}