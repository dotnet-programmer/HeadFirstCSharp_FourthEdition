namespace Dziedziczenie;

internal class BrokenEgg : Egg
{
	public BrokenEgg(double size, string color) : base(size, color) => Console.WriteLine("Ptak złożył pęknięte jajo.");

	public BrokenEgg(string color) : base(0, $"{color}	pęknięte ") => Console.WriteLine("Ptak złożył pęknięte jajo.");
}