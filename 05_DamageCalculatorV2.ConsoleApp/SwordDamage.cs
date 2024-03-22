using System.Diagnostics;

namespace DamageCalculatorV2.ConsoleApp;

internal class SwordDamage
{
	private const int BASE_DAMAGE = 3;
	private const int FLAME_DAMAGE = 2;

	private int _roll;
	private bool _magic;
	private bool _flaming;

	/// <summary>
	/// Konstruktor oblicza obrażenia na podstawie domyślnych wartości właściwości
	/// Magic i Flaming oraz początkowego rzutu 3d6.
	/// </summary>
	/// <param name=”startingRoll”>Początkowy rzut 3d6</param>
	public SwordDamage(int startingRoll)
	{
		_roll = startingRoll;
		CalculateDamage();
	}

	/// <summary>
	/// Zawiera obliczone obrażenia.
	/// </summary>
	public int Damage { get; private set; }

	/// <summary>
	/// Ustawia lub pobiera wartość rzutu 3d6.
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
	/// Zwraca true, jeśli miecz jest magiczny; w przeciwnym razie zwraca false.
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
	/// Zwraca true, jeśli miecz jest płonący; w przeciwnym razie zwraca false.
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
	/// Oblicza obrażenia na podstawie aktualnych wartości właściwości.
	/// </summary>
	private void CalculateDamage()
	{
		decimal magicMultiplier = 1M;
		if (Magic)
		{
			magicMultiplier = 1.75M;
		}

		Damage = BASE_DAMAGE;
		Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE;
		if (Flaming)
		{
			Damage += FLAME_DAMAGE;
		}
		Debug.WriteLine("Jestem w CalculateDamage");
	}
}