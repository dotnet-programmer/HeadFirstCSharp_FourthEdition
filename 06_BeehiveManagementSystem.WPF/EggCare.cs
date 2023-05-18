namespace BeehiveManagementSystem.WPF;

internal class EggCare : Bee
{
	public const float CARE_PROGRESS_PER_SHIFT = 0.15f;
	public override float CostPerShift => 1.35f;
	private readonly Queen queen;

	public EggCare(Queen queen) : base("Opiekunka jaj") => this.queen = queen;

	protected override void DoJob() => queen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
}