using System;

namespace Sandwiches.WPFApp;

internal class MenuItem
{
	public static Random Randomizer = new();

	public string[] Proteins = ["Wołowina", "Salami", "Indyk", "Szynka", "Pastrami", "Tofu"];
	public string[] Condiments = ["musztarda żółta", "musztarda brązowa", "musztarda miodowa", "majonez", "przyprawy", "sos francuski"];
	public string[] Breads = ["ryżowe", "białe", "pszenne", "pumpernikiel", "bułka"];

	public string Description = "";
	public string Price;

	public void Generate()
	{
		string randomProtein = Proteins[Randomizer.Next(Proteins.Length)];
		string randomCondiment = Condiments[Randomizer.Next(Condiments.Length)];
		string randomBread = Breads[Randomizer.Next(Breads.Length)];
		Description = randomProtein + " i " + randomCondiment + ". Pieczywo: " + randomBread + ".";

		decimal bucks = Randomizer.Next(1, 10);
		decimal cents = Randomizer.Next(1, 100);
		decimal price = bucks + (cents * .01M);
		Price = price.ToString("c");
	}
}