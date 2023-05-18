namespace Automat;

internal class VendingMachine
{
	public virtual string Item { get; }

	protected virtual bool CheckAmount(decimal money) => false;

	public string Dispense(decimal money) => CheckAmount(money) ? Item : "Wrzuć odpowiednią kwotę";
}