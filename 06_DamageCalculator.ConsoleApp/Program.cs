using DamageCalculator.ConsoleApp;

Random random = new();

SwordDamage swordDamage = new(RollDice(3));
ArrowDamage arrowDamage = new(RollDice(1));

while (true)
{
	Console.Write("0 - ani magiczny, ani płonący, 1 - magiczny, 2 - płonący, 3 - magiczny i płonący, inne klawisze - koniec: ");
	char key = Console.ReadKey().KeyChar;
	if (key is not '0' and not '1' and not '2' and not '3')
	{
		return;
	}

	Console.Write("\nM - miecz, S - strzały, inne klawisze - koniec: ");
	char weaponKey = Char.ToUpper(Console.ReadKey().KeyChar);
	switch (weaponKey)
	{
		case 'M':
			swordDamage.Roll = RollDice(3);
			swordDamage.IsMagic = (key is '1' or '3');
			swordDamage.IsFlaming = (key is '2' or '3');
			Console.WriteLine(
			$"\nRzut {swordDamage.Roll}, punkty obrażeń {swordDamage.Damage} \n");
			break;

		case 'S':
			arrowDamage.Roll = RollDice(1);
			arrowDamage.IsMagic = (key is '1' or '3');
			arrowDamage.IsFlaming = (key is '2' or '3');
			Console.WriteLine(
			$"\nRzut: {arrowDamage.Roll}, punkty obrażeń {arrowDamage.Damage}\n");
			break;

		default:
			return;
	}
}

int RollDice(int numberOfRolls)
{
	int total = 0;
	for (int i = 0; i < numberOfRolls; i++)
	{
		total += random.Next(1, 7);
	}

	return total;
}