using System.Timers;
using Timer = System.Timers.Timer;

namespace MatchGame.BlazorWebAssembly.Pages;

public partial class Home
{
	private readonly List<string> _animalEmoji =
	[
		"🐶","🐶",
		"🐺","🐺",
		"🐮","🐮",
		"🦊","🦊",
		"🐱","🐱",
		"🦁","🦁",
		"🐯","🐯",
		"🐹","🐹",
	];

	private List<string> _shuffledAnimals = [];
	private Timer? _timer;
	private int _matchesFound;
	private int _tenthsOfSecondsElapsed;
	private string _timeDisplay = string.Empty;
	private string _lastAnimalFound = string.Empty;
	private string _lastDescription = string.Empty;

	protected override void OnInitialized()
	{
		_timer = new Timer(100);
		_timer.Elapsed += TimerTick;
		SetUpGame();
	}

	private void SetUpGame()
	{
		Random random = new();
		_shuffledAnimals = _animalEmoji
			.OrderBy(item => random.Next())
			.ToList();

		_matchesFound = 0;
		_tenthsOfSecondsElapsed = 0;
	}

	private void ButtonClick(string animal, string animalDescription)
	{
		// Pierwsze kliknięcie w parze. Należy je zapamiętać.
		if (_lastAnimalFound == string.Empty)
		{
			_lastAnimalFound = animal;
			_lastDescription = animalDescription;

			_timer?.Start();
		}
		// Znaleziono dopasowanie! Resetowanie, aby móc utworzyć następną parę.
		else if ((animal == _lastAnimalFound) && (animalDescription != _lastDescription))
		{
			_lastAnimalFound = string.Empty;

			// Zastępowanie znalezionych zwierząt pustym łańcuchem znaków w celu ukrycia emoji.
			_shuffledAnimals = _shuffledAnimals
				.Select(a => a.Replace(animal, string.Empty))
				.ToList();

			_matchesFound++;
			if (_matchesFound == 8)
			{
				_timer?.Stop();
				_timeDisplay += " - Jeszcze raz?";

				SetUpGame();
			}
		}
		// Użytkownik zaznaczył parę niedopasowanych emoji, resetowanie zaznaczonych emoji.
		else
		{
			_lastAnimalFound = string.Empty;
		}
	}

	private void TimerTick(object? sender, ElapsedEventArgs e)
		=> InvokeAsync(() =>
		{
			_tenthsOfSecondsElapsed++;
			_timeDisplay = (_tenthsOfSecondsElapsed / 10F).ToString("0.0s");
			StateHasChanged();
		});
}