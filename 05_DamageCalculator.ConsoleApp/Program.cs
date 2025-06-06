﻿using DamageCalculator.ConsoleApp;

Random random = new();
SwordDamage swordDamage = new();

while (true)
{
	Console.Write("0 — ani magiczny, ani płonący; 1 — magiczny; 2 — płonący; 3 — magiczny i płonący; inne wartości — koniec: ");
	char key = Console.ReadKey().KeyChar;
	if (key is not '0' and not '1' and not '2' and not '3')
	{
		return;
	}

	swordDamage.Roll = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
	swordDamage.SetMagic(key is '1' or '3');
	swordDamage.SetFlaming(key is '2' or '3');
	swordDamage.CalculateDamage();

	Console.WriteLine("\nRzut: " + swordDamage.Roll + ", punkty obrażeń: " + swordDamage.Damage + "\n");
}