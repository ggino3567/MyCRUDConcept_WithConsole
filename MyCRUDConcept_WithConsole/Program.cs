namespace MyCURDConcept_WithConsole;

//這是一個非常簡易的CRUD概念 沒用任何框架去製作網頁或應用UI
//單純想了解如何簡單的使用class實作並且try看看
class Program
{
    static void Main(string[] args)
    {
        //2025/8/24 : 考慮後面加上do-while 然後再用選項去跟隨if-else或switch來不斷執行CRUD

        CallCRUD sample = new CallCRUD();
        sample.AddToList(1, "One");
        sample.AddToList(2, "Two");
        sample.AddToList(3, "Three");
        sample.AddToList(10, "Ten");
        sample.AddToList(25, "Twenty Five");
        sample.RemoveFromList(3);

        sample.ShowList();
        sample.UpdateElement(25, "This is my fucking age.");
        sample.AddToList(2, "TWOOOOO");
        sample.ShowList();
        sample.GetElemet(25);
    }
}

class CallCRUD
{
    //原本是使用public 後使用private隱藏Dictionary
    private Dictionary<int, string> Members = new Dictionary<int, string>();

    //C
    public void AddToList(int id, string name)
    {
        if (Members.ContainsKey(id))
        {
            Console.WriteLine("\n===> This id is exist.");
            //remember! Break out.
            return;
        }
        Members.Add(id, name);
    }

    //D
    public void RemoveFromList(int id)
    {
        if (!Members.ContainsKey(id))
        {
            Console.WriteLine("\n===> This id is not exist.");
        }
        Members.Remove(id);
    }

    //U
    public void UpdateElement(int id, string name)
    {
        if (!Members.ContainsKey(id))
        {
            Console.WriteLine("\n===> This id is not exist.\nPlease try again!");
        }
        else
        {
            Members[id] = name;
            Console.WriteLine($"\n===> Success!\n\tMembers[{id}] is success changed : {Members[id]}");
        }
    }

    //R
    public void ShowList()
    {
        if (Members.Count == 0)
        {
            Console.WriteLine("\n===> No members in the list.");
            return;
        }

        Console.WriteLine("\nMembers:");
        foreach (var item in Members)
        {
            Console.WriteLine($"{item}");
        }
    }

    public void GetElemet(int id)
    {
        if (Members.ContainsKey(id))
        {
            Console.WriteLine($"\nMembers[{id}]: {Members[id]}");
        }
        else
        {
            Console.WriteLine("\n===> This id is not exist.");
        }
    }
}