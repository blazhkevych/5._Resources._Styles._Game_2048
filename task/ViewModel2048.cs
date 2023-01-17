using System.Collections.Generic;
using System.ComponentModel;

namespace Game2048;

/// <summary>Класс ViewModel для игры 2048</summary>
public class ViewModel2048 : OnPropertyChangedClass
{
    private IEnumerable<Cell> _cells;

    private Model2048 model;

    private readonly List<string> modelProperties = new()
    {
        nameof(Model2048.CountEmptyCell), nameof(Model2048.IsGameOver), nameof(Model2048.MaxValue),
        nameof(Model2048.SumValue)
    };

    /// <summary>Безпараметричесий конструтор</summary>
    public ViewModel2048()
    {
        RestartCommand = new RelayCommand(par => ReStart());
        ReStart();
    }

    /// <summary>Общий построчный набор ячеек</summary>
    public IEnumerable<Cell> Cells
    {
        get => _cells;
        private set
        {
            _cells = value;
            OnPropertyChanged(null);
        }
    }

    /// <summary>Количество пустых ячеек</summary>
    public int CountEmptyCell => model.CountEmptyCell;

    /// <summary>Игра закончена</summary>
    public bool IsGameOver => model.IsGameOver;

    /// <summary>Ячейка с максимальным значением</summary>
    public int MaxValue => model.MaxValue;

    /// <summary>Сумма значений всех ячеек</summary>
    public int SumValue => model.SumValue;

    /// <summary>Команда для создания новой игры</summary>
    public RelayCommand RestartCommand { get; }

    /// <summary>Следующий шаг (раунд) -  сдвиг в задданом направлени</summary>
    /// <param name="direction"></param>
    public void NextStep(DirectionEnum direction)
    {
        if (IsGameOver)
            return;

        model.Step(direction);
    }

    private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        var propertyName = e.PropertyName;
        if (string.IsNullOrEmpty(propertyName) || modelProperties.IndexOf(propertyName) >= 0)
            OnPropertyChanged(propertyName);
    }

    /// <summary>Создание новой игры</summary>
    private void ReStart()
    {
        if (model != null)
            model.PropertyChanged -= Model_PropertyChanged;
        model = new Model2048();
        model.PropertyChanged += Model_PropertyChanged;
        var cells = new List<Cell>();
        foreach (var rowCells in model.GetCells())
        foreach (var cell in rowCells)
            cells.Add(cell);
        Cells = cells;
        NextStep(DirectionEnum.None);
        NextStep(DirectionEnum.None);
    }
}