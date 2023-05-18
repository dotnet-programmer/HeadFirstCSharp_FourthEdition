using System;
using System.Windows;

namespace DamageCalculatorV2.WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	private readonly Random random = new();
	private readonly SwordDamage swordDamage;

	public MainWindow()
	{
		InitializeComponent();
		swordDamage = new SwordDamage(random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7));
		DisplayDamage();
	}

	public void RollDice()
	{
		swordDamage.Roll = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
		DisplayDamage();
	}

	private void DisplayDamage() => TxtDisplayDamage.Text = $"Rzut: {swordDamage.Roll}, punkty obrażeń: {swordDamage.Damage}";

	private void Button_Click(object sender, RoutedEventArgs e) => RollDice();

	private void Flaming_Checked(object sender, RoutedEventArgs e)
	{
		swordDamage.Flaming = true;
		DisplayDamage();
	}

	private void Flaming_Unchecked(object sender, RoutedEventArgs e)
	{
		swordDamage.Flaming = false;
		DisplayDamage();
	}

	private void Magic_Checked(object sender, RoutedEventArgs e)
	{
		swordDamage.Magic = true;
		DisplayDamage();
	}

	private void Magic_Unchecked(object sender, RoutedEventArgs e)
	{
		swordDamage.Magic = false;
		DisplayDamage();
	}
}