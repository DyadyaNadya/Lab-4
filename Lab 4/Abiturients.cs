
using System.Security.AccessControl;

[Serializable]
public class Abiturients
{
    private string surname;
    private string name;
    private int result1;
    private int result2;

    public string Surname {
        get { return surname; }
        set { surname = value; }
    }
    public string Name {
        get { return name; }
        set { name = value; }
    }
    public int Result1 {
        get { return result1; }
        set { result1 = value; }
    }
    public int Result2 {
        get { return result2; }
        set { result2 = value; }
    }

    public Abiturients() { }

    public Abiturients(string surname, string name, int result1, int result2)
    {
        Surname=surname;
        Name=name;
        Result1=result1;
        Result2=result2;
        
    }
}
    