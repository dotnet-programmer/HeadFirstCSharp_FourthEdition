namespace Sandwiches.BlazorWebAssembly.Pages;

public partial class Home
{
	private readonly MenuItem[] _menuItems = new MenuItem[5];
	private string? _guacamolePrice;

	protected override void OnInitialized()
	{
		for (int i = 0; i < 5; i++)
		{
			_menuItems[i] = new MenuItem();
			if (i >= 3)
			{
				_menuItems[i].Breads = ["zwykły rogal", "rogal cebulowy", "rogal z pumpernikla", "rogal z wszystkim"];
			}
			_menuItems[i].Generate();
		}

		MenuItem guacamoleMenuItem = new();
		guacamoleMenuItem.Generate();
		_guacamolePrice = guacamoleMenuItem.Price;
	}
}
