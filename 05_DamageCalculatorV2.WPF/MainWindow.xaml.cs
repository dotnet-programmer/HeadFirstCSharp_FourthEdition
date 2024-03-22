using System;
using System.Windows;

namespace DamageCalculatorV2.WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	private readonly Random _random = new();
	private readonly SwordDamage _swordDamage;

	public MainWindow()
	{
		InitializeComponent();
		_swordDamage = new SwordDamage(_random.Next(1, 7) + _random.Next(1, 7) + _random.Next(1, 7));
		DisplayDamage();
	}

	public void RollDice()
	{
		_swordDamage.Roll = _random.Next(1, 7) + _random.Next(1, 7) + _random.Next(1, 7);
		DisplayDamage();
	}

	private void DisplayDamage() 
		=> TxtDisplayDamage.Text = $"Rzut: {_swordDamage.Roll}, punkty obrażeń: {_swordDamage.Damage}";

	private void Button_Click(object sender, RoutedEventArgs e) 
		=> RollDice();

	private void Flaming_Checked(object sender, RoutedEventArgs e)
	{
		_swordDamage.Flaming = true;
		DisplayDamage();
	}

	private void Flaming_Unchecked(object sender, RoutedEventArgs e)
	{
		_swordDamage.Flaming = false;
		DisplayDamage();
	}

	private void Magic_Checked(object sender, RoutedEventArgs e)
	{
		_swordDamage.Magic = true;
		DisplayDamage();
	}

	private void Magic_Unchecked(object sender, RoutedEventArgs e)
	{
		_swordDamage.Magic = false;
		DisplayDamage();
	}
}