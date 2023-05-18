using System.Collections.Generic;

namespace BasketballRoster.WPF.Model;

internal class Roster
{
	private readonly List<Player> _players = new();

	public string TeamName { get; private set; }

	public IEnumerable<Player> Players => new List<Player>(_players);

	public Roster(string teamName, IEnumerable<Player> players)
	{
		TeamName = teamName;
		_players.AddRange(players);
	}
}