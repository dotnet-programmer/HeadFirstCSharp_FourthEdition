using System;
using System.Windows;
using System.Windows.Threading;

namespace BeehiveManagementSystem.WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	private readonly Queen _queen;
	private readonly DispatcherTimer _timer = new();

	public MainWindow()
	{
		InitializeComponent();
		_queen = Resources["queen"] as Queen;
		//TxtStatusReport.Text = queen.StatusReport;
		_timer.Tick += Timer_Tick;
		_timer.Interval = TimeSpan.FromSeconds(1.5);
		_timer.Start();
	}

	private void Timer_Tick(object? sender, EventArgs e) 
		=> BtnNextShift_Click(this, new RoutedEventArgs());

	private void BtnNextShift_Click(object sender, RoutedEventArgs e) 
		=> _queen.WorkTheNextShift();//TxtStatusReport.Text = queen.StatusReport;

	private void BtnAssignJob_Click(object sender, RoutedEventArgs e) 
		=> _queen.AssignBee(JobSelector.Text);//TxtStatusReport.Text = queen.StatusReport;
}