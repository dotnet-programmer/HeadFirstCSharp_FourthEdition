﻿using Stopwatch.ConsoleApp.ViewModel;

namespace Stopwatch.ConsoleApp.View;

internal class StopwatchView
{
	private readonly StopwatchViewModel _viewModel = new();
	private bool _quit = false;

	/// <summary>
	/// Clears the console and displays the stopwatch
	/// </summary>
	public StopwatchView()
	{
		ClearScreenAndAddHelpMessage();
		TimerCallback timerCallback = UpdateTimeCallback;
		var _timer = new Timer(timerCallback, null, 0, 10);
		while (!_quit)
		{
			Thread.Sleep(100);
		}

		Console.CursorVisible = true;
	}

	/// <summary>
	/// Clears the screen, adds the help message to fourth row, and makes the cursor invisible
	/// </summary>
	private static void ClearScreenAndAddHelpMessage()
	{
		Console.Clear();
		Console.CursorTop = 3; // This moves the cursor to the fourth row (rows start at 0)
		Console.WriteLine("Space to start or stop, R to reset, L for lap time, any other key to quit");
		Console.CursorVisible = false;
	}

	/// <summary>
	/// Callback to update the time display that the time calls each time it ticks
	/// </summary>
	private void UpdateTimeCallback(object state)
	{
		if (Console.KeyAvailable)
		{
			switch (Console.ReadKey(true).KeyChar.ToString().ToUpper())
			{
				case " ":
					_viewModel.StartStop();
					break;
				case "R":
					_viewModel.Reset();
					break;
				case "L":
					_viewModel.LapTime();
					break;
				default:
					Console.CursorVisible = true;
					Console.CursorLeft = 0;
					Console.CursorTop = 5;
					_quit = true;
					break;
			}
		}
		WriteCurrentTime();
	}

	/// <summary>
	/// Writes the current time to the second row and 23rd column of the screen
	/// </summary>
	private void WriteCurrentTime()
	{
		Console.CursorTop = 1; // This moves the cursor to the second row (rows start at 0)
		Console.CursorLeft = 23; // This moves the cursor to the 23rd column (starting at 0)
		var time = $"{_viewModel.Hours}:{_viewModel.Minutes}:{_viewModel.Seconds}.{_viewModel.Tenths}";
		var lapTime = $"{_viewModel.LapHours}:{_viewModel.LapMinutes}:{_viewModel.LapSeconds}.{_viewModel.LapTenths}";
		Console.Write($"{time} - lap time {lapTime}");
	}
}