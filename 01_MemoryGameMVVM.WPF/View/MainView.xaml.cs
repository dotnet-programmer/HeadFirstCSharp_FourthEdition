using System.Windows;
using MemoryGameMVVM.WPF.ViewModels;

namespace MemoryGameMVVM.WPF.View;

/// <summary>
/// Interaction logic for MainView.xaml
/// </summary>
public partial class MainView : Window
{
	public MainView()
	{
		InitializeComponent();
		DataContext = new MainViewModel(MainGrid);
	}
}