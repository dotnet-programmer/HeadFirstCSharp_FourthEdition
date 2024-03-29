namespace DamageCalculator.ConsoleApp;

internal class ArrowDamage(int startingRoll) : WeaponDamage(startingRoll)
{
	private const decimal BASE_MULTIPLIER = 0.35M;
	private const decimal MAGIC_MULTIPLIER = 2.5M;
	private const decimal FLAME_DAMAGE = 1.25M;

	protected override void CalculateDamage()
	{
		decimal baseDamage = Roll * BASE_MULTIPLIER;
		if (IsMagic)
		{
			baseDamage *= MAGIC_MULTIPLIER;
		}
		if (IsFlaming)
		{
			baseDamage += FLAME_DAMAGE;
		}
		Damage = (int)Math.Ceiling(baseDamage);
	}
}