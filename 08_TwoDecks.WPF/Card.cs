namespace TwoDecks.WPF;

internal class Card(Values value, Suits suit)
{
	public Values Value { get; private set; } = value;
	public Suits Suit { get; private set; } = suit;

	public string Name 
		=> $"{Value} of {Suit}";

	public override string ToString() 
		=> Name;
}