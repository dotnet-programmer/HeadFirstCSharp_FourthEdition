using AbilityScoreTester.ConsoleApp;

AbilityScoreCalculator calculator = new();

while (true)
{
	calculator.RollResult = ReadInt(calculator.RollResult, "Początkowy rzut 4d6");
	calculator.DivideBy = ReadDouble(calculator.DivideBy, "Dzielone przez");
	calculator.AddAmount = ReadInt(calculator.AddAmount, "Dodawana wartość");
	calculator.Minimum = ReadInt(calculator.Minimum, "Minimum");

	calculator.CalculateAbilityScore();

	Console.WriteLine("Obliczone punkty umiejętności: " + calculator.Score);
	Console.WriteLine("Wciśnij Q, by zakończyć, lub inny klawisz, aby kontynuować");

	char keyChar = Console.ReadKey(true).KeyChar;
	if (keyChar is 'Q' or 'q')
	{
		return;
	}
}

/// <summary>
/// Wyświetla informację i wczytuje wartość typu int z konsoli.
/// </summary>
/// <param name="lastUsedValue">Wartość domyślna.</param>
/// <param name="prompt">Informacja wyświetlana w konsoli.</param>
/// <returns>Wczytana wartość int lub wartość domyślna
/// (jeśli nie można przetworzyć wczytanej wartości)</returns>
static int ReadInt(int lastUsedValue, string prompt)
{
	// Wyświetlanie informacji i [wartości domyślnej]:
	// Wczytywanie wiersza danych wyjściowych i używanie int.TryParse do próby ich przetworzenia.
	// Jeśli jest to możliwe, wyświetlanie w konsoli " użycie wartości " + value.
	// W przeciwnym razie wyświetlanie w konsoli " użycie wartości domyślnej " + lastUsedValue.

	Console.Write(prompt + " [" + lastUsedValue + "]: ");
	string line = Console.ReadLine();
	if (int.TryParse(line, out int value))
	{
		Console.WriteLine(" użycie wartości " + value);
		return value;
	}
	else
	{
		Console.WriteLine(" użycie wartości domyślnej " + lastUsedValue);
		return lastUsedValue;
	}
}

static double ReadDouble(double lastUsedValue, string prompt)
{
	Console.Write(prompt + " [" + lastUsedValue + "]: ");
	string line = Console.ReadLine();
	if (double.TryParse(line, out double value))
	{
		Console.WriteLine(" użycie wartości " + value);
		return value;
	}
	else
	{
		Console.WriteLine(" użycie wartości domyślnej " + lastUsedValue);
		return lastUsedValue;
	}
}