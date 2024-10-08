using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MatchGame;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	private readonly Game _game;

	public MainWindow()
	{
		InitializeComponent();
		_game = new(MainGrid.Children.OfType<TextBlock>().Where(x => x.Name != nameof(TimerTextBlock)), TimerTextBlock, 0.1);
		_game.StartNewGame();
	}

	private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
	{
		if (sender is TextBlock textBlock)
		{
			_game.FindMatch(textBlock);
		}
	}

	private void TimerTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
	{
		if (_game.IsGameOver)
		{
			_game.StartNewGame();
		}
	}
}