namespace SwordDamage.BlazorWebAssembly.Pages;

public partial class Home
{
	private readonly Random _random = new();
	private readonly SwordWeaponDamage _swordDamage = new(10);

	protected override void OnInitialized()
		=> RollDice();

	public void RollDice()
		=> _swordDamage.Roll = _random.Next(1, 7) + _random.Next(1, 7) + _random.Next(1, 7);
}
