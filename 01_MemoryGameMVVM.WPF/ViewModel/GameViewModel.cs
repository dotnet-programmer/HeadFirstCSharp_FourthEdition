using MemoryGameMVVM.WPF.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;

namespace MemoryGameMVVM.WPF.ViewModel;

internal class GameViewModel : INotifyPropertyChanged
{
	private readonly GameModel _gameModel = new();

	public void Start() => _gameModel.Start();

	public void Stop() => _gameModel.Stop();

	public void Reset() => _gameModel.Reset();

	public string Hours => _gameModel.Elapsed.Hours.ToString("D2");
	public string Minutes => _gameModel.Elapsed.Minutes.ToString("D2");
	public string Seconds => _gameModel.Elapsed.Seconds.ToString("D2");
	public string Milliseconds => _gameModel.Elapsed.Milliseconds.ToString("D3");

	public event PropertyChangedEventHandler? PropertyChanged;

	public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

	public void SetUpGame(IEnumerable<TextBlock> textBlocks)
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

		_gameModel.SetUpGame(textBlocks, animals);
	}

	internal void CheckIsMatch(object sender)
	{
		if (sender is TextBlock textBlock)
		{
			_gameModel.CheckIsMatch(textBlock);
		}
	}
}