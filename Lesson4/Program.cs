
using Lesson4;
using Lesson4.BuildingDescriptions;

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("1.Реализовать класс для описания здания (уникальный номер здания, высота, этажность, количество квартир, подъездов). Поля сделать закрытыми, предусмотреть методы для заполнения полей и получения значений полей для печати. Добавить методы вычисления высоты этажа, количества квартир в подъезде, количества квартир на этаже и т.д. Предусмотреть возможность, чтобы уникальный номер здания генерировался программно. Для этого в классе предусмотреть статическое поле, которое бы хранило последний использованный номер здания, и предусмотреть метод, который увеличивал бы значение этого поля.");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("2. * Для реализованного класса создать новый класс Creator, который будет являться фабрикой объектов класса здания. Для этого изменить модификатор доступа к конструкторам класса, в новый созданный класс добавить перегруженные фабричные методы CreateBuild для создания объектов класса здания. В классе Creator все методы сделать статическими, конструктор класса сделать закрытым. Для хранения объектов класса здания в классе Creator использовать хеш-таблицу. Предусмотреть возможность удаления объекта здания по его уникальному номеру из хеш-таблицы. Создать тестовый пример, работающий с созданными классами.");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("3. * Разбить созданные классы (здания, фабричный класс) и тестовый пример в разные исходные файлы. Разместить классы в одном пространстве имен. Создать сборку (DLL), включающие эти классы. Подключить сборку к проекту и откомпилировать тестовый пример со сборкой. Получить исполняемый файл, проверить с помощью утилиты ILDASM, что тестовый пример ссылается на сборку и не содержит в себе классов здания и Creator.");
Console.WriteLine("6. Выход");
Console.ForegroundColor = ConsoleColor.White;

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
                BuildingDescriptionMethod();//Реализовать класс для описания здания
                break;
            case 2:
                CreatorMethod();// Для реализованного класса создать новый класс Creator
                break;
            case 3:
                SplitFabrics();//Разбить созданные классы (здания, фабричный класс) 
                break;
            case 6:
                Environment.Exit(0);
                break;
            default:
                break;
        }
    }
}



void BuildingDescriptionMethod()
{
    BuildingDescription buildingD = new();
    /// <summary>
    /// ввод с консоля приметивный 
    /// </summary>
    WriteConsoleDom(out double height, out int storeys, out int apartments, out int entrances);
    buildingD.ChangeApartmentCount(ref apartments);
    buildingD.ChangeEntranceCount(ref storeys);
    buildingD.ChangeHeight(ref height);
    buildingD.ChangeEntranceCount(ref entrances);

    Console.WriteLine(buildingD.ToString() + Environment.NewLine);
    Console.WriteLine($"Кол-во квартир на этаже {buildingD.CountFloor}");
    Console.WriteLine("Высота этажа: " + buildingD.GetFloorHeight + "м\n");
    // убедимся, что id увеличивается  -я создаю  guid? поэтому такая проблема не имеет быть места 
    Console.ReadLine();
}
void CreatorMethod()
{
    var random = new Random();
    for (int i = 0; i < 100; i++)
        Creator.CreateBuild();

    foreach (BuildingDescription build in Creator.Builds.Values)
        Console.WriteLine($"Id: {build.UniqueBuildingNumber}");

    Console.WriteLine();
    var index = random.Next(1, 100);
    Console.WriteLine($"Delete build ID: {index}");
    Creator.Delete(index);
    foreach (BuildingDescription build in Creator.Builds.Values)
        Console.WriteLine($"Build ID: {build.UniqueBuildingNumber}");
}
void SplitFabrics()
{
    //SplitClass_Buiding.dll  уже подкючена,  бизнес логика отдельно
}


void WriteConsoleDom(out double height, out int storeys, out int apartments, out int entrances)
{
    height = 0;
    storeys = 0;
    apartments = 0;
    entrances = 0;
    Console.WriteLine("через пробел 4 параметра, высота, этажность, количество квартир, подъездов");
    var temp = Console.ReadLine();
    int count = 0;
    if (temp.Length>0)
    {
        var splitStr = temp.Split(" ");
        if (splitStr.Count() == 4)
        {
            double.TryParse(temp, out double Height);
            int.TryParse(temp, out var Storeys);
            int.TryParse(temp, out var Apartments);
            int.TryParse(temp, out var varEntrances);
            height = Height;
            storeys = Storeys;
            apartments = Apartments;
            entrances = varEntrances;
        }
        else
        {
            Console.WriteLine("не хватает параметров");
            
        }
    }
}