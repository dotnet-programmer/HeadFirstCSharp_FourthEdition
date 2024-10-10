﻿using System.Text.Json;

namespace HideAndSeek.ConsoleApp;

public class GameController
{
	/// <summary>
	/// Private list of opponents the player needs to find
	/// </summary>
	public readonly IEnumerable<Opponent> Opponents =
	[
		new("Joe"),
		new("Bob"),
		new("Ana"),
		new("Owen"),
		new("Jimmy"),
	];

	/// <summary>
	/// Private list of opponents the player has found so far
	/// </summary>
	private readonly List<Opponent> _foundOpponents = [];

	/// <summary>
	/// A Dictionary to keep track of the opponent locations
	/// </summary>
	private readonly Dictionary<string, string> _opponentLocations = [];

	public GameController()
	{
		House.ClearHidingPlaces();
		foreach (var opponent in Opponents)
		{
			opponent.Hide();
		}

		CurrentLocation = House.Entry;
	}

	/// <summary>
	/// The number of moves the player has made
	/// </summary>
	public int MoveNumber { get; private set; } = 1;

	/// <summary>
	/// The player's current location in the house
	/// </summary>
	public Location CurrentLocation { get; private set; }

	/// <summary>
	/// Returns true if the game is over
	/// </summary>
	public bool GameOver
		=> Opponents.Count() == _foundOpponents.Count;

	/// <summary>
	/// Returns the the current status to show to the player
	/// </summary>
	public string Status
	{
		get
		{
			var found = _foundOpponents.Count() == 0
				? "You have not found any opponents"
				: $"You have found {_foundOpponents.Count()} of {Opponents.Count()} opponents: {string.Join(", ", _foundOpponents.Select(o => o.Name))}";

			var hidingPlace = (CurrentLocation is LocationWithHidingPlace location)
				? $"{Environment.NewLine}Someone could hide {location.HidingPlace}"
				: "";

			return $"You are in the {CurrentLocation}. You see the following exits:" + Environment.NewLine +
				$" - {string.Join(Environment.NewLine + " - ", CurrentLocation.ExitList)}{hidingPlace}" +
				$"{Environment.NewLine}{found}";
		}
	}

	/// <summary>
	/// A prompt to display to the player
	/// </summary>
	public string Prompt
		=> $"{MoveNumber}: Which direction do you want to go (or type 'check'): ";

	/// <summary>
	/// Move to the location in a direction
	/// </summary>
	/// <param name="direction">The direction to move</param>
	/// <returns>True if the player can move in that direction, false oterwise</returns>
	public bool Move(Direction direction)
	{
		var oldLocation = CurrentLocation;
		CurrentLocation = CurrentLocation.GetExit(direction);
		return (oldLocation != CurrentLocation);
	}

	/// <summary>
	/// Parses input from the player and updates the status
	/// </summary>
	/// <param name="input">Input to parse</param>
	/// <returns>The results of parsing the input</returns>
	public string ParseInput(string input)
	{
		var results = "That's not a valid direction";

		if (input.ToLower().StartsWith("save "))
		{
			var filename = input.Substring(5);
			results = Save(filename);
		}
		else if (input.ToLower().StartsWith("load "))
		{
			var filename = input.Substring(5);
			results = Load(filename);
		}
		else if (input.ToLower() == "check")
		{
			MoveNumber++;
			if (CurrentLocation is LocationWithHidingPlace locationWithHidingPlace)
			{
				var found = locationWithHidingPlace.CheckHidingPlace();
				if (found.Count() == 0)
				{
					results = $"Nobody was hiding {locationWithHidingPlace.HidingPlace}";
				}
				else
				{
					_foundOpponents.AddRange(found);
					var s = found.Count() == 1 ? "" : "s";
					results = $"You found {found.Count()} opponent{s} hiding {locationWithHidingPlace.HidingPlace}";
				}
			}
			else
			{
				results = $"There is no hiding place in the {CurrentLocation}";
			}
		}
		else if (Enum.TryParse(typeof(Direction), input, out object direction))
		{
			if (!Move((Direction)direction))
			{
				results = "There's no exit in that direction";
			}
			else
			{
				MoveNumber++;
				results = $"Moving {direction}";
			}
		}
		return results;
	}

	/// <summary>
	/// Save a game to a file
	/// </summary>
	/// <param name="filename">Name of the file (without extension)</param>
	/// <returns>Results of the save to display to the player</returns>
	public string Save(string filename)
	{
		if (filename.Contains("/") || filename.Contains("\\") || filename.Contains(" "))
		{
			return "Please enter a filename without slashes or spaces.";
		}
		else
		{
			var savedGame = new SavedGame()
			{
				PlayerLocation = CurrentLocation.Name,
				OpponentLocations = _opponentLocations,
				FoundOpponents = _foundOpponents.Select(opponent => opponent.Name).ToList(),
				MoveNumber = this.MoveNumber,
			};

			var json = JsonSerializer.Serialize<SavedGame>(savedGame);
			File.WriteAllText($"{filename}.json", json);
			return $"Saved current game to {filename}";
		}
	}

	/// <summary>
	/// Load a game from a file
	/// </summary>
	/// <param name="filename">Name of the file (without extension)</param>
	/// <returns>Results of the save to display to the player</returns>
	public string Load(string filename)
	{
		if (filename.Contains("/") || filename.Contains("\\") || filename.Contains(" "))
		{
			return "Please enter a filename without slashes or spaces.";
		}
		else if (!File.Exists($"{filename}.json"))
		{
			return "That save file does not exist.";
		}
		else
		{
			var json = File.ReadAllText($"{filename}.json");
			var savedGame = JsonSerializer.Deserialize<SavedGame>(json);
			House.ClearHidingPlaces();
			CurrentLocation = House.GetLocationByName(savedGame.PlayerLocation);
			foreach (var opponentName in savedGame.OpponentLocations.Keys)
			{
				var opponent = new Opponent(opponentName);
				var locationName = savedGame.OpponentLocations[opponentName];
				if (House.GetLocationByName(locationName) is LocationWithHidingPlace location)
				{
					location.Hide(opponent);
				}
			}
			_foundOpponents.Clear();
			_foundOpponents.AddRange(savedGame.FoundOpponents.Select(name => new Opponent(name)));
			MoveNumber = savedGame.MoveNumber;
			return $"Loaded game from {filename}";
		}
	}
}