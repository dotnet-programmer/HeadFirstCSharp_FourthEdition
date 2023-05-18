using BasketballRoster.WPF.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace BasketballRoster.WPF.ViewModel;

//internal class RosterViewModel : INotifyPropertyChanged
internal class RosterViewModel
{
	public ObservableCollection<PlayerViewModel> Starters { get; set; }
	public ObservableCollection<PlayerViewModel> Bench { get; set; }

	private readonly Roster _roster;

	private string _teamName;
	public string TeamName
	{
		get => _teamName;
		set =>
			// OnPropertyChanged()
			_teamName = value;
	}

	//private void OnPropertyChanged(string name)
	//{
	//	PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	//}
	//public event PropertyChangedEventHandler? PropertyChanged;

	public RosterViewModel(Roster roster)
	{
		_roster = roster;

		Starters = new ObservableCollection<PlayerViewModel>();
		Bench = new ObservableCollection<PlayerViewModel>();

		TeamName = _roster.TeamName;

		UpdateRosters();
	}

	private void UpdateRosters()
	{
		var startingPlayers = _roster.Players.Where(p => p.Starter).Select(p => new PlayerViewModel(p.Name, p.Number));
		foreach (var item in startingPlayers)
		{
			Starters.Add(item);
		}

		var benchPlayers = _roster.Players.Where(p => !p.Starter).Select(p => new PlayerViewModel(p.Name, p.Number));
		foreach (var item in benchPlayers)
		{
			Bench.Add(item);
		}
	}
}