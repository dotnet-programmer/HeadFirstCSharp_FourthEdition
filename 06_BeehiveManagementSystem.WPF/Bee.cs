namespace BeehiveManagementSystem.WPF;

internal class Bee
{
	public virtual float CostPerShift { get; }
	public string Job { get; private set; }

	public Bee(string job) => Job = job;

	public void WorkTheNextShift()
	{
		if (HoneyVault.ConsumeHoney(CostPerShift))
		{
			DoJob();
		}
	}

	protected virtual void DoJob()
	{ /* przesłaniana w podklasie */ }
}