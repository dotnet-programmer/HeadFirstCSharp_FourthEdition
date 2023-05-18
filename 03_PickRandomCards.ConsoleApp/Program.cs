using PickRandomCards.ConsoleApp;

Console.Write("Wpisz liczbę generowanych kart: ");
string input = Console.ReadLine();
if (int.TryParse(input, out int numberOfCadrs))
{
	var cards = CardPicker.PickSomeCards(numberOfCadrs);
	foreach (var item in cards)
	{
		Console.WriteLine(item);
	}
}
else
{
	Console.WriteLine("Błąd danych! Nie podałeś liczby!");
}