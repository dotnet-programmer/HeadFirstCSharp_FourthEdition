namespace BasketballRoster.WPF.ViewModel;

internal class PlayerViewModel
{
	public string Name { get; set; }
	public int Number { get; set; }

	public PlayerViewModel(string name, int number)
	{
		Name = name;
		Number = number;
	}

	public override string ToString() => $"{Name} (#{Number})";
}