namespace TwoDecks.BlazorWebAssembly;

public class Deck : List<Card>
{
	private static readonly Random _random = new();

	public Deck()
		=> Reset();

	public void Reset()
	{
		Clear();
		FillDeck();
	}

	public void Shuffle()
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
	}

	private void FillDeck()
	{
		for (int suit = 0; suit <= 3; suit++)
		{
			for (int value = 1; value <= 13; value++)
			{
				Add(new Card((Values)value, (Suits)suit));
			}
		}
	}
}