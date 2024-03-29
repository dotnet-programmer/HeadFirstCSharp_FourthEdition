using System.Diagnostics;

namespace DamageCalculatorV2.WPF;

internal class SwordDamage
{
	private const int BASE_DAMAGE = 3;
	private const int FLAME_DAMAGE = 2;

	private int _roll;
	private bool _isMagic;
	private bool _isFlaming;

	public SwordDamage(int startingRoll)
	{
		_roll = startingRoll;
		CalculateDamage();
	}

	public int Damage { get; private set; }

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

	private void CalculateDamage()
	{
		decimal magicMultiplier = IsMagic ? 1.75M : 1M;
		int flameDamage = IsFlaming ? FLAME_DAMAGE : 0;
		Damage = (int)(Roll * magicMultiplier) + flameDamage + BASE_DAMAGE;
		Debug.WriteLine("Jestem w CalculateDamage");
	}
}