using Stopwatch.ConsoleApp.Model;
using System.ComponentModel;

namespace Stopwatch.ConsoleApp.ViewModel;

public class StopwatchViewModel : INotifyPropertyChanged
{
	public void StartStop() => _model.Running = !_model.Running;

	public void Reset() => _model.Reset();

	public void LapTime() => _model.SetLapTime();

	public string Hours => _model.Elapsed.Hours.ToString("D2");
	public string Minutes => _model.Elapsed.Minutes.ToString("D2");
	public string Seconds => _model.Elapsed.Seconds.ToString("D2");
	public object Tenths => _model.Elapsed.Milliseconds.ToString("D3");

	public object LapHours => _model.LapTime.Hours.ToString("D2");
	public object LapMinutes => _model.LapTime.Minutes.ToString("D2");
	public object LapSeconds => _model.LapTime.Seconds.ToString("D2");
	public object LapTenths => _model.LapTime.Milliseconds.ToString("D3");

	private readonly StopwatchModel _model = new();

	public event PropertyChangedEventHandler? PropertyChanged;

	public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}