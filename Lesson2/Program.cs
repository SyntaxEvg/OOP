//1.Создать класс счет в банке с закрытыми полями: номер счета, баланс, тип банковского счета (использовать перечислимый тип). Предусмотреть методы для доступа к данным – заполнения и чтения. Создать объект класса, заполнить его поля и вывести информацию об объекте класса на печать.
//2. Изменить класс счет в банке из упражнения таким образом, чтобы номер счета генерировался сам и был уникальным. Для этого надо создать в классе статическую переменную и метод, который увеличивает значение этого переменной.
//3. В классе банковский счет удалить методы заполнения полей. Вместо этих методов создать конструкторы. Переопределить конструктор по умолчанию, создать конструктор для заполнения поля баланс, конструктор для заполнения поля тип банковского счета, конструктор для заполнения баланса и типа банковского счета. Каждый конструктор должен вызывать метод, генерирующий номер счета.
//4. В классе все методы для заполнения и получения значений полей заменить на свойства. Написать тестовый пример.
//5. * Добавить в класс счет в банке два метода: снять со счета и положить на счет. Метод снять со счета проверяет, возможно ли снять запрашиваемую сумму, и в случае положительного результата изменяет баланс.


using Lesson2;
using Lesson2.Less3._3;
using Lesson2.StringExtension;
using System.Text.RegularExpressions;

Console.WriteLine("Выбрать ЗД от 1 до 3 или 6- если хотите выйти из программы");
Console.WriteLine("[1]В класс банковский счет, созданный в упражнениях, добавить метод, который переводит деньги с одного счета на другой. У метода два параметра: ссылка на объект класса банковский счет откуда снимаются деньги, второй параметр – сумма.");
Console.WriteLine("[2]Реализовать метод, который в качестве входного параметра принимает строку string, возвращает строку типа string, буквы в которой идут в обратном порядке. Протестировать метод.");
Console.WriteLine("[3]Работа со строками. Дан текстовый файл, содержащий ФИО и e-mail адрес. Разделителем между ФИО и адресом электронной почты является символ &: Кучма Андрей Витальевич & Kuchma@mail.ru Мизинцев Павел Николаевич & Pasha@mail.ru Сформировать новый файл, содержащий список адресов электронной почты. Предусмотреть метод, выделяющий из строки адрес почты. Методу в качестве параметра передается символьная строка s, e-mail возвращается в той же строке s: public void SearchMail (ref string s).");

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
                BankAccount();
                break;
            case 2:
                RisversArrayList();
                break;
            case 3:
                FileStream();
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
/// Урок 3, занятие 2
/// </summary>
void RisversArrayList()
{
    Console.WriteLine("Введите строку, которую надо перевернуть");
    string str = Console.ReadLine();
    if (str.Length>0 )
    {       
        Console.WriteLine(str.RString());
    }  
}
/// <summary>
/// Урок 3, занятие 3
/// </summary>
void FileStream()
{
    //Работа со строками. Дан текстовый файл, содержащий ФИО и e-mail адрес.
    List<string> EmailParse = new List<string>();
    var PuthFolder= $"{Environment.CurrentDirectory}\\Less3.3\\Data\\";
    var Str= new ReadLineFile().ReadLine($"{PuthFolder}\\Data.txt");

    Regex regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    string nameFileSaveEmail = $"{PuthFolder}\\DataEmail.txt";
    foreach (string item in Str.Where((x)=> x.Length>0 && x.Contains("& ")))
    {
        var strSplit =item.Split("& ");
        if (strSplit.Length>0 )
        {
           var strLastIsEmail= strSplit.Last();
            if (regex.Match(strLastIsEmail).Success)
            {
                File.AppendAllText(nameFileSaveEmail, strLastIsEmail + Environment.NewLine);
            }
            else
            {
                Console.WriteLine("Email: {0} not valid.", strLastIsEmail);
            }
        }
        else
        {
            Console.WriteLine("bag str.", item);
        }
    }

}

/// <summary>
/// Урок 3, занятие 1
/// </summary>
void BankAccount()
{
    Dictionary<int, Enum> AccountTypeList = new();
    int number = 0;
    Dictionary<Guid, BankAccount> ListClientBD = new();
    foreach (Enum items in Enum.GetValues(typeof(AccountType)))
    {
        if (!AccountTypeList.ContainsKey(number))
        {
            AccountTypeList.Add(number, items);
            Console.WriteLine($"{items.ToString()}");
        }
        number++;
    }
    Console.WriteLine("Создать Аккаунт, Введи имя и нажмите enter,для отмены Tab");
    while (true)
    {
        Console.WriteLine("Введи имя");
        if (Console.ReadKey().Key == ConsoleKey.Tab)
        {
            break;
        }
        var name = Console.ReadLine();
        if (name?.Length > 2)
        {
            Console.WriteLine($"Какой тип счета открыть из (отчет от 0) {AccountTypeList.Count()}");
            int.TryParse(Console.ReadLine(), out var num);
            if (num > -1 && AccountTypeList.ContainsKey(num))
            {
                Console.WriteLine("Сумма для пополнения");
                int.TryParse(Console.ReadLine(), out var Sum);
                if (Sum > 0)
                {
                    var client = new BankAccount(Sum, (AccountType)AccountTypeList[num], name);
                    Console.WriteLine($"Создан {name},баланс пополнен на {Sum}, можно создать  еще клиента, или выйти");
                    Console.WriteLine(client.ToString());

                    if (!ListClientBD.ContainsKey(client.AccountNumber))
                    {
                        ListClientBD.Add(client.AccountNumber, client);
                    }
                    else
                    {
                        Console.WriteLine("Клиент есть в базе");
                    }

                }
            }
        }
    }
    Console.WriteLine("Выбрать клиента и проивести возможные действия");
    int i = 0;
    Dictionary<int, KeyValuePair<Guid, BankAccount>> dic = new();

    ListClientsBD(ref dic, ref i, out var ClientId);

    var ClientSelect = dic[ClientId].Value;
    i = 0;
    Console.WriteLine($"{i++}Доступные операции");
    Console.WriteLine($"{i++}показать баланс");
    Console.WriteLine($"{i++}снять деньги");
    Console.WriteLine($"{i++}Перевести другому пользователю");
    Console.WriteLine($"9 Для выхода");
    while (true)
    {
        int.TryParse(Console.ReadLine(), out var input);
        if (input > -1)
        {
            switch (i)
            {
                case 0:
                    ClientSelect.ToString();
                    break;
                case 1:
                    Console.WriteLine($"Тек. баланс {ClientSelect.Balance}");
                    break;
                case 2:
                    ClientSelect.SpendMoney(50);// потратить  50
                    Console.WriteLine($"Остаток {ClientSelect.Balance}");
                    break;
                case 3:
                    i = 0;
                    Console.WriteLine("Кому перевести?");
                    ListClientsBD(ref dic, ref i, out var ClientTO);//кому отправляем
                    if (ClientSelect != dic[ClientTO].Value)
                    {
                        ClientSelect.Transaction(dic[ClientTO].Value, 1000);
                        Console.WriteLine($"Отправил 1000 рублей со счета {ClientSelect.AccountNumber} на счет {dic[ClientTO].Value.AccountNumber}");
                        Console.WriteLine($"Баланс стал To {ClientSelect.Balance} From {dic[ClientTO].Value.Balance}");
                    }
                    else
                    {
                        Console.WriteLine("Выбрали самого себя");
                    }
                    break;
                case 9:
                    Environment.Exit(0);
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }
    }

    /// <summary>
    /// показываем всех клиентов в бд 
    /// </summary>
    void ListClientsBD(ref Dictionary<int, KeyValuePair<Guid, BankAccount>> dic, ref int i, out int ClientId)
    {
        foreach (var item in ListClientBD)
        {
            dic.Add(i, item);
            Console.WriteLine($"[{ i++}]\t{item}");//показываем все о клиенте 

        }
        int.TryParse(Console.ReadLine(), out ClientId);
        if (!dic.ContainsKey(ClientId))//нет клиента
        {
            Environment.Exit(0);
        }
        Console.WriteLine($"Выбран клиент {dic[ClientId].Value}");
    }
}

//Создаем пользователей пока не устанем 



