//1.Создать класс счет в банке с закрытыми полями: номер счета, баланс, тип банковского счета (использовать перечислимый тип). Предусмотреть методы для доступа к данным – заполнения и чтения. Создать объект класса, заполнить его поля и вывести информацию об объекте класса на печать.
//2. Изменить класс счет в банке из упражнения таким образом, чтобы номер счета генерировался сам и был уникальным. Для этого надо создать в классе статическую переменную и метод, который увеличивает значение этого переменной.
//3. В классе банковский счет удалить методы заполнения полей. Вместо этих методов создать конструкторы. Переопределить конструктор по умолчанию, создать конструктор для заполнения поля баланс, конструктор для заполнения поля тип банковского счета, конструктор для заполнения баланса и типа банковского счета. Каждый конструктор должен вызывать метод, генерирующий номер счета.
//4. В классе все методы для заполнения и получения значений полей заменить на свойства. Написать тестовый пример.
//5. * Добавить в класс счет в банке два метода: снять со счета и положить на счет. Метод снять со счета проверяет, возможно ли снять запрашиваемую сумму, и в случае положительного результата изменяет баланс.


using Lesson2;

Console.WriteLine("Сумма для пополнения");
int.TryParse(Console.ReadLine(), out var Sum);
if (Sum>0)
{

    Dictionary<int,Enum> AccountTypeList = new();
    int number=0;
    foreach (Enum items in Enum.GetValues(typeof(AccountType)))
    {
        if (!AccountTypeList.ContainsKey(number))
        {
            AccountTypeList.Add(number, items);
            Console.WriteLine($"{items.ToString()}");
        }
        number++;   
    }
    Console.WriteLine($"Какой тип счета открыть из  {AccountTypeList.Count()}");
    int.TryParse(Console.ReadLine(), out var num);

    if (num>-1 && AccountTypeList.ContainsKey(num))
    {
        var client = new BankAccount(Sum, (AccountType)AccountTypeList[num]);
        Console.WriteLine(client.ToString());
        client.PutMoney(Sum);//положим еще монет) 
        Console.WriteLine($"Тек. баланс {client.Balance}");
        client.SpendMoney(50);// потратить  50
        Console.WriteLine($"Тек. баланс {client.Balance}");

    }

    Console.WriteLine();

    AccountTypeList.Clear();
}

Console.ReadLine();
