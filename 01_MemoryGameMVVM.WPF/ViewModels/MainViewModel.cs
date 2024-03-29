using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using MemoryGameMVVM.WPF.Commands;

namespace MemoryGameMVVM.WPF.ViewModels;

internal class MainViewModel : BaseViewModel
{
	private readonly List<string> _randomAnimals = [];
	private readonly DispatcherTimer _timer = new();
	private readonly Random _random = new();
	private readonly Grid _mainGrid;

	private int _matchesFound;
	private int _tenthsOfSecondsElapsed;
	private bool _findingMatch;
	private Button? _lastButton;

	public MainViewModel(Grid mainGrid)
	{
		_mainGrid = mainGrid;
		SetCommands();
		SetTimer();
		SetUpGame();
		StartTimer();
	}

	private string _timeElapsed;
	public string TimeElapsed
	{
		get => _timeElapsed;
		set { _timeElapsed = value; OnPropertyChanged(); }
	}

	public ICommand GridTileCommand { get; private set; }
	public ICommand RestartGameCommand { get; private set; }

	private void SetCommands()
	{
		GridTileCommand = new RelayCommand(CheckIsMatch, CanCheckIsMatch);
		RestartGameCommand = new RelayCommand(RestartGame, CanRestartGame);
	}

	private void CheckIsMatch(object commandParameter)
	{
		if (commandParameter is Button button)
		{
			int index = int.Parse(button.Name[3..]);

			if (!_findingMatch)
			{
				_findingMatch = true;
				button.Content = _randomAnimals[index];
				_lastButton = button;
			}
			else if (button != _lastButton)
			{
				button.Content = _randomAnimals[index];
				Application.Current.Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle);

				if (_lastButton.Content == button.Content)
				{
					_matchesFound++;
					_findingMatch = false;
				}
				else
				{
					Thread.Sleep(1000);
					button.Content = _lastButton.Content = "?";
					_findingMatch = false;
					_lastButton = null;
				}
			}
		}
	}

	private bool CanCheckIsMatch(object commandParameter)
		=> _matchesFound != 8;

	private void RestartGame(object commandParameter)
	{
		SetUpGame();
		StartTimer();
	}

	private bool CanRestartGame(object commandParameter)
		=> _matchesFound == 8;

	private void SetTimer()
	{
		_timer.Interval = TimeSpan.FromMilliseconds(100);
		_timer.Tick += Timer_Tick;
	}

	private void Timer_Tick(object? sender, EventArgs e)
	{
		_tenthsOfSecondsElapsed++;
		TimeElapsed = (_tenthsOfSecondsElapsed / 10d).ToString("0.0s");

		if (_matchesFound == 8)
		{
			_timer.Stop();
			TimeElapsed += " - Jeszcze raz?";
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

		_randomAnimals.Clear();
		var buttons = _mainGrid.Children.OfType<Button>();
		foreach (var button in buttons)
		{
			button.Content = "?";
			int index = _random.Next(animals.Count);
			_randomAnimals.Add(animals[index]);
			animals.RemoveAt(index);
		}
		_tenthsOfSecondsElapsed = 0;
		_matchesFound = 0;
	}

	private void StartTimer()
		=> _timer.Start();
}