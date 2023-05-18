using System.Collections;

namespace EnumerableClass;

internal class BetterSportSequence : IEnumerable<Sport>
{
	public IEnumerator<Sport> GetEnumerator()
	{
		int maxEnumValue = Enum.GetValues(typeof(Sport)).Length - 1;
		for (int i = 0; i <= maxEnumValue; i++)
		{
			yield return (Sport)i;
		}
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	public Sport this[int index] => (Sport)index;
}