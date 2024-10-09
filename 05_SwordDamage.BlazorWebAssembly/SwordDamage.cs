namespace _05_SwordDamage.BlazorWebAssembly;

public class SwordDamage
{
	private const int BASE_DAMAGE = 3;
	private const int FLAME_DAMAGE = 2;

	private int _roll;
	private bool _magic;
	private bool _flaming;

	/// <summary>
	/// The constructor calculates damage based on default Magic
	/// and Flaming values and a starting 3d6 roll.
	/// </summary>
	/// <param name="startingRoll">Starting 3d6 roll</param>
	public SwordDamage(int startingRoll)
	{
		_roll = startingRoll;
		CalculateDamage();
	}

	/// <summary>
	/// Contains the calculated damage.
	/// </summary>
	public int Damage { get; private set; }

	/// <summary>
	/// Sets or gets the 3d6 roll.
	/// </summary>
	public int Roll
	{
		get => _roll;
		set
		{
			_roll = value;
			CalculateDamage();
		}
	}

	/// <summary>
	/// True if the sword is magic, false otherwise.
	/// </summary>
	public bool Magic
	{
		get => _magic;
		set
		{
			_magic = value;
			CalculateDamage();
		}
	}

	/// <summary>
	/// True if the sword is flaming, false otherwise.
	/// </summary>
	public bool Flaming
	{
		get => _flaming;
		set
		{
			_flaming = value;
			CalculateDamage();
		}
	}

	/// <summary>
	/// Calculates the damage based on the current properties.
	/// </summary>
	private void CalculateDamage()
	{
		decimal magicMultiplier = Magic ? 1.75M : 1M;

		Damage = BASE_DAMAGE;
		Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE;

		if (Flaming)
		{
			Damage += FLAME_DAMAGE;
		}
	}
}