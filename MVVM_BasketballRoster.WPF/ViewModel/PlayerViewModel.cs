namespace BasketballRoster.WPF.ViewModel;

internal class PlayerViewModel(string name, int number)
{
	public string Name { get; set; } = name;
	public int Number { get; set; } = number;

	public override string ToString() 
		=> $"{Name} (#{Number})";
}