using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MatchGame;

internal class Game
{
	private readonly DispatcherTimer _timer = new();
	private readonly IEnumerable<TextBlock> _textBlocks;
	private readonly TextBlock _timerTextBlock;
	private readonly double _timerInterval;

	private TextBlock _lastTextBlockClicked;
	private int _tenthsOfSecondsElapsed;
	private int _matchesFound;
	private bool _findingMatch;

	public Game(IEnumerable<TextBlock> textBlocks, TextBlock timerTextBlock, double timerInterval)
	{
		_textBlocks = textBlocks;
		_timerTextBlock = timerTextBlock;
		_timerInterval = timerInterval;
		SetTimer();
	}

	public bool IsGameOver
		=> _matchesFound == 8;

	public void StartNewGame()
	{
		SetUpGame();
		_timer.Start();
	}

	public void FindMatch(TextBlock textBlock)
	{
		if (!_findingMatch)
		{
			_lastTextBlockClicked = textBlock;
			_lastTextBlockClicked.Visibility = Visibility.Hidden;
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

	private void SetTimer()
	{
		_timer.Interval = TimeSpan.FromSeconds(_timerInterval);
		_timer.Tick += Timer_Tick;
	}

	private void Timer_Tick(object sender, EventArgs e)
	{
		_tenthsOfSecondsElapsed++;
		_timerTextBlock.Text = (_tenthsOfSecondsElapsed / 10d).ToString("0.0s");

		if (_matchesFound == 8)
		{
			_timer.Stop();
			_timerTextBlock.Text += " - Jeszcze raz?";
		}
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

		Random random = new();
		foreach (var item in _textBlocks)
		{
			item.Visibility = Visibility.Visible;
			int index = random.Next(animals.Count);
			item.Text = animals[index];
			animals.RemoveAt(index);
		}

		_tenthsOfSecondsElapsed = _matchesFound = 0;
	}
}