using System.Collections;

namespace EnumerableClass;

internal class ManualSportSequence : IEnumerable<Sport>
{
	public IEnumerator<Sport> GetEnumerator() => new ManualSportEnumerator();

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}