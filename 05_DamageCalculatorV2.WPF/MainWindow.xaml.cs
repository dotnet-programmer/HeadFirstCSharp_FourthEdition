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
		_swordDamage = new SwordDamage(RollDice());
		DisplayDamage();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		_swordDamage.Roll = RollDice();
		DisplayDamage();
	}

	private void Flaming_Checked(object sender, RoutedEventArgs e)
	{
		_swordDamage.IsFlaming = true;
		DisplayDamage();
	}

	private void Flaming_Unchecked(object sender, RoutedEventArgs e)
	{
		_swordDamage.IsFlaming = false;
		DisplayDamage();
	}

	private void Magic_Checked(object sender, RoutedEventArgs e)
	{
		_swordDamage.IsMagic = true;
		DisplayDamage();
	}

	private void Magic_Unchecked(object sender, RoutedEventArgs e)
	{
		_swordDamage.IsMagic = false;
		DisplayDamage();
	}

	private int RollDice()
		=> _random.Next(1, 7) + _random.Next(1, 7) + _random.Next(1, 7);

	private void DisplayDamage()
		=> TxtDisplayDamage.Text = $"Rzut: {_swordDamage.Roll}, punkty obrażeń: {_swordDamage.Damage}";
}