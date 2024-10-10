using GoFish.ConsoleApp;

namespace GoFish.Tests;

[TestClass]
public class PlayerTests
{
	[TestMethod]
	public void TestGetNextHand()
	{
		var player = new Player("Owen", []);
		player.GetNextHand([]);
		CollectionAssert.AreEqual(new Deck().Take(5).Select(card => card.ToString()).ToList(), player.Hand.Select(card => card.ToString()).ToList());
	}

	[TestMethod]
	public void TestDoYouHaveAny()
	{
		IEnumerable<Card> cards =
		[
			new Card(Values.Jack, Suits.Spades),
			new Card(Values.Three, Suits.Clubs),
			new Card(Values.Three, Suits.Hearts),
			new Card(Values.Four, Suits.Diamonds),
			new Card(Values.Three, Suits.Diamonds),
			new Card(Values.Jack, Suits.Clubs),
		];
		var player = new Player("Owen", cards);
		var threes = player.DoYouHaveAny(Values.Three, [])
							.Select(Card => Card.ToString())
							.ToList();
		CollectionAssert.AreEqual(new List<string>()
		{
			"Three of Diamonds",
			"Three of Clubs",
			"Three of Hearts",
		}, threes);
		Assert.AreEqual(3, player.Hand.Count());

		var jacks = player.DoYouHaveAny(Values.Jack, [])
							.Select(Card => Card.ToString())
							.ToList();
		CollectionAssert.AreEqual(new List<string>()
		{
			"Jack of Clubs",
			"Jack of Spades",
		}, jacks);

		var hand = player.Hand.Select(Card => Card.ToString()).ToList();
		CollectionAssert.AreEqual(new List<string>() { "Four of Diamonds" }, hand);
		Assert.AreEqual("Owen has 1 card and 0 books", player.Status);
	}

	[TestMethod]
	public void TestAddCardsAndPullOutBooks()
	{
		IEnumerable<Card> cards =
		[
			new Card(Values.Jack, Suits.Spades),
			new Card(Values.Three, Suits.Clubs),
			new Card(Values.Jack, Suits.Hearts),
			new Card(Values.Three, Suits.Hearts),
			new Card(Values.Four, Suits.Diamonds),
			new Card(Values.Jack, Suits.Diamonds),
			new Card(Values.Jack, Suits.Clubs),
		];
		var player = new Player("Owen", cards);
		Assert.AreEqual(0, player.Books.Count());
		var cardsToAdd = new List<Card>()
		{
			new(Values.Three, Suits.Diamonds),
			new(Values.Three, Suits.Spades),
		};
		player.AddCardsAndPullOutBooks(cardsToAdd);
		var books = player.Books.ToList();
		CollectionAssert.AreEqual(new List<Values>() { Values.Three, Values.Jack }, books);
		var hand = player.Hand.Select(Card => Card.ToString()).ToList();
		CollectionAssert.AreEqual(new List<string>() { "Four of Diamonds" }, hand);
		Assert.AreEqual("Owen has 1 card and 2 books", player.Status);
	}

	[TestMethod]
	public void TestDrawCard()
	{
		var player = new Player("Owen", []);
		player.DrawCard([]);
		Assert.AreEqual(1, player.Hand.Count());
		Assert.AreEqual("Ace of Diamonds", player.Hand.First().ToString());
	}

	[TestMethod]
	public void TestRandomValueFromHand()
	{
		var player = new Player("Owen", []);
		Player.Random = new MockRandom() { ValueToReturn = 0 };
		Assert.AreEqual("Ace", player.RandomValueFromHand().ToString());
		Player.Random = new MockRandom() { ValueToReturn = 4 };
		Assert.AreEqual("Two", player.RandomValueFromHand().ToString());
		Player.Random = new MockRandom() { ValueToReturn = 8 };
		Assert.AreEqual("Three", player.RandomValueFromHand().ToString());
	}
}