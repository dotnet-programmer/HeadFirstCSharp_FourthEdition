using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace MemoryGame.WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	private readonly DispatcherTimer _timer = new();
	private readonly Random _random = new();
	private readonly List<string> _randomAnimals = [];

	private int _tenthsOfSecondsElapsed;
	private int _matchesFound;
	private bool _findingMatch;
	private TextBlock _lastTextBlock;

	public MainWindow()
	{
		InitializeComponent();
		SetTimer();
		SetUpGame();
	}

	private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
	{
		if (_matchesFound == 8)
		{
			return;
		}
		
		TextBlock textBlock = sender as TextBlock;
		int index = int.Parse(textBlock.Name[2..]);

		if (!_findingMatch)
		{
			_findingMatch = true;
			textBlock.Text = _randomAnimals[index];
			_lastTextBlock = textBlock;
		}
		else if (textBlock != _lastTextBlock)
		{
			textBlock.Text = _randomAnimals[index];
			Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle);

			if (_lastTextBlock.Text == textBlock.Text)
			{
				_matchesFound++;
				_findingMatch = false;
			}
			else
			{
				Thread.Sleep(1000);
				textBlock.Text = _lastTextBlock.Text = "?";
				_findingMatch = false;
				_lastTextBlock = null;
			}
		}

		if (_matchesFound == 8)
		{
			_timer.Stop();
			TimerText.Content += " - Play again?";
		}
	}

	private void TimerText_MouseDown(object sender, MouseButtonEventArgs e)
	{
		if (_matchesFound == 8)
		{
			SetUpGame();
		}
	}

	private void SetTimer()
	{
		_timer.Interval = TimeSpan.FromSeconds(.1);
		_timer.Tick += Timer_Tick;
	}

	private void Timer_Tick(object sender, EventArgs e)
	{
		_tenthsOfSecondsElapsed++;
		TimerText.Content = (_tenthsOfSecondsElapsed / 10d).ToString("0.0s");
	}

	private void SetUpGame()
	{
		List<string> animals =
		[
			"🦇", "🦇",
			"🐅", "🐅",
			"🦥", "🦥",
			"🦔", "🦔",
			"🐢", "🐢",
			"🐘", "🐘",
			"🦭", "🦭",
			"🦀", "🦀",
		];

		_randomAnimals.Clear();

		foreach (var item in MainGrid.Children.OfType<TextBlock>())
		{
			item.Text = "?";
			int index = _random.Next(animals.Count);
			_randomAnimals.Add(animals[index]);
			animals.RemoveAt(index);
		}

		StartTimer();
	}

	private void StartTimer()
	{
		_tenthsOfSecondsElapsed = 0;
		_matchesFound = 0;
		_timer.Start();
	}
}