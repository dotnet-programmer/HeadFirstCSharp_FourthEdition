﻿using System.Collections.Generic;
using BasketballRoster.WPF.Model;

namespace BasketballRoster.WPF.ViewModel;

internal class LeagueViewModel
{
	public LeagueViewModel()
	{
		var anasRoster = new Roster("The Bombers", GetBomberPlayers());
		AnasTeam = new RosterViewModel(anasRoster);

		var jimmysRoster = new Roster("The Amazins", GetAmazinPlayers());
		JimmysTeam = new RosterViewModel(jimmysRoster);
	}

	public RosterViewModel AnasTeam { get; set; }
	public RosterViewModel JimmysTeam { get; set; }

	private IEnumerable<Player> GetBomberPlayers()
		=>
		[
			new("Ana", 31, true),
			new("Lloyd", 23, true),
			new("Kathleen", 6, true),
			new("Mike", 0, true),
			new("Joe", 42, true),
			new("Herb", 32, false),
			new("Fingers", 8, false),
		];

	private IEnumerable<Player> GetAmazinPlayers()
		=>
		[
			new Player("Jimmy",42, true),
			new Player("Henry",11, true),
			new Player("Bob",4, true),
			new Player("Lucinda", 18, true),
			new Player("Kim", 16, true),
			new Player("Bertha", 23, false),
			new Player("Ed",21, false),
		];
}