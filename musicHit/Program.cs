using System.Data;
using System.Runtime.ExceptionServices;
string firstName = "";
int firstAge = 0;
string firstNationality = "";
string secondName = "";
int secondAge = 0;
string secondNationality = "";
double hits = 0;
string cicle = "";

List<string> massKeys = new List<string>() //create mass
{
    "firstMusic",
    "secondMusic",
    "firstFilms",
    "secondFilms",
    "firstCuisine",
    "secondCuisine"
};

Dictionary<string, List<string>> ineterstsMass = new Dictionary<string, List<string>>();

foreach (var line in massKeys)
{
    ineterstsMass.Add(line, new List<string>());
}

while (cicle != "нет")
{
    Console.WriteLine("Если хочешь сравнить музыкыкальные плейлисты введи 1 \nЕсли хочешь заполнить анкеты по интересам введи 2 ");
    string programSwitch = Console.ReadLine();
    switch (programSwitch)
    {
        case "1":
            Console.WriteLine("укажите путь к первому списку треков");
            string linkFirst = Console.ReadLine();

            AddInterestsMassText("firstMusic", linkFirst);


            Console.WriteLine("укажите путь ко второму списку треков");
            string linkSecond = Console.ReadLine();
            AddInterestsMassText("secondMusic", linkSecond);

            var resultMusic = Compare(ineterstsMass["firstMusic"], ineterstsMass["secondMusic"]);
            Console.WriteLine($"Соотношение музыки {resultMusic}");
            Console.WriteLine($"кол-во совпадений: {hits}");

            break;

        case "2":
            Personalyty(ref firstName, ref firstAge, ref firstNationality);

            InterestsText("music", "firstMusic");
            InterestsText("films", "firstFilms");
            InterestsText("cuisine", "firstCuisine");

            Personalyty(ref secondName, ref secondAge, ref secondNationality);

            InterestsText("music", "secondMusic");
            InterestsText("films", "secondFilms");
            InterestsText("cuisine", "secondCuisine");

            resultMusic = Compare(ineterstsMass["firstMusic"], ineterstsMass["secondMusic"]);
            var resultFilms = Compare(ineterstsMass["firstFilms"], ineterstsMass["secondFilms"]);
            var resultCuisine = Compare(ineterstsMass["firstCuisine"], ineterstsMass["secondCuisine"]);

            Console.WriteLine($"Соотношение музыки {resultMusic}");
            Console.WriteLine($"Соотношение филмов {resultFilms}");
            Console.WriteLine($"Соотношение кухни {resultCuisine}");

            break;
    }


    Console.WriteLine("Хотите попробовать еще? если да - напишите да , если нет - напишите нет");
    cicle = Console.ReadLine();
    ineterstsMass.Clear();
    foreach (var line in massKeys)
    {
        ineterstsMass.Add(line, new List<string>());
    }
}

Console.ReadKey();

void InterestsText(string interests, string personInterests) //met show exmple
{
    switch (interests)
    {
        case "music":
            Console.WriteLine("Перечисли через энтер жанры музыки, котрые ты любишь. Пиши жанры так-же как в перечне! когда закончишь, напиши 1");
            Console.WriteLine("рок, поп, рэп, электронная, джаз, классика, инди,");
            AddInterestsMass(personInterests);
            break;
        case "films":
            Console.WriteLine("Перечисли через энтер жанры кино, котрые ты любишь. Пиши жанры так-же как в перечне! когда закончишь, напиши 1");
            Console.WriteLine("Драмма, комедия, детектив, триллер, боевик, супергеройское, хоррор, ром-ком, анимэ, артхаус");
            AddInterestsMass(personInterests);
            break;
        case "cuisine":
            Console.WriteLine("Перечисли через энтер кухни, котрые ты любишь. Пиши кухни так-же как в перечне! когда закончишь, напиши 1");
            Console.WriteLine("Русская, азиатская, французкая, итальянская, мексиканская, фаст-фуд, японская, немецкая");
            AddInterestsMass(personInterests);
            break;
    }
}

void AddInterestsMass(string personInterests) //met add interests in mass
{
    string temp = Console.ReadLine();

    if (temp != "1")
    {
        ineterstsMass[personInterests].Add(temp);
        AddInterestsMass(personInterests);
    }
}

void AddInterestsMassText(string personInterests, string link) //met add interests in mass
{
    try
    {
        using (StreamReader reader = new StreamReader(link))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                ineterstsMass[personInterests].Add(line);
            }

            reader.Close();
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("The file could not be read:");
        Console.WriteLine(e.Message);
    }
}

void Personalyty(ref string name, ref int age, ref string nationality)
{
    Console.WriteLine("Привет! Заполни не большую анкету!");
    Console.WriteLine("Как тебя зовут?");
    name = Console.ReadLine();
    Console.WriteLine("Сколько тебе лет?");
    age = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Какой ты национальности?");
    nationality = Console.ReadLine();
    Console.WriteLine($"Привет {name}  Твой возраст {age} и ты {nationality}");
}

double Compare(List<string> list1, List<string> list2)
{
    var  bigSize = GetMax(list1.Count, list2.Count);
    hits = 0;

    for (int i = 0; i < list1.Count; i++)
    {
        for (int j = 0; j < list2.Count; j++)
        {
            if (list1[i] == list2[j])
            {
                hits++;

            }
        }
    }

    return Math.Round((hits / bigSize) * 100, 2);
}

int GetMax(int a1, int b1)
{
    if (a1 >= b1)
    {
        return a1;
    }
    else
    {
        return b1;
    }
}










