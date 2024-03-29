using System.Windows;
using System.Windows.Input;

namespace TwoDecks.WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();

		if (Resources["rightDeck"] is Deck rightDeck)
		{
			rightDeck.Clear();
		}
	}

	private void MoveCard(bool leftToRight)
	{
		if ((Resources["rightDeck"] is Deck rightDeck) && (Resources["leftDeck"] is Deck leftDeck))
		{
			if (leftToRight)
			{
				if (ListBoxLeftDeck.SelectedItem is Card card)
				{
					leftDeck.Remove(card);
					rightDeck.Add(card);
				}
			}
			else
			{
				if (ListBoxRightDeck.SelectedItem is Card card)
				{
					rightDeck.Remove(card);
					leftDeck.Add(card);
				}
			}
		}
	}

	private void BtnShuffleLeftDeck_Click(object sender, RoutedEventArgs e)
	{
		if (Resources["leftDeck"] is Deck leftDeck)
		{
			leftDeck.Shuffle();
		}
	}

	private void BtnResetLeftDeck_Click(object sender, RoutedEventArgs e)
	{
		if (Resources["leftDeck"] is Deck leftDeck)
		{
			leftDeck.Reset();
		}
	}

	private void BtnClearRightDeck_Click(object sender, RoutedEventArgs e)
	{
		if (Resources["rightDeck"] is Deck rightDeck)
		{
			rightDeck.Clear();
		}
	}

	private void BtnSortRightDeck_Click(object sender, RoutedEventArgs e)
	{
		if (Resources["rightDeck"] is Deck rightDeck)
		{
			rightDeck.Sort();
		}
	}

	private void ListBoxLeftDeck_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.Key == Key.Enter)
		{
			MoveCard(true);
		}
	}

	private void ListBoxLeftDeck_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		=> MoveCard(true);

	private void ListBoxRightDeck_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.Key == Key.Enter)
		{
			MoveCard(false);
		}
	}

	private void ListBoxRightDeck_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		=> MoveCard(false);
}