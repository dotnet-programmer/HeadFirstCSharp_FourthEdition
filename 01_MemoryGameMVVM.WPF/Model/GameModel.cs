using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Controls;

namespace MemoryGameMVVM.WPF.Model;

internal class GameModel
{
	private readonly List<string> _randomAnimals = new();

	private DateTime _startedTime;
	private DateTime _endedTime;
	public TimeSpan Elapsed => _startedTime != DateTime.MinValue ? DateTime.Now - _startedTime : TimeSpan.Zero;

	public Random Random = new();

	public GameModel() => Reset();

	public void Reset() => _startedTime = DateTime.MinValue;

	public void Start() => _startedTime = DateTime.Now;

	public void Stop() => _endedTime = DateTime.Now;

	internal void SetUpGame(IEnumerable<TextBlock> textBlocks, List<string> animals)
	{
		_randomAnimals.Clear();

		foreach (var item in textBlocks)
		{
			item.Text = "?";
			int index = Random.Next(animals.Count);
			_randomAnimals.Add(animals[index]);
			animals.RemoveAt(index);
		}
	}

	private int _matchesFound;
	private bool _findingMatch;
	private TextBlock? _lastTextBlock;

	public void CheckIsMatch(TextBlock textBlock)
	{
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
			//Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle);

			if (_lastTextBlock.Text == textBlock.Text) // && textBlock != _lastTextBlock)
			{
				_matchesFound++;
				_findingMatch = false;
			}
			else
			{
				Thread.Sleep(1000);
				textBlock.Text = _lastTextBlock.Text = "  ?  ";
				_findingMatch = false;
				_lastTextBlock = null;
			}
		}

		if (_matchesFound == 8)
		{
			//_timer.Stop();
			//TimerText.Content += " - Play again?";
		}
	}

	//public bool IsRunning
	//{
	//	get => _startedTime != DateTime.MinValue;
	//	set
	//	{
	//		if (value)
	//		{
	//			_startedTime = DateTime.Now;
	//		}
	//		else
	//		{
	//			_endedTime = DateTime.Now;
	//		}
	//	}
	//}
}