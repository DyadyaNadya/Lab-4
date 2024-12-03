
using System.Security.AccessControl;
using System.Xml.Serialization;

public class Immis
{
    //������� 1
    public static List<T> Filler<T>(int n)
    {
        List<T> L = new List<T>();
        for (int i = 0; i < n; i++)
        {

            Console.Write($"������� {i + 1} ������� ������: ");
            string input = Console.ReadLine();

            try
            {
                T element = (T)Convert.ChangeType(input, typeof(T));
                L.Add(element);
            }
            catch (Exception ex)
            {
                Console.WriteLine("������ ��������������");
                i--;
            }
            }
        return L;

    }

    public static List<T> Delete<T>(T E, List<T> InputList) 
    {
        for (int i = 0; i < InputList.Count - 1; i++) 
        { 
            if (EqualityComparer<T>.Default.Equals(InputList[i], E))
            {
                if (i + 1 < InputList.Count && !EqualityComparer<T>.Default.Equals(InputList[i + 1], E))
                {
                    InputList.RemoveAt(i + 1);
                    
                }
            }
        }
        return InputList;
    }

    public static void Print<T> (List<T> L)
    {
        Console.Write("�������� ������: ");
        for (int i = 0; i <  L.Count; i++)
        {
            Console.Write(L[i]);
            Console.Write(' ');
        }
    }

    //������� 2
    public static bool Similar<T>(LinkedList<T> L)
    {
        
        if (L.First == null)
        {
            return false;
        }
        LinkedListNode<T> current = L.First;

        do
        {
            LinkedListNode<T> next;
            if (current.Next != null)
            {
                next = current.Next;
            }
            else
            {
                next = L.First;
            }

            if (EqualityComparer<T>.Default.Equals(current.Value, next.Value))
            {
                return true;
            }

            if (current.Next != null)
            {
                current = current.Next;
            }
            else
            {
                current = L.First;
            }
        }
        while (current != L.First);
        return false;
        
        
    }

    public static LinkedList<T> FillerLL<T>(int n)
    {
        LinkedList<T> L = new LinkedList<T>();
        for (int i = 0; i < n; i++)
        {

            Console.Write($"������� {i + 1} ������� ������: ");
            string input = Console.ReadLine();

            try
            {
                T element = (T)Convert.ChangeType(input, typeof(T));
                L.AddLast(element);
            }
            catch (Exception ex)
            {
                Console.WriteLine("������ ��������������");
                i--;
            }
        }
        return L;

    }

    public static void PrintLL<T>(LinkedList<T> L)
    {
        Console.Write("�������� ������: ");
        LinkedListNode<T> current = L.First;
        while (current != null) 
        { 
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }


    //������� 3
    public static HashSet<T> CountriesToTravel<T>()
    {
        HashSet<T> Countries = new HashSet<T> { (T)Convert.ChangeType("�������", typeof(T)), (T)Convert.ChangeType("��������", typeof(T)),
         (T)Convert.ChangeType("���������", typeof(T)), (T)Convert.ChangeType("���", typeof(T)),  (T)Convert.ChangeType("������", typeof(T)),
          (T)Convert.ChangeType("��������������", typeof(T)),  (T)Convert.ChangeType("�������", typeof(T)), (T)Convert.ChangeType("������", typeof(T)),};

        Console.WriteLine("��� ������: ");
        foreach (var country_name in Countries)
        {
            Console.WriteLine(country_name);
        }
        return Countries;
    }

    public static Dictionary<string, HashSet<T>> TouristVisit<T>()
    {
        Dictionary<string, HashSet<T>> visited = new Dictionary<string, HashSet<T>>
        {
            {
                "���������� �.�.", new HashSet<T> { (T)Convert.ChangeType("�������", typeof(T)), (T)Convert.ChangeType("������", typeof(T)),
                    (T)Convert.ChangeType("���", typeof(T)), (T)Convert.ChangeType("������", typeof(T)) }
            },

            {
                "������� �.�.", new HashSet<T> { (T)Convert.ChangeType("���", typeof(T)) }
            },

            {
                "������� �.�.", new HashSet<T> { (T)Convert.ChangeType("���", typeof(T)), (T)Convert.ChangeType("������", typeof(T)), (T)Convert.ChangeType("���������", typeof(T)) }
            },

            {
                "������ �.�.", new HashSet<T> { (T)Convert.ChangeType("�������", typeof(T)), (T)Convert.ChangeType("���", typeof(T)) }
            },

            {
                "������������ �.�.", new HashSet<T> { (T)Convert.ChangeType("���", typeof(T)), (T)Convert.ChangeType("��������������", typeof(T)), (T)Convert.ChangeType("������", typeof(T)), }
            }
        };

        Console.WriteLine("\n ������� � ���������� ������: ");
        foreach (var tourist in visited)
        {
            Console.WriteLine($"{tourist.Key}:  {string.Join(", ", tourist.Value)}");
        }
        return visited;

    }

    public static HashSet<T> AllVisited<T>(Dictionary<string, HashSet<T>> visited)
    {
        if (visited == null) return new HashSet<T> ();
        HashSet<T> value = new HashSet<T>(visited.Values.First());
        foreach (var countries in visited.Values) 
        {
            value.IntersectWith(countries);
        }
        return value;
    }

    public static HashSet<T> SomeVisited<T> (Dictionary<string, HashSet<T>> visited)
    {
        HashSet<T> value = new HashSet<T>();
        foreach (var countries in visited.Values)
        {
            value.UnionWith(countries);
        }
        return value;
    }

    public static HashSet<T> NobodyVisited<T> (Dictionary <string, HashSet<T>> visited, HashSet<T> Countries)
    {
        HashSet<T> visitedCountries = SomeVisited(visited);
        HashSet <T> value = new HashSet<T>(Countries);
        value.ExceptWith(visitedCountries);
        return value;
    }

    //������� 4
    public static void FillTheFile(string file)
    {
        if (!File.Exists(file)) 
        {
            Console.WriteLine("���� �� ������!");
        }

        Console.WriteLine("�������� ����� � ����: ");
        using (StreamWriter writer = new StreamWriter(File.Open(file, FileMode.Create)))
        {
            writer.WriteLine(Console.ReadLine());
        }
        Console.WriteLine("����� �������");

    }

    public static HashSet<T> TextFile<T>(string file, HashSet<T> voiceless)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("���� �� ������!");
            return new HashSet<T>();
        }

        string text = File.ReadAllText(file).ToLower();
        var words = text.Split(new[] { ' ', '\r', '\n', '\t', ',', '.', '?', '!', '-', '=', ':' }, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<T, int> count = new Dictionary<T, int>();

        foreach (var word in words)
        {
            var letters = new HashSet<T>();
            foreach (var chars in word)
            {
                letters.Add((T)Convert.ChangeType(chars, typeof(T)));
            }

            foreach (var letter in letters)
            {
                if (voiceless.Contains(letter))
                {
                    if (!count.ContainsKey(letter))
                    {
                        count[letter] = 0;
                    }
                    count[letter]++;
                }

            }
        }

        List<T> result = new List<T>();
        foreach (var pair in count) 
        {
            if (pair.Value != 1)
            {
                result.Add(pair.Key);
            }
        }
        result.Sort();
        return new HashSet<T>(result);
    }


    public static List<Abiturients> Abiturients()
    {
        Console.Write("������� ���������� ������������: ");
        int n;

        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0 || n > 500)
        {
            Console.WriteLine("������������ ��������! ������� ����� �� 1 �� 500:");
        }

        List<Abiturients> abiturients = new List<Abiturients>();

        for (int i = 0; i < n; i++)
        {
            string input;
            string[] parts;

            while (true)
            {
                Console.WriteLine($"������� ������ {i + 1}-�� ����������� (������� ��� ����1 ����2):");
                input = Console.ReadLine();

                parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 4)
                {
                    Console.WriteLine("������ �����. ���������� �����.");
                    continue;
                }

                try
                {
                    string surname = parts[0];
                    string name = parts[1];
                    int result1 = int.Parse(parts[2]);
                    int result2 = int.Parse(parts[3]);

                    if (surname.Length > 20 || name.Length > 15 || result1 < 0 || result1 > 100 || result2 < 0 || result2 > 100)
                    {
                        Console.WriteLine("������ �� ������������� �����������. ���������� ��� ���");
                        continue;
                    }

                    abiturients.Add(new Abiturients(surname, name, result1, result2));
                    break;
                }
                catch
                {
                    Console.WriteLine("������ ��������� ������. ���������� �����.");
                    i--;
                }
            }

        }
            return abiturients;
    }

    //������������ ������
    public static void Serializer(string file, List<Abiturients> abiturients)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Abiturients>));
        using (FileStream fs = new FileStream(file, FileMode.Create))
        {
            serializer.Serialize(fs, abiturients);
        }
        Console.WriteLine("\n������ �������� � XML ����");

    }

    //�������������� ������
    public static List<Abiturients> Deserializer (string file)
    {
        if (!File.Exists(file)) 
        {
            Console.WriteLine("������ �������� �����");
            return new List<Abiturients> ();
        }

        XmlSerializer deserializer = new XmlSerializer(typeof (List<Abiturients>));
        using (FileStream fs = new FileStream (file, FileMode.Open))
        {
            return (List<Abiturients>)deserializer.Deserialize(fs);
        }
    }

    public static List<Abiturients> FailedAbiturients(List<Abiturients> abiturients)
    {
        List<Abiturients> failed = new List<Abiturients>();
        foreach (var abiturient in abiturients)
        {
            if (abiturient.Result1 < 30 || abiturient.Result2 < 30)
            {
                failed.Add(abiturient);
            }
        }
        failed.Sort((a, b) =>
        {
            // ���������� �������
            int surnameComparison = string.Compare(a.Surname, b.Surname, StringComparison.Ordinal);

            if (surnameComparison != 0)
            {
                return surnameComparison; // ���� ������� ������, ���������� ��������� ��������� �� �������
            }

            // ���� ������� ����������, ���������� �� �����
            return string.Compare(a.Name, b.Name, StringComparison.Ordinal);
        });
        return failed;

    }

    public static void Print (List<Abiturients> abiturients)
    {
        Console.WriteLine("\n�� �������� � ���������: ");
        foreach (var abiturient in abiturients)
        {
            Console.WriteLine($"{abiturient.Surname} {abiturient.Name}");
        }
    }

}

