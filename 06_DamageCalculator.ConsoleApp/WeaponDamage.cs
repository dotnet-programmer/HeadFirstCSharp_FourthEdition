namespace DamageCalculator.ConsoleApp;

internal class WeaponDamage
{
	private int _roll;
	private bool _magic;
	private bool _flaming;

	public WeaponDamage(int startingRoll)
	{
		_roll = startingRoll;
		CalculateDamage();
	}

	public int Roll
	{
		get => _roll;
		set
		{
			_roll = value;
			CalculateDamage();
		}
	}

	public bool Magic
	{
		get => _magic;
		set
		{
			_magic = value;
			CalculateDamage();
		}
	}

	public bool Flaming
	{
		get => _flaming;
		set
		{
			_flaming = value;
			CalculateDamage();
		}
	}

	public int Damage { get; protected set; }

	protected virtual void CalculateDamage()
	{ /* Przesłaniana w podklasie. */ }
}