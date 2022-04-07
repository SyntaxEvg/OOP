using Lesson7.Interface;
using Lesson7.Servic;
using System;
using System.Drawing;

namespace Lesson7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1.Определить интерфейс IСoder, который полагает методы поддержки шифрования строк. В интерфейсе объявляются два метода Encode() и Decode(), используемые для шифрования и дешифрования строк. Создать класс ACoder, реализующий интерфейс ICoder. Класс шифрует строку посредством сдвига каждого символа на одну «алфавитную» позицию выше. (В результате такого сдвига буква А становится буквой Б). Создать класс BCoder, реализующий интерфейс ICoder. Класс шифрует строку, выполняя замену каждой буквы, стоящей в алфавите на i-й позиции, на букву того же регистра, расположенную в алфавите на i-й позиции с конца алфавита. (Например, буква В заменяется на букву Э. Написать программу, демонстрирующую функционирование классов).");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("2.Создать класс Figure для работы с геометрическими фигурами. " +
                "В качестве полей класса задаются цвет фигуры, " +
                "состояние «видимое/невидимое». Реализовать операции: " +
                "передвижение геометрической фигуры по горизонтали, по вертикали, изменение цвета, " +
                "опрос состояния (видимый/невидимый). Метод вывода на экран должен выводить состояние" +
                " всех полей объекта. Создать класс Point (точка) как потомок геометрической фигуры. " +
                "Создать класс Circle (окружность) как потомок точки. В класс Circle добавить метод, " +
                "который вычисляет площадь окружности. Создать класс Rectangle (прямоугольник) " +
                "как потомок точки, реализовать метод вычисления площади прямоугольника. " +
                "Точка, окружность, прямоугольник должны поддерживать методы передвижения по горизонтали и " +
                "вертикали, изменения цвета. Подумать, какие методы можно объявить в интерфейсе, " +
                "нужно ли объявлять абстрактный класс, какие методы и поля будут в абстрактном классе, " +
                "какие методы будут виртуальными, какие перегруженными.");
            Console.ForegroundColor = ConsoleColor.Red;
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
                            IСoder();//Создать класс рациональных чисел
                            break;
                        case 2:
                            Figure();// На перегрузку операторов.
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private static void IСoder()
        {
            IСoder сoder = new ACoder();

            сoder.Encode("England’s Newest Tourist Attraction,Новейшая туристическая достопримечательность Англии", out var res);
            Console.WriteLine(res);
            сoder.Decode(res, out var decode);
            Console.WriteLine(decode);

            сoder = new BCoder();
            сoder.Encode("Lord Lucan cannot cope, Лорд Лукан не справляется",out  res);
            Console.WriteLine(res);
            сoder.Decode(res, out  decode);
            Console.WriteLine(decode);
        }
        private static void Figure()
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

      
    }
}
