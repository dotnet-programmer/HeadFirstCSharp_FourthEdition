namespace GoFish.ConsoleApp;

public class GameController
{
	public static Random Random = new();
	private GameState gameState;
	public bool GameOver => gameState.GameOver;
	public Player HumanPlayer => gameState.HumanPlayer;
	public IEnumerable<Player> Opponents => gameState.Opponents;
	public string Status { get; private set; }

	/// <summary>
	/// Constructs a new GameController
	/// </summary>
	/// <param name="humanPlayerName">Name of the human player</param>
	/// <param name="computerPlayerNames">Names of the computer players</param>
	public GameController(string humanPlayerName, IEnumerable<string> computerPlayerNames)
	{
		gameState = new(humanPlayerName, computerPlayerNames, new Deck().Shuffle());
		Status = $"Starting a new game with players {string.Join(", ", gameState.Players)}";
	}

	/// <summary>
	/// Plays the next round, ending the game if everyone ran out of cards
	/// </summary>
	/// <param name="playerToAsk">Which player the human is asking for a card</param>
	/// <param name="valueToAskFor">The value of the card the human is asking for</param>
	public void NextRound(Player playerToAsk, Values valueToAskFor)
	{
		Status = gameState.PlayRound(gameState.HumanPlayer, playerToAsk, valueToAskFor, gameState.Stock) + Environment.NewLine;
		ComputerPlayersPlayNextRound();
		Status += string.Join(Environment.NewLine,
		gameState.Players.Select(player => player.Status));
		Status += $"{Environment.NewLine}The stock has {gameState.Stock.Count()} cards";
		Status += Environment.NewLine + gameState.CheckForWinner();
	}

	/// <summary>
	/// All of the computer players that have cards play the next round. If the human is
	/// out of cards, then the deck is depleted and they play out the rest of the game.
	/// </summary>
	private void ComputerPlayersPlayNextRound()
	{
		IEnumerable<Player> computerPlayersWithCards;
		do
		{
			computerPlayersWithCards = gameState.Opponents.Where(player => player.Hand.Count() > 0);
			foreach (Player player in computerPlayersWithCards)
			{
				var randomPlayer = gameState.RandomPlayer(player);
				var randomValue = player.RandomValueFromHand();
				Status += gameState.PlayRound(player, randomPlayer, randomValue, gameState.Stock) + Environment.NewLine;
			}
		} while ((gameState.HumanPlayer.Hand.Count() == 0) && (computerPlayersWithCards.Count() > 0));
	}

	/// <summary>
	/// Starts a new game with the same player names
	/// </summary>
	public void NewGame()
	{
		Status = "Starting a new game";
		gameState = new GameState(gameState.HumanPlayer.Name, gameState.Opponents.Select(player => player.Name), new Deck().Shuffle());
	}
}