namespace JimmyLinq;

using System.Collections.Generic;
using System.Linq;

public static class ComicAnalyzer
{
	private static PriceRange CalculatePriceRange(Comic comic, IReadOnlyDictionary<int, decimal> prices)
		=> prices[comic.Issue] < 100
			? PriceRange.Cheap
			: PriceRange.Expensive;

	//IEnumerable<IGrouping<PriceRange, Comic>> grouped =
	//   from comic in comics
	//   orderby prices[comic.Issue]
	//   group comic by CalculatePriceRange(comic, prices) into priceGroup
	//   select priceGroup;
	public static IEnumerable<IGrouping<PriceRange, Comic>> GroupComicsByPrice(IEnumerable<Comic> comics, IReadOnlyDictionary<int, decimal> prices)
		=> comics
			.OrderBy(c => prices[c.Issue])
			.GroupBy(c => CalculatePriceRange(c, prices));

	//var joined =
	//   from comic in comics
	//   orderby comic.Issue
	//   join review in reviews on comic.Issue equals review.Issue
	//   select $"{review.Critic} rated #{comic.Issue} '{comic.Name}' {review.Score:0.00}";
	public static IEnumerable<string> GetReviews(IEnumerable<Comic> comics, IEnumerable<Review> reviews)
		=> comics
			.OrderBy(c => c.Issue)
			.Join(
				reviews,
				c => c.Issue,
				r => r.Issue,
				(comic, review) => $"{review.Critic} rated #{comic.Issue} '{comic.Name}' {review.Score:0.00}");
}