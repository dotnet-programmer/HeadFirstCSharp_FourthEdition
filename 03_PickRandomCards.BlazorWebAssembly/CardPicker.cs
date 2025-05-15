namespace PickRandomCards.BlazorWebAssembly;

public class CardPicker
{
	private static readonly Random _random = new();

	public static string[] PickSomeCards(int numberOfCards)
	{
		string[] cards = new string[numberOfCards];
		for (int i = 0; i < numberOfCards; i++)
		{
			cards[i] = RandomValue() + " " + RandomSuit();
		}
		return cards;
	}

	private static string RandomValue()
	{
		int value = _random.Next(1, 14);
		return value switch
		{
			1 => "As",
			11 => "Walet",
			12 => "Dama",
			13 => "Król",
			_ => value.ToString()
		};
	}

	private static string RandomSuit()
	{
		int suit = _random.Next(1, 5);
		return suit switch
		{
			1 => "pik",
			2 => "kier",
			3 => "trefl",
			4 => "karo",
			_ => throw new InvalidOperationException("Error! Bad suit!")
		};
	}
}