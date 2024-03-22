﻿namespace Stopwatch.ConsoleApp.Model;

internal class StopwatchModel
{
	private DateTime _startedTime;
	private DateTime _pausedAt;
	private TimeSpan _totalPausedTime;
	private bool _paused;

	/// <summary>
	/// The constructor resets the stopwatch
	/// </summary>
	public StopwatchModel()
		=> Reset();

	public TimeSpan LapTime { get; private set; }

	/// <summary>
	/// Returns true if the stopwatch is running
	/// </summary>
	public bool Running
	{
		get => (_startedTime != DateTime.MinValue) && !_paused;
		set
		{
			if (value)
			{
				_paused = false;
				if (_pausedAt != DateTime.MinValue)
				{
					_totalPausedTime += DateTime.Now - _pausedAt;
				}

				if (_startedTime == DateTime.MinValue)
				{
					_startedTime = DateTime.Now;
				}
			}
			else
			{
				_paused = true;
				_pausedAt = DateTime.Now;
			}
		}
	}

	/// <summary>
	/// Returns the elapsed time, or zero if the stopwatch is not running
	/// </summary>
	public TimeSpan Elapsed 
		=> _paused
		? _pausedAt - _startedTime - _totalPausedTime
		: _startedTime != DateTime.MinValue 
			? DateTime.Now - _startedTime - _totalPausedTime 
			: TimeSpan.Zero;

	public void SetLapTime() 
		=> LapTime = Elapsed;

	/// <summary>
	/// Resets the stopwatch by setting its started time to DateTime.MinValue
	/// </summary>
	public void Reset()
	{
		_startedTime = DateTime.MinValue;
		_pausedAt = DateTime.MinValue;
		_paused = false;
		_totalPausedTime = TimeSpan.Zero;
		LapTime = TimeSpan.Zero;
	}
}