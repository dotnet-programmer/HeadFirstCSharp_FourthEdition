namespace BeehiveManagementSystem.BlazorWebAssembly;

public static class HoneyVault
{
	private const float NECTAR_CONVERSION_RATIO = .19f;
	private const float LOW_LEVEL_WARNING = 10f;

	private static float _honey = 25f;
	private static float _nectar = 100f;

	public static string StatusReport
	{
		get
		{
			string status = $"{_honey:0.0} units of honey\n" + $"{_nectar:0.0} units of nectar";
			string warnings = "";

			if (_honey < LOW_LEVEL_WARNING)
			{
				warnings += "\nLOW HONEY - ADD A HONEY MANUFACTURER";
			}

			if (_nectar < LOW_LEVEL_WARNING)
			{
				warnings += "\nLOW NECTAR - ADD A NECTAR COLLECTOR";
			}

			return status + warnings;
		}
	}

	public static void CollectNectar(float amount)
	{
		if (amount > 0f)
		{
			_nectar += amount;
		}
	}

	public static void ConvertNectarToHoney(float amount)
	{
		float nectarToConvert = amount;
		if (nectarToConvert > _nectar)
		{
			nectarToConvert = _nectar;
		}

		_nectar -= nectarToConvert;
		_honey += nectarToConvert * NECTAR_CONVERSION_RATIO;
	}

	public static bool ConsumeHoney(float amount)
	{
		if (_honey >= amount)
		{
			_honey -= amount;
			return true;
		}
		return false;
	}
}