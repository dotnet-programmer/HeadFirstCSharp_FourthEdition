using System;
using System.Windows.Input;

namespace MemoryGameMVVM.WPF.Commands;

internal class RelayCommand(Action<object> execute, Predicate<object>? canExecute = null) : ICommand
{
	private readonly Action<object> _execute = execute ?? throw new ArgumentNullException(nameof(execute));
	private readonly Predicate<object>? _canExecute = canExecute;

	public event EventHandler? CanExecuteChanged
	{
		add => CommandManager.RequerySuggested += value;
		remove => CommandManager.RequerySuggested -= value;
	}

	public void Execute(object? parameter)
		=> _execute(parameter);

	public bool CanExecute(object? parameter)
		=> _canExecute == null || _canExecute(parameter);
}