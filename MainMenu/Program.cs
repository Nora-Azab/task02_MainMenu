namespace MainMenu
{
  internal class Program
    {
        static void ShowMenu()
        {
            Console.WriteLine("====================== Menu List ======================");
            Console.WriteLine(" p - Print Numbers");
            Console.WriteLine(" a - Add a Number");
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
                    //case 'p':

                    //    break;
                    //case 'p':

                    //    break;
                    //case 'p':

                    //    break;
                    //case 'p':

                    //    break;
                    //case 'p':

                    //    break;
                    default:
                        Console.WriteLine("InValid Choice, Enter again");
                        break;
                }
                Console.ReadKey(true);//بستخدمها عشان في الكونسل يقف اشوف النتيجة لحد ما اضغط اي مفتاح في الكيبورد فيعيد اللوب

            }while(op !='q' && op !='0');

        }
        //======================================================
        //methods:
        static void PrintNumbers(List<int> arr)
        {
            Console.Write("[ ");
            for(int i=0; i<arr.Count; i++)
            {
                Console.Write($"{arr[i]}  ");
            }
            Console.Write("]");
        }
    }
}
