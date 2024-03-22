namespace BeehiveManagementSystem.WPF;

internal class EggCare(Queen queen) : Bee("Opiekunka jaj")
{
	public const float CARE_PROGRESS_PER_SHIFT = 0.15f;

	private readonly Queen _queen = queen;

	public override float CostPerShift
		=> 1.35f;

	protected override void DoJob()
		=> _queen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
}