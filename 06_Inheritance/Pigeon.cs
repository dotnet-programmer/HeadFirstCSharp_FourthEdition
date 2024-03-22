namespace Inheritance;

internal class Pigeon : Bird
{
	public override Egg[] LayEggs(int numberOfEggs)
	{
		Egg[] eggs = new Egg[numberOfEggs];

		for (int i = 0; i < numberOfEggs; i++)
		{
			eggs[i] = Randomizer.Next(4) == 0 ? new BrokenEgg("Białe") : new Egg(Randomizer.NextDouble() * 2 + 1, "Białe");
		}

		return eggs;
	}
}