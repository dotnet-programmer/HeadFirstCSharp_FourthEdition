namespace PickRandomCards.BlazorWebAssembly.Pages;

public partial class Home
{
	private int _numberOfCards = 5;
	private string[] _pickedCards = [];

	private void UpdateCards()
		=> _pickedCards = CardPicker.PickSomeCards(_numberOfCards);
}