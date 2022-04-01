

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("1. Создать класс рациональных чисел. В классе два поля – числитель и знаменатель. Предусмотреть конструктор. Определить операторы ==, != (метод Equals()), <, >, <=, >=, +, –, ++, --. Переопределить метод ToString() для вывода дроби. Определить операторы преобразования типов между типом дробь,float, int. Определить операторы *, /, %.");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("2. * На перегрузку операторов. Описать класс комплексных чисел. Реализовать операцию сложения, умножения, вычитания, проверку на равенство двух комплексных чисел. Переопределить метод ToString() для комплексного числа. Протестировать на простом примере.");
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
                CreateClassRationalNumbers(ref random);//Создать класс рациональных чисел
                break;
            case 2:
                OperatorOverloading(ref random);// На перегрузку операторов.
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
/// RationalNumbers
/// </summary>
void CreateClassRationalNumbers(ref Random random)
{
   
    int n = random.Next(0, 100);
    int d = random.Next(0, 100);

    var RationalNumberTyple = new RN(n, d);
    Console.WriteLine(RationalNumberTyple.ToString());
    Console.WriteLine($"== : {n == d}");
    Console.WriteLine($"!= : {n != d}");
    Console.WriteLine($"equals {n.Equals(d)}");
    Console.WriteLine($"< : {n < d}");
    Console.WriteLine($"> : {n > d}");
    Console.WriteLine($"<= : {n <= d}");
    Console.WriteLine($">= : {n >= d}");
    Console.WriteLine($"+ : {n + d}");
    Console.WriteLine($"- : {n - d}");
    Console.WriteLine($"* : {n * d}");
    Console.WriteLine($"/ : {n / d}");
    Console.WriteLine($"% : {n % d}");
    Console.WriteLine($"++: {++n}");
    Console.WriteLine($" --: {--d}");
    Console.ReadLine();
}

/// <summary>
/// Complex Numbers
/// </summary>
void OperatorOverloading(ref Random random)
{
        Console.WriteLine("Complex Numbers");
        double n = random.Next(0, 100);
        double d = random.Next(0, 100);
        var complexOne = new ComplexNumb(n, d);
         n = random.Next(0, 100);
         d = random.Next(0, 100);
        var complexTwo = new ComplexNumb(n, d);
    Console.WriteLine($"complex number: {complexOne}");
        Console.WriteLine($"+ the second: {complexOne + complexTwo}");
        Console.WriteLine($"- the second: {complexOne - complexTwo}");
        Console.WriteLine($"* the second: {complexOne * complexTwo}");
        Console.WriteLine($"equals the second: {complexOne.Equals(complexTwo)}");
        Console.WriteLine($"== the second: {complexOne == complexTwo}");
        Console.WriteLine($"equals the third: {complexOne.Equals(complexTwo)}");
        Console.WriteLine($"== the third: {complexOne == complexTwo}");
    }