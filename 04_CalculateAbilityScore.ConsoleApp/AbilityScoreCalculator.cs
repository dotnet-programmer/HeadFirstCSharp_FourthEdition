namespace AbilityScoreTester.ConsoleApp;

internal class AbilityScoreCalculator
{
	public double DivideBy = 1.75;
	public int RollResult = 14;
	public int AddAmount = 2;
	public int Minimum = 3;
	public int Score;

	public void CalculateAbilityScore()
	{
		// Dzielenie wyniku rzutu przez pole DivideBy
		double divided = RollResult / DivideBy;

		// Dodawanie AddAmount do wyniku dzielenia
		int added = (int)divided + AddAmount;

		// Jeśli wynik jest za niski, użyj Minimum
		Score = added < Minimum ? Minimum : added;
	}
}