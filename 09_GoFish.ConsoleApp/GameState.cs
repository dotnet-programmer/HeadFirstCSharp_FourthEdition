namespace GoFish.ConsoleApp;

public class GameState
{
	public readonly IEnumerable<Player> Players;
	public readonly IEnumerable<Player> Opponents;
	public readonly Player HumanPlayer;
	public readonly Deck Stock;

	/// <summary>
	/// Constructor creates the players and deals their first hands
	/// </summary>
	/// <param name="humanPlayerName">Name of the human player</param>
	/// <param name="opponentNames">Names of the computer players</param>
	/// <param name="stock">Shuffled stock of cards to deal from</param>
	public GameState(string humanPlayerName, IEnumerable<string> opponentNames, Deck stock)
	{
		Stock = stock;

		HumanPlayer = new(humanPlayerName);
		HumanPlayer.GetNextHand(Stock);

		var opponents = new List<Player>();
		foreach (string name in opponentNames)
		{
			var player = new Player(name);
			player.GetNextHand(stock);
			opponents.Add(player);
		}
		Opponents = opponents;
		Players = new List<Player>() { HumanPlayer }.Concat(Opponents);
	}

	public bool GameOver { get; private set; } = false;

	/// <summary>
	/// Gets a random player that doesn't match the current player
	/// </summary>
	/// <param name="currentPlayer">The current player</param>
	/// <returns>A random player that the current player can ask for a card</returns>
	public Player RandomPlayer(Player currentPlayer) 
		=> Players.Where(p => p != currentPlayer).ElementAt(Player.Random.Next(Players.Count() - 1));

	/// <summary>
	/// Makes one player play a round
	/// </summary>
	/// <param name="player">The player asking for a card</param>
	/// <param name="playerToAsk">The player being asked for a card</param>
	/// <param name="valueToAskFor">The value to ask the player for</param>
	/// <param name="stock">The stock to draw cards from</param>
	/// <returns>A message that describes what just happened</returns>
	public string PlayRound(Player player, Player playerToAsk, Values valueToAskFor, Deck stock)
	{
		// Owen asked Brittney for Jacks" + Environment.NewLine + "Brittney has 1 Jack card"

		var valuePlural = (valueToAskFor == Values.Six) ? "Sixes" : $"{valueToAskFor}s";
		string message = $"{player} asked {playerToAsk} for {valuePlural}{Environment.NewLine}";

		var cards = playerToAsk.DoYouHaveAny(valueToAskFor, stock);
		if (cards.Any())
		{
			player.AddCardsAndPullOutBooks(cards);
			message += $"{playerToAsk} has {cards.Count()} {valueToAskFor} card{Player.S(cards.Count())}";
		}
		else if (stock.Count == 0)
		{
			message += $"The stock is out of cards";
		}
		else
		{
			player.DrawCard(stock);
			message += $"{player.Name} drew a card";
		}
		if (!player.Hand.Any())
		{
			player.GetNextHand(stock);
			message += $"{Environment.NewLine}{player.Name} ran out of cards, drew {player.Hand.Count()} from the stock";
		}
		return message;
	}

	/// <summary>
	/// Checks for a winner by seeing if any players have any cards left, sets GameOver
	/// if the game is over and there's a winner
	/// </summary>
	/// <returns>A string with the winners, an empty string if there are no winners</returns>
	public string CheckForWinner()
	{
		if (Players.Any(p => p.Hand.Any()))
		{
			return string.Empty;
		}

		GameOver = true;
		var max = Players.Max(p => p.Books.Count());
		var winners = Players.Where(p => p.Books.Count() == max);
		return winners.Count() == 1 ? $"The winner is {winners.First().Name}" : $"The winners are {string.Join(" and ", winners)}";
	}
}