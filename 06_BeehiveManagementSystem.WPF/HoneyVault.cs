namespace BeehiveManagementSystem.WPF;

internal static class HoneyVault
{
	private const float NECTAR_CONVERSION_RATIO = .19f;
	private const float LOW_LEVEL_WARNING = 10f;
	private static float honey = 25f;
	private static float nectar = 100f;

	public static void CollectNectar(float amount)
	{
		if (amount > 0f)
		{
			nectar += amount;
		}
	}

	public static void ConvertNectarToHoney(float amount)
	{
		float nectarToConvert = amount;

		if (nectarToConvert > nectar)
		{
			nectarToConvert = nectar;
		}

		nectar -= nectarToConvert;
		honey += nectarToConvert * NECTAR_CONVERSION_RATIO;
	}

	public static bool ConsumeHoney(float amount)
	{
		if (honey >= amount)
		{
			honey -= amount;
			return true;
		}
		return false;
	}

	public static string StatusReport
	{
		get
		{
			string status = $"Jednostki miodu: {honey: 0.0}\nJednostki nektaru: {nectar: 0.0}";
			string warnings = string.Empty;

			if (honey < LOW_LEVEL_WARNING)
			{
				warnings += "\nNISKI POZIOM MIODU – DODAJ PRODUCENTKĘ MIODU";
			}

			if (nectar < LOW_LEVEL_WARNING)
			{
				warnings += "\nNISKI POZIOM NEKTARU – DODAJ ZBIERACZKĘ NEKTARU";
			}

			return status + warnings;
		}
	}
}