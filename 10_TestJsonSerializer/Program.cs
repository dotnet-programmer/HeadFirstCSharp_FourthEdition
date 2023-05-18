using System.Text.Json;
using TestJsonSerializer;

var guys = new List<Guy>() {
	new Guy() {
		Name = "Borys", Clothes = new Outfit() { Top = "t-shirt", Bottom = "dżinsy" },
		Hair = new HairStyle() { Color = HairColor.czerwone, Length = 8.9f }
	},
	new Guy() {
		Name = "Jonasz", Clothes = new Outfit() { Top = "polo", Bottom = "spodnie" },
		Hair = new HairStyle() { Color = HairColor.szare, Length = 6.8f }
	},
};

var jsonString1 = JsonSerializer.Serialize(guys);
var jsonString2 = JsonSerializer.Serialize(guys, new JsonSerializerOptions() { WriteIndented = true });

Console.WriteLine(jsonString1);
Console.WriteLine();
Console.WriteLine(jsonString2);

var copyOfGuys1 = JsonSerializer.Deserialize<List<Guy>>(jsonString1);
var copyOfGuys2 = JsonSerializer.Deserialize<List<Guy>>(jsonString2);
foreach (var guy in copyOfGuys1)
{
	Console.WriteLine("Wykonałem deserializację tego faceta: {0}", guy);
}

Console.WriteLine();
foreach (var guy in copyOfGuys2)
{
	Console.WriteLine("Wykonałem deserializację tego faceta: {0}", guy);
}

Console.WriteLine();

Console.WriteLine(JsonSerializer.Serialize(3));
Console.WriteLine(JsonSerializer.Serialize((long)-3));
Console.WriteLine(JsonSerializer.Serialize((byte)0));
Console.WriteLine(JsonSerializer.Serialize(float.MaxValue));
Console.WriteLine(JsonSerializer.Serialize(float.MinValue));
Console.WriteLine(JsonSerializer.Serialize(true));
Console.WriteLine(JsonSerializer.Serialize("Słoń"));
Console.WriteLine(JsonSerializer.Serialize("Słoń".ToCharArray()));
Console.WriteLine(JsonSerializer.Serialize(" "));