using System.Collections.ObjectModel;
using System.Linq;
using BasketballRoster.WPF.Model;

namespace BasketballRoster.WPF.ViewModel;

//internal class RosterViewModel : INotifyPropertyChanged
internal class RosterViewModel
{
	private readonly Roster _roster;
	private string _teamName;

	public RosterViewModel(Roster roster)
	{
		_roster = roster;

		Starters = [];
		Bench = [];

		TeamName = _roster.TeamName;

		UpdateRosters();
	}

	public string TeamName
	{
		get => _teamName;
		set =>
			// OnPropertyChanged()
			_teamName = value;
	}

	public ObservableCollection<PlayerViewModel> Bench { get; set; }
	public ObservableCollection<PlayerViewModel> Starters { get; set; }

	//private void OnPropertyChanged(string name)
	//{
	//	PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	//}
	//public event PropertyChangedEventHandler? PropertyChanged;
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