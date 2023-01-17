using System;
using System.Windows.Input;

namespace Game2048;

#region Делегаты для методов WPF команд

public delegate void ExecuteHandler(object parameter);

public delegate bool CanExecuteHandler(object parameter);

#endregion

/// <summary>Класс реализующий интерфейс ICommand для создания WPF команд</summary>
public class RelayCommand : ICommand
{
    private readonly CanExecuteHandler _canExecute;
    private readonly ExecuteHandler _onExecute;

    /// <summary>Конструктор команды</summary>
    /// <param name="execute">Выполняемый метод команды</param>
    /// <param name="canExecute">Метод разрешающий выполнение команды</param>
    public RelayCommand(ExecuteHandler execute, CanExecuteHandler canExecute = null)
    {
        _onExecute = execute;
        _canExecute = canExecute;
    }

    /// <summary>Событие извещающее об измении состояния команды</summary>
    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }


    /// <summary>Вызов разрешающего метода команды</summary>
    /// <param name="parameter">Параметр команды</param>
    /// <returns>True - если выполнение команды разрешено</returns>
    public bool CanExecute(object parameter)
    {
        return _canExecute == null ? true : _canExecute.Invoke(parameter);
    }

    /// <summary>Вызов выполняющего метода команды</summary>
    /// <param name="parameter">Параметр команды</param>
    public void Execute(object parameter)
    {
        _onExecute?.Invoke(parameter);
    }
}