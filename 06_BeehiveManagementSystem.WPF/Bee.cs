namespace BeehiveManagementSystem.WPF;

internal class Bee(string job)
{
	public virtual float CostPerShift { get; }

	public string Job { get; private set; } = job;

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