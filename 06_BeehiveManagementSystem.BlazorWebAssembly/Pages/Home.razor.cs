using System.Timers;
using Timer = System.Timers.Timer;

namespace BeehiveManagementSystem.BlazorWebAssembly.Pages;

public partial class Home
{
	private readonly Queen _queen = new();
	private string _selectedJob = "Nectar Collector";
	private Timer? _timer;

	protected override void OnInitialized()
	{
		_timer = new(1500);
		_timer.Elapsed += Timer_Tick;
		_timer.Start();
	}

	private void Timer_Tick(object? sender, ElapsedEventArgs e)
		=> InvokeAsync(() =>
			{
				_queen.WorkTheNextShift();
				StateHasChanged();
			});
}