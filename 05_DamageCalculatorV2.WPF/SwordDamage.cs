using System.Diagnostics;

namespace DamageCalculatorV2.WPF;

internal class SwordDamage
{
	private const int BASE_DAMAGE = 3;
	private const int FLAME_DAMAGE = 2;

	/// <summary>
	/// Zawiera obliczone obrażenia.
	/// </summary>
	public int Damage { get; private set; }

	private int roll;
	/// <summary>
	/// Ustawia lub pobiera wartość rzutu 3d6.
	/// </summary>
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
	/// <summary>
	/// Zwraca true, jeśli miecz jest magiczny; w przeciwnym razie zwraca false.
	/// </summary>
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
	/// <summary>
	/// Zwraca true, jeśli miecz jest płonący; w przeciwnym razie zwraca false.
	/// </summary>
	public bool Flaming
	{
		get => flaming;
		set
		{
			flaming = value;
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

	/// <summary>
	/// Konstruktor oblicza obrażenia na podstawie domyślnych wartości właściwości
	/// Magic i Flaming oraz początkowego rzutu 3d6.
	/// </summary>
	/// <param name=”startingRoll”>Początkowy rzut 3d6</param>
	public SwordDamage(int startingRoll)
	{
		roll = startingRoll;
		CalculateDamage();
	}
}