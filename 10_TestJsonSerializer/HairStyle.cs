namespace TestJsonSerializer;

internal class HairStyle
{
	public HairColor Color { get; set; }
	public float Length { get; set; }

	public override string ToString() => $"{Color} włosy o długości {Length:0.0} cm ";
}