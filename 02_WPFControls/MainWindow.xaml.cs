using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFControls;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow()
		=> InitializeComponent();

	private void TbNumber_TextChanged(object sender, TextChangedEventArgs e)
		=> tbShowNumber.Text = tbNumber.Text;

	private void TbNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
	{
		if (!int.TryParse(e.Text, out _))
		{
			e.Handled = e.Text != "," || tbShowNumber.Text.Contains(',');
		}
	}

	private void SmallSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		=> tbShowNumber.Text = SmallSlider.Value.ToString("0");

	private void BigSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		=> tbShowNumber.Text = BigSlider.Value.ToString("000-000-000");

	private void RadioButton_Checked(object sender, RoutedEventArgs e)
	{
		if (sender is RadioButton rb)
		{
			tbShowNumber.Text = rb.Content.ToString();
		}
	}

	private void MyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (MyListBox.SelectedItem is ListBoxItem listBoxItem)
		{
			tbShowNumber.Text = listBoxItem.Content.ToString();
		}
	}

	private void ReadOnlyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (ReadOnlyComboBox.SelectedItem is ComboBoxItem comboBoxItem)
		{
			tbShowNumber.Text = comboBoxItem.Content.ToString();
		}
	}

	private void EditableComboBox_TextChanged(object sender, TextChangedEventArgs e)
	{
		if (sender is ComboBox comboBox)
		{
			tbShowNumber.Text = comboBox.Text;
		}
	}
}