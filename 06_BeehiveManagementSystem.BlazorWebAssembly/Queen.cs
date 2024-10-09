namespace _06_BeehiveManagementSystem.BlazorWebAssembly;

public class Queen : Bee
{
    public const float EGGS_PER_SHIFT = 0.45f;
    public const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;

    private Bee[] _workers = [];
    private float _eggs = 0;
    private float _unassignedWorkers = 3;

    public Queen() : base("Queen")
    {
        AssignBee("Nectar Collector");
        AssignBee("Honey Manufacturer");
        AssignBee("Egg Care");
    }

    public string StatusReport { get; private set; } = string.Empty;

    public override float CostPerShift
        => 2.15f;

    public void CareForEggs(float eggsToConvert)
    {
        if (_eggs >= eggsToConvert)
        {
            _eggs -= eggsToConvert;
            _unassignedWorkers += eggsToConvert;
        }
    }

    public void AssignBee(string job)
    {
        switch (job)
        {
            case "Nectar Collector":
                AddWorker(new NectarCollector());
                break;
            case "Honey Manufacturer":
                AddWorker(new HoneyManufacturer());
                break;
            case "Egg Care":
                AddWorker(new EggCare(this));
                break;
        }
        UpdateStatusReport();
    }

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
            _workers[_workers.Length - 1] = worker;
        }
    }

    private void UpdateStatusReport()
            => StatusReport = $"Vault report:\n{HoneyVault.StatusReport}\n" +
            $"\nEgg count: {_eggs:0.0}\nUnassigned workers: {_unassignedWorkers:0.0}\n" +
            $"{WorkerStatus("Nectar Collector")}\n{WorkerStatus("Honey Manufacturer")}" +
            $"\n{WorkerStatus("Egg Care")}\nTOTAL WORKERS: {_workers.Length}";

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

        string s = "s";
        if (count == 1)
        {
            s = "";
        }

        return $"{count} {job} bee{s}";
    }
}