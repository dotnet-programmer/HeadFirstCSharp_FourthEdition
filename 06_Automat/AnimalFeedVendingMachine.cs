namespace Automat;

internal class AnimalFeedVendingMachine : VendingMachine
{
	public override string Item => "Garść karmy dla zwierząt";

	protected override bool CheckAmount(decimal money) => money >= 1.25M;
}