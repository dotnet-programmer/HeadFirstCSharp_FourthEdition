using System.Collections;

namespace EnumerableClass;

internal class ManualSportEnumerator : IEnumerator<Sport>
{
	private int _current = -1;

	public Sport Current 
		=> (Sport)_current;

	object IEnumerator.Current 
		=> Current;

	public void Dispose()
	{ 
		return; 
	}

	public bool MoveNext()
	{
		var maxEnumValue = Enum.GetValues(typeof(Sport)).Length;
		if (_current >= maxEnumValue - 1)
		{
			return false;
		}

		_current++;
		return true;
	}

	public void Reset() 
		=> _current = 0;
}