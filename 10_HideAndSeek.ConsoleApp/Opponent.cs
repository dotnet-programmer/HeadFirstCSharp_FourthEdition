namespace HideAndSeek.ConsoleApp;

public class Opponent
{
	public readonly string Name;

	public Opponent(string name) => Name = name;

	public override string ToString() => Name;

	public Location Hide()
	{
		var currentLocation = House.Entry;

		var locationsToMoveThrough = House.Random.Next(10, 20);

		for (int i = 0; i < locationsToMoveThrough; i++)
		{
			currentLocation = House.RandomExit(currentLocation);
		}

		while (currentLocation is not LocationWithHidingPlace)
		{
			currentLocation = House.RandomExit(currentLocation);
		}

		(currentLocation as LocationWithHidingPlace).Hide(this);

		System.Diagnostics.Debug.WriteLine($"{Name} is hiding {(currentLocation as LocationWithHidingPlace).HidingPlace} in the {currentLocation.Name}");

		return currentLocation;
	}
}