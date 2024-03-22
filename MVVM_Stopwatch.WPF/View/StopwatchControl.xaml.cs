using Stopwatch.ConsoleApp.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Stopwatch.WPF.View;

/// <summary>
/// Interaction logic for StopwatchControl.xaml
/// </summary>
public partial class StopwatchControl : UserControl
{
	private readonly DispatcherTimer _timer = new();
	private readonly StopwatchViewModel _stopwatchViewModel;

	public StopwatchControl()
	{
		InitializeComponent();

		_stopwatchViewModel = Resources["viewModel"] as StopwatchViewModel;

		_timer.Interval = TimeSpan.FromMilliseconds(50);
		_timer.Tick += TimerTick;
		_timer.Start();
	}

	private void TimerTick(object sender, EventArgs e) 
		=> _stopwatchViewModel.OnPropertyChanged(String.Empty);

	private void StartStopButton_Click(object sender, RoutedEventArgs e) 
		=> _stopwatchViewModel.StartStop();

	private void ResetButton_Click(object sender, RoutedEventArgs e) 
		=> _stopwatchViewModel.Reset();

	private void LapButton_Click(object sender, RoutedEventArgs e) 
		=> _stopwatchViewModel.LapTime();
}