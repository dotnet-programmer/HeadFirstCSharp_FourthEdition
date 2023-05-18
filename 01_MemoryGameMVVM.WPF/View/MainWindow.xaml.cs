using MemoryGameMVVM.WPF.ViewModel;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace MemoryGameMVVM.WPF.View;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	private readonly DispatcherTimer _timer = new();
	private readonly GameViewModel _gameViewModel;

	public MainWindow()
	{
		InitializeComponent();
		if (Resources["viewModel"] is GameViewModel gameViewModel)
		{
			_gameViewModel = gameViewModel;
		}
		SetTimer();

		_gameViewModel.SetUpGame(MainGrid.Children.OfType<TextBlock>().Where(x => x.Name != "TimerText"));
		_gameViewModel.Start();
		_timer.Start();

		//SetUpGame();
	}

	private void SetTimer()
	{
		_timer.Interval = TimeSpan.FromMilliseconds(100);
		_timer.Tick += Timer_Tick;
	}

	private void Timer_Tick(object? sender, EventArgs e) => _gameViewModel.OnPropertyChanged(String.Empty);

	//private int _tenthsOfSecondsElapsed;
	//Random random = new();

	//private readonly List<string> _randomAnimals = new();

	//private int _matchesFound;
	//private bool _findingMatch;
	//private TextBlock? _lastTextBlock;

	//private void Timer_Tick(object? sender, EventArgs e)
	//{
	//	_tenthsOfSecondsElapsed++;
	//	//TimerText.Content = (_tenthsOfSecondsElapsed / 10d).ToString("0.0s");
	//}

	//private void SetUpGame()
	//{
	//List<string> animals = new()
	//{
	//	"🦇", "🦇",
	//	"🐅", "🐅",
	//	"🦥", "🦥",
	//	"🦔", "🦔",
	//	"🐢", "🐢",
	//	"🐘", "🐘",
	//	"🦭", "🦭",
	//	"🦀", "🦀",
	//};

	//_randomAnimals.Clear();

	//foreach (var item in MainGrid.Children.OfType<TextBlock>().Where(x => x.Name != "TimerText"))
	//{
	//	item.Text = "?";
	//	int index = random.Next(animals.Count);
	//	_randomAnimals.Add(animals[index]);
	//	animals.RemoveAt(index);
	//}

	//StartTimer();
	//}

	//private void StartTimer()
	//{
	//_tenthsOfSecondsElapsed = 0;
	//_matchesFound = 0;
	//_timer.Start();
	//}

	private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e) => _gameViewModel.CheckIsMatch(sender);//TextBlock textBlock = sender as TextBlock;//int index = int.Parse(textBlock.Name.Substring(2));//if (!_findingMatch)//{//	_findingMatch = true;//	//textBlock.Text = _randomAnimals[index];//	_lastTextBlock = textBlock;//}//else if (textBlock != _lastTextBlock)//{//	//textBlock.Text = _randomAnimals[index];//	Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle);//	if (_lastTextBlock.Text == textBlock.Text) // && textBlock != _lastTextBlock)//	{//		_matchesFound++;//		_findingMatch = false;//	}//	else // if (textBlock != _lastTextBlock)//	{//		Thread.Sleep(1000);//		textBlock.Text = _lastTextBlock.Text = "  ?  ";//		_findingMatch = false;//		_lastTextBlock = null;//	}//}//if (_matchesFound == 8)//{//	_timer.Stop();//	//TimerText.Content += " - Play again?";//}

	private void TimerText_MouseDown(object sender, MouseButtonEventArgs e)
	{
		//if (_matchesFound == 8)
		//{
		//	//SetUpGame();
		//}
	}
}