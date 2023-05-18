namespace DamageCalculator.ConsoleApp;

internal class WeaponDamage
{
	public int Damage { get; protected set; }

	private int roll;
	public int Roll
	{
		get => roll;
		set
		{
			roll = value;
			CalculateDamage();
		}
	}

	private bool magic;
	public bool Magic
	{
		get => magic;
		set
		{
			magic = value;
			CalculateDamage();
		}
	}

	private bool flaming;
	public bool Flaming
	{
		get => flaming;
		set
		{
			flaming = value;
			CalculateDamage();
		}
	}

	protected virtual void CalculateDamage()
	{ /* Przesłaniana w podklasie. */ }

	public WeaponDamage(int startingRoll)
	{
		roll = startingRoll;
		CalculateDamage();
	}
}