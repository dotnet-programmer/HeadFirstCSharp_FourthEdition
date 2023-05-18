namespace HideAndSeek.ConsoleApp;

public class SavedGame
{
	public string PlayerLocation { get; set; }
	public Dictionary<string, string> OpponentLocations { get; set; }
	public List<string> FoundOpponents { get; set; }
	public int MoveNumber { get; set; }
}