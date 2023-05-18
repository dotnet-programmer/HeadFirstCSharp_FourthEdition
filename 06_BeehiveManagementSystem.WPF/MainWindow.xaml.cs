using System;
using System.Windows;
using System.Windows.Threading;

namespace BeehiveManagementSystem.WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	private readonly Queen queen;
	private readonly DispatcherTimer timer = new();

	public MainWindow()
	{
		InitializeComponent();
		queen = Resources["queen"] as Queen;
		//TxtStatusReport.Text = queen.StatusReport;
		timer.Tick += Timer_Tick;
		timer.Interval = TimeSpan.FromSeconds(1.5);
		timer.Start();
	}

	private void Timer_Tick(object? sender, EventArgs e) => BtnNextShift_Click(this, new RoutedEventArgs());

	private void BtnNextShift_Click(object sender, RoutedEventArgs e) => queen.WorkTheNextShift();//TxtStatusReport.Text = queen.StatusReport;

	private void BtnAssignJob_Click(object sender, RoutedEventArgs e) => queen.AssignBee(JobSelector.Text);//TxtStatusReport.Text = queen.StatusReport;
}