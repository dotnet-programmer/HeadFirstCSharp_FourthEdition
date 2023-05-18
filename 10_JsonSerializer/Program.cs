using JsonSerializer;

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

var jsonString = System.Text.Json.JsonSerializer.Serialize(guys);
Console.WriteLine(jsonString);