namespace MyCURDConcept_WithConsole;

//這是一個非常簡易的CRUD概念 沒用任何框架去製作網頁或應用UI
//單純想了解如何簡單的使用class實作並且try看看
class Program
{
    static void Main(string[] args)
    {
        //2025/8/24 : 考慮後面加上do-while 然後再用選項去跟隨if-else或switch來不斷執行CRUD
        //2025/8/24 : 加了 有點簡陋 回來再改完整點

        CallCRUD sample = new CallCRUD();
        
        do
        {
            Console.WriteLine("==== SimpleCRUD ====");
            Console.WriteLine("1. 添加");
            Console.WriteLine("2. 讀取");
            Console.WriteLine("3. 更新");
            Console.WriteLine("4. 刪除");
            Console.WriteLine("5. 退出");
            Console.WriteLine("====================");
            Console.WriteLine("\n請選擇執行動作 : ");
            int operatorInput = int.Parse(Console.ReadLine());

            if (operatorInput == 5)
            {
                Console.WriteLine("\n===> 退出");
                return;
            }
            else if (operatorInput == 1)
            {
                Console.WriteLine("\n===> 添加");
                Console.Write("輸入ID : ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("\n輸入Value : ");
                string name = Console.ReadLine();
                sample.AddToList(id, name);
            }
            else if (operatorInput == 2)
            {
                Console.WriteLine("\n===> 讀取");
                Console.Write("請輸入 (1) to 讀取全部 | (2) 讀取特定內容 : ");
                int chooseInput = int.Parse(Console.ReadLine());
                if (chooseInput == 1)
                {
                    sample.ShowList();
                }
                else
                {
                    Console.Write("輸入欲搜尋的ID : ");
                    int id = int.Parse(Console.ReadLine());
                    sample.GetElemet(id);
                }
            }
            else if (operatorInput == 3)
            {
                Console.Write("輸入ID : ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("\n輸入Value : ");
                string name = Console.ReadLine();
                sample.UpdateElement(id, name);
            }
            else if (operatorInput == 4)
            {
                Console.Write("輸入欲搜尋的ID : ");
                int id = int.Parse(Console.ReadLine());
                sample.RemoveFromList(id);
            }
            else
            {
                Console.WriteLine("輸入的選項錯誤!");
            }

        } while (true);
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
        Console.WriteLine($"Members[{id}, {name}] add success!\n");
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
            Console.WriteLine("\n===> No members in the list.\n");
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