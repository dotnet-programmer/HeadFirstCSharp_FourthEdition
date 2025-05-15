using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Controls.BlazorWebAssembly.Pages;

public partial class Home
{
	private string? _displayValue;

	private void UpdateValue(ChangeEventArgs e)
		=> _displayValue = e.Value?.ToString();

	private void UpdateNumericValue(ChangeEventArgs e)
	{
		if (int.TryParse(e.Value?.ToString(), out _))
		{
			_displayValue = e.Value.ToString();
		}
	}

	private void ButtonClick(string displayValue)
		=> _displayValue = displayValue;
}