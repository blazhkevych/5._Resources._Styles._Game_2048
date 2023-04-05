using System.Windows;
using System.Windows.Input;
using Game2048;

namespace task;

/// <summary>
///     Ресурсы. Стили. Шаблоны элементов управления.
///     Задание 1
///     Необходимо разработать игру 2048
///     Игровое поле имеет форму квадрата 4х4. Целью игры является получение плитки номиналом 2048.
///     Правила игры
///     * В каждом раунде появляется плитка номиналом 2  (с вероятностью 90%) или 4 (с вероятностью 10%).
///     * Нажатием стрелки игрок может скинуть все плитки игрового поля в одну из 4-х сторон.
///     Если при сбрасывании две плитки одного номинала «налетают» одна на другую, то они слипаются в одну,
///     номинал которой равен сумме соединившихся плиток. После каждого хода на свободной секции поля появляется
///     новая плитка номиналом 2 или 4. Если при нажатии кнопки местоположение плиток или их номинал не
///     изменится, то ход не совершается.
///     * Если в одной строчке или в одном столбце находится более двух плиток одного номинала,
///     то при сбрасывании они начинают слипаться с той стороны, в которую были направлены.
///     Например, находящиеся в одной строке плитки (4, 4, 4) после хода влево они превратятся в (8, 4),
///     а после хода вправо — в (4, 8).
///     * За каждое соединение игровые очки увеличиваются на номинал получившейся плитки.
///     * Игра заканчивается поражением, если после очередного хода невозможно совершить действие.
///     При разработке приложения необходимо использовать архитектурный шаблон проектирования MVVM.
///     Задание 2
///     Необходимо разработать окно аутентификации пользователя.
///     Для внешнего оформления элементов управления следует использовать стили и шаблоны элементов управления.
///     Resources. Styles. Control templates.
///     Exercise 1
///     Need to develop a game 2048
///     The playing field has the shape of a 4x4 square. The goal of the game is to get a tile with a face value of 2048.
///     Rules of the game
///     * In each round, a tile with a face value of 2 (with a probability of 90%) or 4 (with a probability of 10%)
///     appears.
///     * By pressing the arrow, the player can throw off all the tiles of the playing field in one of the 4 sides.
///     If, when dropped, two tiles of the same denomination “bump” one onto the other, then they stick together into one,
///     the value of which is equal to the sum of the connected tiles. After each move on the free section of the field
///     appears
///     a new tile with a value of 2 or 4. If, when the button is pressed, the location of the tiles or their value is not
///     changes, the move is not made.
///     * If there are more than two tiles of the same denomination in one line or in one column,
///     then when dropped, they begin to stick together from the side in which they were directed.
///     For example, the tiles (4, 4, 4) in the same row will turn into (8, 4) after moving to the left,
///     and after moving to the right - in (4, 8).
///     * For each connection, game points are increased by the face value of the resulting tile.
///     * The game ends in defeat if after the next move it is impossible to take an action.
///     When developing an application, the MVVM architectural design pattern must be used.
///     Task 2
///     It is necessary to develop a user authentication window.
///     Control styles and templates should be used for external appearance of controls.
/// </summary>
/// <summary>Логика взаимодействия для MainWindow.xaml</summary> 
public partial class MainWindow : Window
{
    private readonly ViewModel2048 vm;

    public MainWindow()
    {
        InitializeComponent();
        vm = (ViewModel2048)DataContext;
    }

    private void Window_KeyUp(object sender, KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Up:
                vm.NextStep(DirectionEnum.Up);
                break;
            case Key.Down:
                vm.NextStep(DirectionEnum.Down);
                break;
            case Key.Left:
                vm.NextStep(DirectionEnum.Left);
                break;
            case Key.Right:
                vm.NextStep(DirectionEnum.Right);
                break;
        }
    }
}