using Lesson2;
using System.Drawing;

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("1. Для класса банковский счет переопределить операторы == " +
    "и != для сравнения информации в двух счетах. Переопределить метод Equals аналогично оператору ==," +
    " не забыть переопределить метод GetHashCode(). Переопределить методToString() " +
    "для печати информации о счете. Протестировать функционирование переопределенных " +
    "методов и операторов на простом примере.");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("2. Создать класс Figure для работы с геометрическими фигурами. " +
    "В качестве полей класса задаются цвет фигуры, состояние «видимое/невидимое». " +
    "Реализовать операции: передвижение геометрической фигуры по горизонтали, по вертикали, " +
    "изменение цвета, опрос состояния (видимый/невидимый). Метод вывода на экран должен выводить" +
    " состояние всех полей объекта. Создать класс Point (точка) как потомок геометрической фигуры. " +
    "Создать класс Circle (окружность) как потомок точки. В класс Circle добавить метод, " +
    "который вычисляет площадь окружности. Создать класс Rectangle (прямоугольник) как потомок точки, " +
    "реализовать метод вычисления площади прямоугольника. Точка, окружность, прямоугольник должны " +
    "поддерживать методы передвижения по горизонтали и вертикали, изменения цвета.");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("6. Выход");
Console.ForegroundColor = ConsoleColor.White;
Random random = new Random();
while (true)
{
    var temp = Console.ReadLine();
    int count = 0;
    int.TryParse(temp, out count);
    if (count != 0)
    {
        switch (count)
        {
            case 1:
                ComparinginformationAccounts(ref random);//Создать класс рациональных чисел
                break;
            case 2:
                CreateFigureGeometricShapes();// На перегрузку операторов.
                break;
            case 6:
                Environment.Exit(0);
                break;
            default:
                break;
        }
    }
}



/// <summary>
///  Для класса банковский счет переопределить операторы ==
/// </summary>
void ComparinginformationAccounts(ref Random random)
{
    var Sum = 100;
    var Sum2 = 1020;
    var client1 = new BankAccount(Sum, AccountType.Deposit, "user1");
    var client2 = new BankAccount(Sum2, AccountType.Deposit, "user2");
    Console.WriteLine($"client1 == client2 {client1 == client2}");
    Console.WriteLine($"client1 != client2 {client1 != client2}");
    Console.WriteLine($"client1 equals client2 {client1.Equals(client2)}");
}
/// <summary>
/// работа с фигурами
/// </summary>
void CreateFigureGeometricShapes()
{
    var pointCenter = new System.Drawing.Point() { X = 0, Y = 0 };
    var circleCenter = new System.Drawing.Point() { X = 3, Y = 3 };
    var rectangleCenter = new System.Drawing.Point() { X = 5, Y = 5 };
    var isVisible = true;

    var point = new Point(Color.Red, isVisible, pointCenter);
    double radius = 10;
    var circle = new Circle(Color.Blue, !isVisible, circleCenter, radius);
    var width = 10;
    var height = 5;
    var rectangle = new Rectangle(Color.Green, isVisible, rectangleCenter, width, height);

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(point);
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine(circle); 
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(rectangle);
    Console.ForegroundColor = ConsoleColor.White;
    var horizontalOffset = 1;
    point.MoveHorizontal(horizontalOffset);
    Console.WriteLine($"{horizontalOffset}");
    Console.WriteLine(point);

    var newRadius = 3;
    var newColor = Color.Lime;
    var verticalOffset = -1;
    circle.ChangeRadius(newRadius);
    circle.ChangeColor(newColor);
    circle.MoveVertical(verticalOffset);
    Console.WriteLine($"Переместите круг (0, {verticalOffset})" +
        $" Измените цвет на {newColor}." +
        $" Измените радиус на {newRadius}");
    Console.WriteLine(circle);
    rectangle.ChangeHeight(rectangle.Width);
    rectangle.MoveHorizontal(horizontalOffset);
    rectangle.MoveVertical(verticalOffset);
    rectangle.ChangeColor(newColor);
    Console.WriteLine($"Переместите прямоугольник в ({horizontalOffset}, {verticalOffset}). Измените цвет на {newColor}. Изменить высоту на {rectangle.Width}");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(rectangle);
    Console.ReadKey();
}