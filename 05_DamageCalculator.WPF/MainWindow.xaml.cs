using System;
using System.Windows;

namespace DamageCalculator.WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	private readonly Random _random = new();
	private readonly SwordDamage _swordDamage = new();

	public MainWindow()
	{
		InitializeComponent();
		RollDice();
	}

	public void RollDice()
	{
		_swordDamage.Roll = _random.Next(1, 7) + _random.Next(1, 7) + _random.Next(1, 7);
		SetDamage();
	}

	private void BtnRollDice_Click(object sender, RoutedEventArgs e)
		=> RollDice();

	private void CheckBox_Changed(object sender, RoutedEventArgs e)
		=> SetDamage();

	private void SetDamage()
	{
		_swordDamage.SetMagic(ChIsMagic.IsChecked.Value);
		_swordDamage.SetFlaming(ChIsFlaming.IsChecked.Value);
		_swordDamage.CalculateDamage();

		DisplayDamage();
	}

	private void DisplayDamage()
		=> TxtDisplayDamage.Text = "Rzut: " + _swordDamage.Roll + ", punkty obrażeń: " + _swordDamage.Damage;
}