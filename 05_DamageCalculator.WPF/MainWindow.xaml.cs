using System;
using System.Windows;

namespace DamageCalculator.WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	private readonly Random random = new();
	private readonly SwordDamage swordDamage = new();

	public MainWindow()
	{
		InitializeComponent();
		RollDice();
	}

	private void BtnRollDice_Click(object sender, RoutedEventArgs e) => RollDice();

	public void RollDice()
	{
		swordDamage.Roll = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
		SetDamage();
	}

	private void CheckBox_Changed(object sender, RoutedEventArgs e) => SetDamage();

	private void SetDamage()
	{
		swordDamage.SetMagic(ChIsMagic.IsChecked.Value);
		swordDamage.SetFlaming(ChIsFlaming.IsChecked.Value);
		swordDamage.CalculateDamage();

		DisplayDamage();
	}

	private void DisplayDamage() => TxtDisplayDamage.Text = "Rzut: " + swordDamage.Roll + ", punkty obrażeń: " + swordDamage.Damage;
}