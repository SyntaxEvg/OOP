using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2.Less3._1
{
    public class BankAccountBase
    {
        public void BankAccount()
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
        }
}
