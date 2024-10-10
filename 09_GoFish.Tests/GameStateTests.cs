using GoFish.ConsoleApp;

namespace GoFish.Tests;

[TestClass]
public class GameStateTests
{
	[TestMethod]
	public void TestConstructor()
	{
		var computerPlayerNames = new List<string>()
		{
			"Computer1",
			"Computer2",
			"Computer3",
		};

		var gameState = new GameState("Human", computerPlayerNames, []);
		CollectionAssert.AreEqual(
			new List<string> { "Human", "Computer1", "Computer2", "Computer3" },
			gameState.Players.Select(player => player.Name).ToList());
		Assert.AreEqual(5, gameState.HumanPlayer.Hand.Count());
	}

	[TestMethod]
	public void TestRandomPlayer()
	{
		var computerPlayerNames = new List<string>()
		{
			"Computer1",
			"Computer2",
			"Computer3",
		};
		var gameState = new GameState("Human", computerPlayerNames, []);
		Player.Random = new MockRandom() { ValueToReturn = 1 };
		Assert.AreEqual("Computer2", gameState.RandomPlayer(gameState.Players.ToList()[0]).Name);
		Player.Random = new MockRandom() { ValueToReturn = 0 };
		Assert.AreEqual("Human", gameState.RandomPlayer(gameState.Players.ToList()[1]).Name);
		Assert.AreEqual("Computer1", gameState.RandomPlayer(gameState.Players.ToList()[0]).Name);
	}

	[TestMethod]
	public void TestPlayRound()
	{
		var deck = new Deck();
		deck.Clear();
		var cardsToAdd = new List<Card>() {
			// Cards the game will deal to Owen
			new(Values.Jack, Suits.Spades),
			new(Values.Jack, Suits.Hearts),
			new(Values.Six, Suits.Spades),
			new(Values.Jack, Suits.Diamonds),
			new(Values.Six, Suits.Hearts),
			// Cards the game will deal to Brittney
			new(Values.Six, Suits.Diamonds),
			new(Values.Six, Suits.Clubs),
			new(Values.Seven, Suits.Spades),
			new(Values.Jack, Suits.Clubs),
			new(Values.Nine, Suits.Spades),
			// Two more cards in the deck for Owen to draw when he runs out
			new(Values.Queen, Suits.Hearts),
			new(Values.King, Suits.Spades),
		};
		foreach (var card in cardsToAdd)
		{
			deck.Add(card);
		}

		var gameState = new GameState("Owen", ["Brittney"], deck);
		var owen = gameState.HumanPlayer;
		var brittney = gameState.Opponents.First();
		Assert.AreEqual("Owen", owen.Name);
		Assert.AreEqual(5, owen.Hand.Count());
		Assert.AreEqual("Brittney", brittney.Name);
		Assert.AreEqual(5, brittney.Hand.Count());

		var message = gameState.PlayRound(owen, brittney, Values.Jack, deck);
		Assert.AreEqual("Owen asked Brittney for Jacks" + Environment.NewLine + "Brittney has 1 Jack card", message);
		Assert.AreEqual(1, owen.Books.Count());
		Assert.AreEqual(2, owen.Hand.Count());
		Assert.AreEqual(0, brittney.Books.Count());
		Assert.AreEqual(4, brittney.Hand.Count());

		message = gameState.PlayRound(brittney, owen, Values.Six, deck);
		Assert.AreEqual("Brittney asked Owen for Sixes" + Environment.NewLine + "Owen has 2 Six cards", message);
		Assert.AreEqual(1, owen.Books.Count());
		Assert.AreEqual(2, owen.Hand.Count());
		Assert.AreEqual(1, brittney.Books.Count());
		Assert.AreEqual(2, brittney.Hand.Count());

		message = gameState.PlayRound(owen, brittney, Values.Queen, deck);
		Assert.AreEqual("Owen asked Brittney for Queens" + Environment.NewLine + "The stock is out of cards", message);
		Assert.AreEqual(1, owen.Books.Count());
		Assert.AreEqual(2, owen.Hand.Count());
	}

	[TestMethod]
	public void TestCheckForAWinner()
	{
		var computerPlayerNames = new List<string>()
		{
			"Computer1",
			"Computer2",
			"Computer3",
		};
		var emptyDeck = new Deck();
		emptyDeck.Clear();
		var gameState = new GameState("Human", computerPlayerNames, emptyDeck);
		Assert.AreEqual("The winners are Human and Computer1 and Computer2 and Computer3", gameState.CheckForWinner());
	}
}