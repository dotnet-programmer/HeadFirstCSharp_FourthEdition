namespace BeehiveManagementSystem.WPF;

internal class NectarCollector : Bee
{
	public const float NECTAR_COLLECTED_PER_SHIFT = 33.25f;
	public override float CostPerShift => 1.95f;

	public NectarCollector() : base("Zbieraczka nektaru")
	{
	}

	protected override void DoJob() => HoneyVault.CollectNectar(NECTAR_COLLECTED_PER_SHIFT);
}