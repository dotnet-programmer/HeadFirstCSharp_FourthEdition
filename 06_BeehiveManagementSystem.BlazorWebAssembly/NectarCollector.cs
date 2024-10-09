namespace _06_BeehiveManagementSystem.BlazorWebAssembly;

public class NectarCollector : Bee
{
    public const float NECTAR_COLLECTED_PER_SHIFT = 33.25f;

    public NectarCollector() : base("Nectar Collector")
    {
    }

    public override float CostPerShift
        => 1.95f;

    protected override void DoJob()
        => HoneyVault.CollectNectar(NECTAR_COLLECTED_PER_SHIFT);
}