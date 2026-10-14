namespace MainMenu
{
    internal class Program
    {
        static void ShowMenu()
        {
            Console.WriteLine("====================== Menu List ======================");
            Console.WriteLine(" p - Print Numbers");
            Console.WriteLine(" a - Add a Number");
            Console.WriteLine(" n - Add Range Of Numbers");
            Console.WriteLine(" m - Display Sum and Mean Of Numbers");
            Console.WriteLine(" s - Display The Smallest Number");
            Console.WriteLine(" l - Display The Largest Number");
            Console.WriteLine(" f - Find a Number (Choice The Algorithm)");// there is subMenu else => [linear] & [binary search]
            Console.WriteLine(" c - Clear The Whole List");
            Console.WriteLine(" d - Delete a Number");
            Console.WriteLine(" s - Sort (Choice The Algorithm)");// subMenu => [selection , bubble , insertion , merge]
            Console.WriteLine(" r - Reverse Numbers");
            Console.WriteLine(" v - Remove Dublicates");
            Console.WriteLine(" To Quit Any Time Press '0' OR 'q'");
            Console.WriteLine("=======================================================");
        }
        //======================================================
        static void Main(string[] args)
        {
            char op;
            List<int> arr = new List<int>();

            do
            {
                Console.Clear();
                ShowMenu();
                Console.Write("\nEnter A Choice : ");
                op = Convert.ToChar(Console.ReadLine().ToLower());
                //--------------
                switch (op)
                {
                    case 'p':
                        PrintNumbers(arr);
                        break;
                    case 'a':
                        AddNumber(arr);
                        break;
                    case 'm':
                        DisplayMean(arr);
                        break;
                    case 'n':
                        AddRange(arr);
                        break;
                    case 's':
                        DisplaySmallest(arr);
                        break;
                    case 'l':
                        DisplayLargest(arr);
                        break;
                    case 'f':
                        FindMenu(arr);
                        break;
                    //case 'p':

                    //    break;
                    // it's better to write the condition of finishing here instead of do-while(...)
                    //لأنه كده مش هينزل تاني وينفذ مثلا اي كود بعد الاسواتش ولكن هينهي المين فانكشن خالص
                    //ونفس السبب اني معملتش بريك وعملت ريتيرن
                    case 'q' or '0':
                        Console.WriteLine("Good bye :)");
                        return;
                    //break;// 
                    default:
                        Console.WriteLine("InValid Choice, Enter again");
                        break;
                }
                Console.WriteLine("Press any key to continue :)");
                Console.ReadKey(true);//بستخدمها عشان في الكونسل يقف اشوف النتيجة لحد ما اضغط اي مفتاح في الكيبورد فيعيد اللوب

            } while (true);

        }
        //======================================================
        //methods:
        static void PrintNumbers(List<int> arr)
        {
            Console.Write("[ ");
            for (int i = 0; i < arr.Count; i++)
            {
                Console.Write($"{arr[i]}  ");
            }
            Console.Write("]");
        }
        //=====================
        static void AddNumber(List<int> arr)
        {
            Console.Write("Enter the number =>  ");
            int num = Convert.ToInt32(Console.ReadLine());

            arr.Add(num);
            Console.WriteLine($" {num} is added :)");
        }
        //=====================
        static void AddRange(List<int> arr)
        {
            Console.Write("Enter all the numbers seperated with a space =>  ");
            string[] inputs = Console.ReadLine().Trim().Split(" ");
            for(int i = 0;i < inputs.Length;i++)
                arr.Add(Convert.ToInt32(inputs[i]));
            Console.WriteLine("The numbers are added :)");

        }
        //=====================
        static void DisplayMean(List<int> arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Count; i++)
                sum += arr[i];
            Console.WriteLine($"Sum = {sum} :::: Avarage = {sum / arr.Count}");
        }
        //=====================
        static void DisplaySmallest(List<int> arr)
        {
            int min = arr[0];// or    int.MaxValue 
            for (int i = 0; i < arr.Count; i++)
                if (arr[i] < min)
                    min = arr[i];
            Console.WriteLine($"The Smallest Number is {min}");
        }
        //=====================
        static void DisplayLargest(List<int> arr)
        {
            int max = arr[0];// or    int.MinValue 
            for (int i = 0; i < arr.Count; i++)
                if (arr[i] > max)
                    max = arr[i];
            Console.WriteLine($"The Largest Number is {max}");
        }
        //=====================
        static void ShowFindMenu()
        {
            Console.WriteLine("===================Find Menu===================");
            Console.WriteLine(" l - Find Using (Linear Search)");
            Console.WriteLine(" b - Find Using (Binary Search)");
            Console.WriteLine(" 0 - Back");
            Console.WriteLine("===============================================");
        }
        //=====================
        static void FindMenu(List<int> list)
        {
            while (true)
            {
                Console.Clear();
                ShowFindMenu();
                Console.Write("Enter Your Choice => ");
                char choice = Convert.ToChar(Console.ReadLine().Trim().ToLower());

                if (choice == 'l')
                    LinearSearchFind(list);
                else if (choice == 'b')
                    Console.WriteLine("binary");
                else if (choice == '0')
                {
                    Console.WriteLine("u will go to the main menu :)");
                    return; // go to the previous menu 
                }
                else
                    Console.WriteLine("InValid Choice, Try Again:)");

                Console.WriteLine("Press any key to continue :)");
                Console.ReadKey(true);
            }
        }
        //=====================
        static int ReadNumberForSearch()
        {
            Console.Write("Enter num to search for => ");
            int num = Convert.ToInt32(Console.ReadLine());
            return num;
        }
        //=====================
        static int LinearSearch(List<int> list, int target)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == target)
                    return i;
            }
            return -1;
        }
        //=====================
        static void LinearSearchFind(List<int> list)
        {
            int num = ReadNumberForSearch();
            int index = LinearSearch(list, num);

            if (index == -1)
                Console.WriteLine($"{num} is not found");
            else
                Console.WriteLine($"{num} is found at position {index + 1}");
        }
        //=====================





    }
}
