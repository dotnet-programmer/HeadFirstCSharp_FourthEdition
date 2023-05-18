using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace MatchGame;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	private TextBlock? _lastTextBlockClicked;
	private bool _findingMatch = false;

	private readonly DispatcherTimer _timer = new();
	private int _tenthsOfSecondsElapsed;
	private int _matchesFound;

	public MainWindow()
	{
		InitializeComponent();
		SetTimer();
		SetUpGame();
	}

	private void SetUpGame()
	{
		List<string> animals = new()
		{
			"🦇", "🦇",
			"🐅", "🐅",
			"🦥", "🦥",
			"🦔", "🦔",
			"🐢", "🐢",
			"🐘", "🐘",
			"🦭", "🦭",
			"🦀", "🦀",
		};

		Random random = new();

		foreach (var item in MainGrid.Children.OfType<TextBlock>())
		{
			if (item.Name != "TimerTextBlock")
			{
				item.Visibility = Visibility.Visible;
				int index = random.Next(animals.Count);
				item.Text = animals[index];
				animals.RemoveAt(index);
			}
		}

		StartTimer();
	}

	private void SetTimer()
	{
		_timer.Interval = TimeSpan.FromSeconds(.1);
		_timer.Tick += Timer_Tick;
	}

	private void StartTimer()
	{
		_timer.Start();
		_tenthsOfSecondsElapsed = 0;
		_matchesFound = 0;
	}

	private void Timer_Tick(object? sender, EventArgs e)
	{
		_tenthsOfSecondsElapsed++;
		TimerTextBlock.Text = (_tenthsOfSecondsElapsed / 10d).ToString("0.0s");

		if (_matchesFound == 8)
		{
			_timer.Stop();
			TimerTextBlock.Text += " - Jeszcze raz?";
		}
	}

	private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
	{
		TextBlock textBlock = sender as TextBlock;

		if (!_findingMatch)
		{
			textBlock.Visibility = Visibility.Hidden;
			_lastTextBlockClicked = textBlock;
			_findingMatch = true;
		}
		else if (textBlock.Text == _lastTextBlockClicked.Text)
		{
			textBlock.Visibility = Visibility.Hidden;
			_findingMatch = false;
			_matchesFound++;
		}
		else
		{
			_lastTextBlockClicked.Visibility = Visibility.Visible;
			_findingMatch = false;
		}
	}

	private void TimerTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
	{
		if (_matchesFound == 8)
		{
			SetUpGame();
		}
	}
}