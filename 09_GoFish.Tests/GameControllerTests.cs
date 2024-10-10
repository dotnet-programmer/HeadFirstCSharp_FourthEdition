﻿using GoFish.ConsoleApp;

namespace GoFish.Tests;

[TestClass]
public class GameControllerTests
{
	[TestInitialize]
	public void Initialize()
		=> Player.Random = new MockRandom() { ValueToReturn = 0 };

	[TestMethod]
	public void TestConstructor()
	{
		GameController gameController = new("Human", ["Player1", "Player2", "Player3"]);
		Assert.AreEqual("Starting a new game with players Human, Player1, Player2, Player3", gameController.Status);
	}

	[TestMethod]
	public void TestNextRound()
	{
		// The constructor shuffles the deck, but MockRandom makes sure it stays in order
		// so Owen should have Ace to 5 of Diamonds, Brittney should have 6 to 10 of Diamonds
		GameController gameController = new("Owen", ["Brittney"]);
		gameController.NextRound(gameController.Opponents.First(), Values.Six);
		Assert.AreEqual("Owen asked Brittney for Sixes" +
			Environment.NewLine + "Brittney has 1 Six card" +
			Environment.NewLine + "Brittney asked Owen for Sevens" +
			Environment.NewLine + "Brittney drew a card" +
			Environment.NewLine + "Owen has 6 cards and 0 books" +
			Environment.NewLine + "Brittney has 5 cards and 0 books" +
			Environment.NewLine + "The stock has 41 cards" +
			Environment.NewLine, gameController.Status);
	}

	[TestMethod]
	public void TestNewGame()
	{
		Player.Random = new MockRandom() { ValueToReturn = 0 };
		GameController gameController = new("Owen", ["Brittney"]);
		gameController.NextRound(gameController.Opponents.First(), Values.Six);
		gameController.NewGame();
		Assert.AreEqual("Owen", gameController.HumanPlayer.Name);
		Assert.AreEqual("Brittney", gameController.Opponents.First().Name);
		Assert.AreEqual("Starting a new game", gameController.Status);
	}
}