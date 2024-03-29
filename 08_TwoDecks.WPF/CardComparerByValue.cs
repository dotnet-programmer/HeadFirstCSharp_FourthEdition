using System.Collections.Generic;

namespace TwoDecks.WPF;

internal class CardComparerByValue : IComparer<Card>
{
	public int Compare(Card x, Card y)
		=> x.Suit < y.Suit 
			? -1 
			: x.Suit > y.Suit 
				? 1 
				: x.Value < y.Value 
					? -1 
					: x.Value > y.Value 
						? 1 
						: 0;
}