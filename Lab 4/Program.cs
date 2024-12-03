using Microsoft.VisualBasic.FileIO;
using static Immis;

public class Program
{
    public static void Main()
    {
        int task = GetPositiveInt("Введите номер задания: ");

        switch (task) {

            case 1:
                //Задание 1
                Console.WriteLine("------Задание 1------\n");
                int n = GetPositiveInt("Введите количество элементов в списке чисел: ");
                List<int> list1 = Filler<int>(n);
                int number;
                Console.Write("\nВведите элемент E: \n");
                int E = int.Parse(Console.ReadLine());

                int c = GetPositiveInt("\nВведите количество элементов в списке строк: ");
                List<string> list2 = Filler<string>(c);
                string word;
                Console.Write("\nВведите элемент E:");
                string W = Console.ReadLine();
                Console.WriteLine();

                List<int> Output1 = Delete<int>(E, list1);
                List<string> Output2 = Delete<string>(W, list2);
                Print(Output1);
                Console.WriteLine("\n");
                Print(Output2);

                break;


            case 2:

                //Задание 2
                Console.WriteLine("\n------Задание 2------");
                int n2 = GetPositiveInt("Введите количество элементов в списке: ");
                LinkedList<int> list = FillerLL<int>(n2);
                PrintLL(list);
                bool Sim = Similar(list);
                string answer;

                if (Sim)
                {
                    answer = "Одинаковые элементы есть";
                }
                else
                {
                    answer = "Одинаковых элементов нет";
                }

                Console.WriteLine(answer);
                break;

            case 3:
                HashSet<string> countries = Immis.CountriesToTravel<string>();
                Dictionary<string, HashSet<string>> visitedCountries = Immis.TouristVisit<string>();

                var All = Immis.AllVisited(visitedCountries);
                var Somebody = Immis.SomeVisited(visitedCountries);
                var Nobody = Immis.NobodyVisited(visitedCountries, countries);

                Console.WriteLine("\nСтраны, в которых побывали все туристы: ");
                foreach (var country in All) {
                    Console.WriteLine(country);
                }

                Console.WriteLine("\nСтраны, в которых побывали некоторые туристы: ");
                foreach (var country in Somebody)
                {
                    Console.WriteLine(country);
                }

                Console.WriteLine("\nСтраны, в которых не побывал никто: ");
                foreach (var country in Nobody)
                {
                    Console.WriteLine(country);
                }
            break;

            case 4:
                string file = "text.txt";
                HashSet<char> voiceless = new HashSet<char>() { 'с', 'т', 'ш', 'п', 'к', 'щ', 'ч', 'х', 'ф', 'ц' };
                Immis.FillTheFile(file);
                var result = Immis.TextFile(file, voiceless);
                Console.WriteLine("\nГлухие согласные, которые не входят ровно в одно слово (в алфавитном порядке):");
                Console.WriteLine(string.Join(", ", result));
                break;

            case 5:
                string filexml = "abiturients.xml";

                List<Abiturients> abiturients = Immis.Abiturients();
                Immis.Serializer(filexml, abiturients);
                List<Abiturients> ListOfAbiturients = Immis.Deserializer(filexml);
                List<Abiturients> failed = Immis.FailedAbiturients(abiturients);

                
                Immis.Print(failed);
                break;

            default:
            Console.WriteLine("Номер задания введён некорректно или такого задания нет");


        break;

    }

    }



    public static int GetPositiveInt(string message)
    {
        int result;
        do
        {
            Console.Write(message);
            string input = Console.ReadLine();
            if (!int.TryParse(input, out result) || result <= 0)
            {
                Console.WriteLine("Пожалуйста, введите положительное целое число. ");
            }
        } while (result <= 0);
        return result;
    }
}
