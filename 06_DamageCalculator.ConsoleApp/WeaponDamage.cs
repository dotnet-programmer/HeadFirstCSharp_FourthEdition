namespace DamageCalculator.ConsoleApp;

internal class WeaponDamage
{
	private int _roll;
	private bool _isMagic;
	private bool _isFlaming;

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

	public bool IsMagic
	{
		get => _isMagic;
		set
		{
			_isMagic = value;
			CalculateDamage();
		}
	}

	public bool IsFlaming
	{
		get => _isFlaming;
		set
		{
			_isFlaming = value;
			CalculateDamage();
		}
	}

	public int Damage { get; protected set; }

	protected virtual void CalculateDamage()
	{ /* Przesłaniana w podklasie. */ }
}