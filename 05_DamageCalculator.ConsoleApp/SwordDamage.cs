namespace DamageCalculator.ConsoleApp;

internal class SwordDamage
{
	private const int BASE_DAMAGE = 3;
	private const int FLAME_DAMAGE = 2;
	private const decimal MAGIC_MULTIPLIER = 1.75M;

	private bool _isMagic = false;
	private bool _isFlaming = false;

	public int Damage;
	public int Roll;

	public void SetMagic(bool isMagic)
		=> _isMagic = isMagic;

	public void SetFlaming(bool isFlaming)
		=> _isFlaming = isFlaming;

	public void CalculateDamage()
	{
		Damage = _isMagic
			? (int)(Roll * MAGIC_MULTIPLIER) + BASE_DAMAGE
			: Roll + BASE_DAMAGE;

		if (_isFlaming)
		{
			Damage += FLAME_DAMAGE;
		}
	}
}