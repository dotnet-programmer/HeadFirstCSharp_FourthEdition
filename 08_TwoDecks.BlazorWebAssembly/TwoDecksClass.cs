namespace TwoDecks.BlazorWebAssembly;

public class TwoDecksClass
{
	private Deck _leftDeck = [];
	private readonly Deck _rightDeck = [];

	public int LeftDeckCount
		=> _leftDeck.Count;

	public int RightDeckCount
		=> _rightDeck.Count;

	public int LeftCardSelected { get; set; }
	public int RightCardSelected { get; set; }

	public string LeftDeckCardName(int i)
		=> _leftDeck[i].ToString();

	public string RightDeckCardName(int i)
		=> _rightDeck[i].ToString();

	public void Shuffle()
		=> _leftDeck.Shuffle();

	public void Reset()
		=> _leftDeck = [];

	public void Clear()
		=> _rightDeck.Clear();

	public void Sort()
		=> _rightDeck.Sort(new CardComparerByValue());

	public void MoveCard(Direction direction)
	{
		if (direction == Direction.LeftToRight)
		{
			_rightDeck.Add(_leftDeck[LeftCardSelected]);
			_leftDeck.RemoveAt(LeftCardSelected);
		}
		else
		{
			_leftDeck.Add(_rightDeck[RightCardSelected]);
			_rightDeck.RemoveAt(RightCardSelected);
		}
	}
}