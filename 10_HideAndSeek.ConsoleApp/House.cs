namespace HideAndSeek.ConsoleApp;

public static class House
{
	/// <summary>
	/// Returns the starting location for the player
	/// </summary>
	public static readonly Location Entry;

	/// <summary>
	/// The instance of Random used to choose random lcations
	/// </summary>
	public static Random Random = new();

	/// <summary>
	/// Private collection of locations in the house
	/// </summary>
	private static readonly IEnumerable<Location> _locations;

	/// <summary>
	/// Sets up the house data structure
	/// </summary>
	static House()
	{
		Entry = new Location("Entry");
		var hallway = new Location("Hallway");
		var livingRoom = new LocationWithHidingPlace("Living Room", "behind the sofa");
		var kitchen = new LocationWithHidingPlace("Kitchen", "next to the stove");
		var bathroom = new LocationWithHidingPlace("Bathroom", "behind the door");
		var landing = new Location("Landing");
		var masterBedroom = new LocationWithHidingPlace("Master Bedroom", "in the closet");
		var masterBath = new LocationWithHidingPlace("Master Bath", "in the bathtub");
		var secondBathroom = new LocationWithHidingPlace("Second Bathroom", "in the shower");
		var kidsRoom = new LocationWithHidingPlace("Kids Room", "under the bed");
		var nursery = new LocationWithHidingPlace("Nursery", "under the crib");
		var pantry = new LocationWithHidingPlace("Pantry", "inside a cabinet");
		var attic = new LocationWithHidingPlace("Attic", "in a trunk");
		var garage = new LocationWithHidingPlace("Garage", "behind the car");

		Entry.AddExit(Direction.East, hallway);
		Entry.AddExit(Direction.Out, garage);
		hallway.AddExit(Direction.Northwest, kitchen);
		hallway.AddExit(Direction.North, bathroom);
		hallway.AddExit(Direction.South, livingRoom);
		hallway.AddExit(Direction.Up, landing);
		landing.AddExit(Direction.Northwest, masterBedroom);
		landing.AddExit(Direction.West, secondBathroom);
		landing.AddExit(Direction.Southwest, nursery);
		landing.AddExit(Direction.South, pantry);
		landing.AddExit(Direction.Southeast, kidsRoom);
		landing.AddExit(Direction.Up, attic);
		masterBedroom.AddExit(Direction.East, masterBath);

		// Add all of the locations to the private locations collection
		_locations = [
			Entry,
			hallway,
			kitchen,
			bathroom,
			livingRoom,
			landing,
			masterBedroom,
			secondBathroom,
			kidsRoom,
			nursery,
			pantry,
			attic,
			garage,
			attic,
			masterBath,
		];
	}

	/// <summary>
	/// Gets a location by name
	/// </summary>
	/// <param name="name">The name of the location to find</param>
	/// <returns>The location, or Entry if no location by that name was found</returns>
	public static Location GetLocationByName(string location)
		=> _locations.Any(x => x.Name == location) ? _locations.First(x => x.Name == location) : Entry;

	//public static Location RandomExit(Location location) => location.Exits.ElementAt(Random.Next(location.Exits.Count)).Value;

	/// <summary>
	/// Gets a random exit from the location
	/// </summary>
	/// <param name="location">Location to get the random exit from</param>
	/// <returns>One of the locatin's exits selected randomly</returns>
	public static Location RandomExit(Location location)
		=> GetLocationByName(
			location
				.Exits
				.OrderBy(exit => exit.Value.Name)
				.Select(exit => exit.Value.Name)
				.Skip(Random.Next(0, location.ExitList.Count()))
				.First());

	/// <summary>
	/// Check each hiding place to make sure no opponents are still hiding
	/// to reset the house between rounds (or tests)
	/// </summary>
	public static void ClearHidingPlaces()
	{
		foreach (var location in _locations)
		{
			if (location is LocationWithHidingPlace hidingPlace)
			{
				hidingPlace.CheckHidingPlace();
			}
		}
	}
}