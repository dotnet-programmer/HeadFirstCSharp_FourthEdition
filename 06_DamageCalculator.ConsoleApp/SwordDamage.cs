namespace DamageCalculator.ConsoleApp;

internal class SwordDamage(int startingRoll) : WeaponDamage(startingRoll)
{
	public const int BASE_DAMAGE = 3;
	public const int FLAME_DAMAGE = 2;

	protected override void CalculateDamage()
	{
		decimal magicMultiplier = IsMagic ? 1.75M : 1M;
		int isFlaming = IsFlaming ? FLAME_DAMAGE : 0;
		Damage = (int)(Roll * magicMultiplier) + isFlaming + BASE_DAMAGE;
	}
}