﻿namespace BeehiveManagementSystem.WPF;

internal class HoneyManufacturer : Bee
{
	public const float NECTAR_PROCESSED_PER_SHIFT = 33.15f;
	public override float CostPerShift => 1.7f;

	public HoneyManufacturer() : base("Producentka miodu")
	{
	}

	protected override void DoJob() => HoneyVault.ConvertNectarToHoney(NECTAR_PROCESSED_PER_SHIFT);
}