using Microsoft.AspNetCore.Components.Web;

namespace TwoDecks.BlazorWebAssembly.Pages;

public partial class Home
{
	private readonly TwoDecksClass _twoDecks = new();

	private void LeftKeyHandler(KeyboardEventArgs e)
	{
		if (e.Key == "Enter")
		{
			_twoDecks.MoveCard(Direction.LeftToRight);
		}
	}

	private void RightKeyHandler(KeyboardEventArgs e)
	{
		if (e.Key == "Enter")
		{
			_twoDecks.MoveCard(Direction.RightToLeft);
		}
	}

	private void LeftDblClickHandler(MouseEventArgs e)
		=> _twoDecks.MoveCard(Direction.LeftToRight);

	private void RightDblClickHandler(MouseEventArgs e)
		=> _twoDecks.MoveCard(Direction.RightToLeft);
}
