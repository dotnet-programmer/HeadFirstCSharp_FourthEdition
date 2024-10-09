namespace _06_BeehiveManagementSystem.BlazorWebAssembly;

internal class HoneyManufacturer : Bee
{
    public const float NECTAR_PROCESSED_PER_SHIFT = 33.15f;

    public HoneyManufacturer() : base("Honey Manufacturer")
    {
    }

    public override float CostPerShift
        => 1.7f;

    protected override void DoJob()
        => HoneyVault.ConvertNectarToHoney(NECTAR_PROCESSED_PER_SHIFT);
}