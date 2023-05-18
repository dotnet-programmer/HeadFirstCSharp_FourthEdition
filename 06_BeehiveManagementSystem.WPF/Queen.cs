using System;
using System.ComponentModel;

namespace BeehiveManagementSystem.WPF;

internal class Queen : Bee, INotifyPropertyChanged
{
	public const float EGGS_PER_SHIFT = 0.45f;
	public const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;
	private Bee[] workers = Array.Empty<Bee>();
	private float eggs = 0;
	private float unassignedWorkers = 3;

	public event PropertyChangedEventHandler? PropertyChanged;

	protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

	public string StatusReport { get; private set; }
	public override float CostPerShift => 2.15f;

	public Queen() : base("Królowa")
	{
		AssignBee("Zbieraczka nektaru");
		AssignBee("Producentka miodu");
		AssignBee("Opiekunka jaj");
	}

	public void AssignBee(string job)
	{
		switch (job)
		{
			case "Zbieraczka nektaru":
				AddWorker(new NectarCollector());
				break;

			case "Producentka miodu":
				AddWorker(new HoneyManufacturer());
				break;

			case "Opiekunka jaj":
				AddWorker(new EggCare(this));
				break;
		}
		UpdateStatusReport();
	}

	private void AddWorker(Bee worker)
	{
		if (unassignedWorkers >= 1)
		{
			unassignedWorkers--;
			Array.Resize(ref workers, workers.Length + 1);
			workers[^1] = worker;
		}
	}

	private void UpdateStatusReport()
	{
		StatusReport = $"Raport o stanie skarbca:\n{HoneyVault.StatusReport}\n"
				 + $"\nLiczba jaj: {eggs: 0.0}\n"
				 + $"Nieprzydzielone robotnice: {unassignedWorkers: 0.0}\n"
				 + $"{WorkerStatus("Zbieraczka nektaru")}\n{WorkerStatus("Producentka miodu")}"
				 + $"\n{WorkerStatus("Opiekunka jaj")}\nROBOTNICE W SUMIE: {workers.Length}";
		OnPropertyChanged(nameof(StatusReport));
	}

	public void CareForEggs(float eggsToConvert)
	{
		if (eggs >= eggsToConvert)
		{
			eggs -= eggsToConvert;
			unassignedWorkers += eggsToConvert;
		}
	}

	private string WorkerStatus(string job)
	{
		int count = 0;
		foreach (Bee worker in workers)
		{
			if (worker.Job == job)
			{
				count++;
			}
		}

		return $"{job}: {count}";
	}

	protected override void DoJob()
	{
		eggs += EGGS_PER_SHIFT;
		foreach (Bee worker in workers)
		{
			worker.WorkTheNextShift();
		}
		HoneyVault.ConsumeHoney(unassignedWorkers * HONEY_PER_UNASSIGNED_WORKER);
		UpdateStatusReport();
	}
}