//1.Создать класс счет в банке с закрытыми полями: номер счета, баланс, тип банковского счета (использовать перечислимый тип). Предусмотреть методы для доступа к данным – заполнения и чтения. Создать объект класса, заполнить его поля и вывести информацию об объекте класса на печать.
//2. Изменить класс счет в банке из упражнения таким образом, чтобы номер счета генерировался сам и был уникальным. Для этого надо создать в классе статическую переменную и метод, который увеличивает значение этого переменной.
//3. В классе банковский счет удалить методы заполнения полей. Вместо этих методов создать конструкторы. Переопределить конструктор по умолчанию, создать конструктор для заполнения поля баланс, конструктор для заполнения поля тип банковского счета, конструктор для заполнения баланса и типа банковского счета. Каждый конструктор должен вызывать метод, генерирующий номер счета.
//4. В классе все методы для заполнения и получения значений полей заменить на свойства. Написать тестовый пример.
//5. * Добавить в класс счет в банке два метода: снять со счета и положить на счет. Метод снять со счета проверяет, возможно ли снять запрашиваемую сумму, и в случае положительного результата изменяет баланс.


using Lesson2;
using Lesson2.Less3._1;
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
    string str = Console.ReadLine()!;
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
    new BankAccountBase().BankAccount();
}

//Создаем пользователей пока не устанем 



