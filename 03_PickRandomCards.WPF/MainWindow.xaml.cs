using System.Windows;

namespace PickRandomCards.WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow()
		=> InitializeComponent();

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		string[] pickedCards = CardPicker.PickSomeCards((int)NumberOfCards.Value);
		ListOfCards.Items.Clear();
		foreach (string card in pickedCards)
		{
			ListOfCards.Items.Add(card);
		}
	}
}