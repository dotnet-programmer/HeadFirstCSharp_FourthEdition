using System;
using System.ComponentModel;

namespace BeehiveManagementSystem.WPF;

internal class Queen : Bee, INotifyPropertyChanged
{
	public const float EGGS_PER_SHIFT = 0.45f;
	public const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;

	private Bee[] _workers = [];
	private float _eggs = 0;
	private float _unassignedWorkers = 3;

	public Queen() : base("Królowa")
	{
		AssignBee("Zbieraczka nektaru");
		AssignBee("Producentka miodu");
		AssignBee("Opiekunka jaj");
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	public string StatusReport { get; private set; }

	public override float CostPerShift 
		=> 2.15f;

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

	public void CareForEggs(float eggsToConvert)
	{
		if (_eggs >= eggsToConvert)
		{
			_eggs -= eggsToConvert;
			_unassignedWorkers += eggsToConvert;
		}
	}

	protected void OnPropertyChanged(string name) 
		=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

	protected override void DoJob()
	{
		_eggs += EGGS_PER_SHIFT;
		foreach (Bee worker in _workers)
		{
			worker.WorkTheNextShift();
		}
		HoneyVault.ConsumeHoney(_unassignedWorkers * HONEY_PER_UNASSIGNED_WORKER);
		UpdateStatusReport();
	}

	private void AddWorker(Bee worker)
	{
		if (_unassignedWorkers >= 1)
		{
			_unassignedWorkers--;
			Array.Resize(ref _workers, _workers.Length + 1);
			_workers[^1] = worker;
		}
	}

	private void UpdateStatusReport()
	{
		StatusReport = $"Raport o stanie skarbca:\n{HoneyVault.StatusReport}\n"
				 + $"\nLiczba jaj: {_eggs: 0.0}\n"
				 + $"Nieprzydzielone robotnice: {_unassignedWorkers: 0.0}\n"
				 + $"{WorkerStatus("Zbieraczka nektaru")}\n{WorkerStatus("Producentka miodu")}"
				 + $"\n{WorkerStatus("Opiekunka jaj")}\nROBOTNICE W SUMIE: {_workers.Length}";
		OnPropertyChanged(nameof(StatusReport));
	}

	private string WorkerStatus(string job)
	{
		int count = 0;
		foreach (Bee worker in _workers)
		{
			if (worker.Job == job)
			{
				count++;
			}
		}

		return $"{job}: {count}";
	}
}