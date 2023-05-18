using PaintballGun.ConsoleApp;

int numberOfBalls = ReadInt(20, "Liczba kulek");
int magazineSize = ReadInt(16, "Pojemność magazynka");
Console.Write($"Załadowany[false]: ");
bool.TryParse(Console.ReadLine(), out bool isLoaded);

//PaintballGunClass gun = new();
PaintballGunClass gun = new(numberOfBalls, magazineSize, isLoaded);

while (true)
{
	//Console.WriteLine($"Kulki: {gun.GetBalls()}, załadowano: {gun.GetBallsLoaded()}");
	Console.WriteLine($"Kulki: {gun.Balls}, załadowano: {gun.BallsLoaded}");
	if (gun.IsEmpty())
	{
		Console.WriteLine("OSTRZEŻENIE: brak amunicji");
	}

	Console.WriteLine("Spacja — strzał, p — przeładowanie, " + " + — dodaj amunicję, k — koniec");
	char key = Console.ReadKey(true).KeyChar;
	if (key == ' ')
	{
		Console.WriteLine($"Próba strzału: {gun.Shoot()}");
	}
	else if (key == 'p')
	{
		gun.Reload();
	}
	else if (key == '+')
	{
		//gun.SetBalls(gun.GetBalls() + PaintballGunClass.MAGAZINE_SIZE);
		gun.Balls += gun.MagazineSize;
	}
	else if (key == 'k')
	{
		return;
	}
}

static int ReadInt(int lastUsedValue, string prompt)
{
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