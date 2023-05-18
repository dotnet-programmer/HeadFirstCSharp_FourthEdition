namespace TestJsonSerializer;

internal class Guy
{
	public string Name { get; set; }
	public HairStyle Hair { get; set; }
	public Outfit Clothes { get; set; }

	public override string ToString() => $"{Name} ma {Hair} i nosi {Clothes}.";
}