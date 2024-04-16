using PickRandomCards.ConsoleApp;

Console.Write("Wpisz liczbę generowanych kart: ");
string input = Console.ReadLine();

if (int.TryParse(input, out int numberOfCards))
{
	var cards = CardPicker.PickSomeCards(numberOfCards);
	foreach (var item in cards)
	{
		Console.WriteLine(item);
	}
}
else
{
	Console.WriteLine("Błąd danych! Nie podałeś liczby!");
}