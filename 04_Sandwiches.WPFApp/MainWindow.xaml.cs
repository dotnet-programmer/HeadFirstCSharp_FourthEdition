using System.Windows;

namespace Sandwiches.WPFApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
		MakeTheMenu();
	}

	private void MakeTheMenu()
	{
		MenuItem[] menuItems = new MenuItem[5];
		string guacamolePrice;
		for (int i = 0; i < 5; i++)
		{
			menuItems[i] = new MenuItem();
			if (i >= 3)
			{
				menuItems[i].Breads = ["zwykły rogal", "rogal cebulowy", "rogal z pumpernikla", " rogal z wszystkim"];
			}
			menuItems[i].Generate();
		}
		Item1.Text = menuItems[0].Description;
		Price1.Text = menuItems[0].Price;
		Item2.Text = menuItems[1].Description;
		Price2.Text = menuItems[1].Price;
		Item3.Text = menuItems[2].Description;
		Price3.Text = menuItems[2].Price;
		Item4.Text = menuItems[3].Description;
		Price4.Text = menuItems[3].Price;
		Item5.Text = menuItems[4].Description;
		Price5.Text = menuItems[4].Price;

		MenuItem specialMenuItem = new()
		{
			Proteins = ["Szynka organiczna", "Burger z grzybów", " Mortadella"],
			Breads = ["bułka bezglutenowa", "tortilla", "pita"],
			Condiments = ["musztarda diżońska", "sos z miso", "au jus"]
		};
		specialMenuItem.Generate();
		Item6.Text = specialMenuItem.Description;
		Price6.Text = specialMenuItem.Price;

		MenuItem guacamoleMenuItem = new();
		guacamoleMenuItem.Generate();
		guacamolePrice = guacamoleMenuItem.Price;
		Guacamole.Text = "Dodaj guacamole za " + guacamolePrice;
	}
}