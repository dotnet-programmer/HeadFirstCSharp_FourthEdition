namespace Dziedziczenie;

internal class Ostrich : Bird
{
	public override Egg[] LayEggs(int numberOfEggs)
	{
		Egg[] eggs = new Egg[numberOfEggs];

		for (int i = 0; i < numberOfEggs; i++)
		{
			eggs[i] = new(Randomizer.NextDouble() + 12, "Nakrapiane");
		}

		return eggs;
	}
}