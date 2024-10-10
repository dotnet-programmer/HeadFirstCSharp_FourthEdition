namespace HideAndSeek.ConsoleApp;

/// <summary>
/// Constructor that sets the location name and hiding place name
/// </summary>
/// <param name="name">Name of the location</param>
/// <param name="hidingPlace">Hiding place</param>
public class LocationWithHidingPlace(string name, string hidingPlace) : Location(name)
{
	// <summary>
	/// The name of the hiding place in this location
	/// </summary>
	public readonly string HidingPlace = hidingPlace;

	/// <summary>
	/// The opponents hidden in this location's hiding place
	/// </summary>
	private readonly List<Opponent> _hiddenOpponents = [];

	/// <summary>
	/// Hides an opponent in the hiding place
	/// </summary>
	/// <param name="opponent">Opponent to hide</param>
	public void Hide(Opponent opponent)
		=> _hiddenOpponents.Add(opponent);

	/// <summary>
	/// Checks the hiding place to see if any opponents are there
	/// </summary>
	/// <returns>Any opponents that were found, clearing the hiding place</returns>
	public IEnumerable<Opponent> CheckHidingPlace()
	{
		var foundOpponents = new List<Opponent>(_hiddenOpponents);
		_hiddenOpponents.Clear();
		return foundOpponents;
	}
}