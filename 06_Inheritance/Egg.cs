namespace Inheritance;

internal class Egg(double size, string color)
{
	public double Size { get; private set; } = size;
	public string Color { get; private set; } = color;

	public string Description 
		=> $"{Color} jajo o wielkości {Size: 0.0} cm.";
}