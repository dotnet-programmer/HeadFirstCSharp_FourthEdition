namespace Inheritance;

internal class Bird
{
	public static Random Randomizer = new();

	public virtual Egg[] LayEggs(int numberOfEggs)
	{
		Console.Error.WriteLine("Metoda Bird.LayEggs nie powinna być wywoływana");
		return [];
	}
}