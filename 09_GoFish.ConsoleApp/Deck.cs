namespace GoFish.ConsoleApp;

public class Deck : List<Card>
{
	private static readonly Random _random = Player.Random;

	public Deck()
		=> Reset();

	public void Reset()
	{
		Clear();
		for (int suit = 0; suit <= 3; suit++)
		{
			for (int value = 1; value <= 13; value++)
			{
				Add(new Card((Values)value, (Suits)suit));
			}
		}
	}

	public Deck Shuffle()
	{
		List<Card> copy = new(this);
		Clear();
		while (copy.Count > 0)
		{
			int index = _random.Next(copy.Count);
			Card card = copy[index];
			copy.RemoveAt(index);
			Add(card);
		}
		return this;
	}

	public Card Deal(int index)
	{
		Card cardToDeal = base[index];
		RemoveAt(index);
		return cardToDeal;
	}
}