using System.ComponentModel;

namespace MainMenu
{
    internal class Program
    {
        static bool goBack = false;//عملته عشان لو في رجوع من أي منيو تانية يرجع على طول من غير ما
                                   // dothis line  Console.WriteLine("Press any key to continue :)");
                                   //على مستوى الكلاس كله عشان تستخدمها اي ميثود
        static void ShowMenu()
        {
            Console.WriteLine("====================== Menu List ======================");
            Console.WriteLine(" p - Print Numbers");// done
            Console.WriteLine(" a - Add a Number");// done
            Console.WriteLine(" n - Add Range Of Numbers");// done
            Console.WriteLine(" m - Display Sum and Mean Of Numbers");// done
            Console.WriteLine(" s - Display The Smallest Number");// done
            Console.WriteLine(" l - Display The Largest Number");// done
            Console.WriteLine(" f - Find a Number (Choice The Algorithm)");//done        // there is subMenu else => [linear] & [binary search]
            Console.WriteLine(" c - Clear The Whole List");
            Console.WriteLine(" d - Delete a Number");
            Console.WriteLine(" t - Sort (Choice The Algorithm)");//done TODO: merge     // subMenu => [selection , bubble , insertion , merge]
            Console.WriteLine(" r - Reverse Numbers");//done
            Console.WriteLine(" v - Remove Dublicates");//done
            Console.WriteLine(" To Quit Any Time Press '0' OR 'q'");//done
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
                        if (goBack)
                        {
                            goBack = false;
                            continue;
                        }
                        break;
                    case 't':
                        SortMenu(arr);
                        if (goBack)
                        {
                            goBack = false;
                            continue;
                        }
                        break;
                    case 'v':
                        RemoveDublicates(ref arr);
                        break;
                    case 'r':
                        //ReverseList(ref arr);
                        ReverseList(arr);
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
            Console.Write("]\n");
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
            for (int i = 0; i < inputs.Length; i++)
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
                    BinarySearchFind(list);
                else if (choice == '0')
                {
                    goBack = true;
                    Console.WriteLine("u will go to the main menu :)");
                    return; // go to the previous menu 
                }
                else
                    Console.WriteLine("InValid Choice, Try Again:)");
                Console.WriteLine("hhhhhhhhhh");
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
        static int BinarySearch(List<int> list, int target)
        {
            int l = 0;
            int r = list.Count - 1;
            int mid;
            while (l <= r)
            {
                //mid = (l + r) / 2;
                mid = l + (r - l) / 2; // to avoid overflow for (int.MaxValue + int.MaxValue)   
                if (list[mid] == target)
                    return mid;
                else if (list[mid] < target)
                    l = mid + 1;
                else if (list[mid] > target)
                    r = mid - 1;
            }
            return -1;
        }
        //=====================
        static void BinarySearchFind(List<int> list)
        {
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_");
            Console.WriteLine("\nU Know? We Must Sort The List First Then Search :)");
            Console.WriteLine("So i will leave the original list and make BS on another sorted list from numbers of the origional :) :)");
            Console.WriteLine("\n-_-_-_-_-_-_-_-_-_-_-_-_\n");
            List<int> sortedList = new List<int>();
            sortedList = list;
            sortedList.Sort();//معلش هنا استخدمت الجاهزة على ما أعمل الميثود كمان شويه
            //-------------
            int num = ReadNumberForSearch();
            int index = BinarySearch(sortedList, num);

            if (index == -1)
                Console.WriteLine($"{num} is not found");
            else
                Console.WriteLine($"{num} is found at position {index + 1}");
        }
        //=====================
        //=====================
        //Sorting Algorithms:
        //في نقطة مهمة .. انا عملت الجورزمات السورتينج دي من يومين لواحدها ولسه واخداهم الأن ل هنا جاهزين
        static void ShowSortMenu()
        {
            Console.WriteLine("===================Sort Menu===================");
            Console.WriteLine("================Ascending Sort=================\n");
            Console.WriteLine(" 1 - Selection Sort");
            Console.WriteLine(" 2 - Bubble Sort");
            Console.WriteLine(" 3 - Insertion Sort");
            Console.WriteLine(" 4 - Merge Sort");
            Console.WriteLine(" 0 - Back");
            Console.WriteLine("\n===============================================");
        }
        //=====================
        static void SortMenu(List<int> list)
        {
            while (true)
            {
                Console.Clear();
                ShowSortMenu();
                Console.Write("Enter Your Choice => ");
                char choice = Convert.ToChar(Console.ReadLine().Trim().ToLower());
                if (choice == '1')
                    SelectionSort(list);
                else if (choice == '2')
                    BubbleSort(list);
                else if (choice == '3')
                    InsertionSort(list);
                //else if (choice == '4') //TODO
                //    MergeSort(list);
                else if (choice == '0')
                {
                    goBack = true;
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
        static void SelectionSort(List<int> list)
        {
            //هنا نقطة مهمة جدا .. انه الليست بالفعل اتغيرت لأن دلوقتي انا كان معايا 
            //its ref [in stack] => which point to the list [in heap]
            int position, temp;

            for (int i = 0; i < list.Count - 1; i++)//tour
            {

                position = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[position])
                    {
                        position = j;
                    }
                }
                //position == i ://مكنش في داعي للفة دي والرقم في مكانه الصحصح
                if (position != i)
                {
                    //swapping:

                    temp = list[i];
                    list[i] = list[position];
                    list[position] = temp;
                }
            }
            Console.WriteLine("List has been sorted using Selection Sort.");

        }
        //=====================
        static void BubbleSort(List<int> list)
        {
            //foreach (int ele in list) Console.Write($"{ele}  ");

            int loop = list.Count - 1;
            int tmp;
            bool swapped;

            while (loop > 0)
            {
                //في كل لفة في فرصة انه بدل ما نكمل الالجورزم .. انه يوقف لأنه خلاص الاّراي بالفعل اترتبت
                swapped = false;
                for (int i = 0; i < loop; i++)
                {
                    if (list[i] > list[i + 1])
                    {
                        //swapping
                        tmp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = tmp;

                        swapped = true;

                    }
                }
                if (!swapped) break;
                loop--;
            }
            //Console.WriteLine();
            //foreach (int ele in list) Console.Write($"{ele}  ");
            //Console.WriteLine();

            Console.WriteLine("List has been sorted using Bubble Sort.");

        }
        //=====================
        static void InsertionSort(List<int> list)
        {
            //foreach (int i in list) Console.Write($"{i}  ");
            int key, j;
            for (int i = 1; i < list.Count; i++)//i=1 : consider the first element is sorted already
            {
                key = list[i];

                /// for(j=i-1; j>=0; j--)//looping on the sorted list(من يمين ل شمال)
                /// {
                ///     if(key < arr[j])
                ///     {
                ///         //will shift arr[j] to the next index ->
                ///         arr[j + 1] = arr[j];// become this index empty :)
                ///     }
                ///     else
                ///     {
                ///         break;// wil not continue looping => already the arr i loop in reversely is sorted so all the rest elements are smaller
                ///     }
                /// }

                j = i - 1;

                if (key >= list[j]) continue; //it's correct place already :)  => goog if the arr is sorted :)
                // j>=0 must be first =>&& make  short-circuit evaluation => and if(j==-1)-> arr[-1] -> will make exception outOfRange
                while (j >= 0 && key < list[j]) //looping on the sorted list(من يمين ل شمال)
                {
                    //shifting:
                    list[j + 1] = list[j];// become this index empty :)
                    j--;
                }
                //this for => if u reached arr[0] -> the end of the sorted arr and ended the comparison
                ////or        if u reached that the current element is smaller than the key so => we reached the correct place for [key]
                list[j + 1] = key;
            }

            //Console.WriteLine();
            //foreach (int i in list) Console.Write($"{i}  ");
            //Console.WriteLine();
            Console.WriteLine("List has been sorted using Insertion Sort.");

        }
        //=====================
        static void RemoveDublicates(ref List<int>oldList) // ref : to allow me to change the address it self 
            // دلوقتي انا مش معايا نسخة ولكن معايا المكان ال اقدر اعدل فيه العنوان ال بيشاور عليه
        {
            HashSet<int> uniqueNumbers = new HashSet<int>();
            List<int> newList = new List<int>();

            for(int i=0; i<oldList.Count; ++i)
            {
                if (uniqueNumbers.Add(oldList[i]))
                    newList.Add(oldList[i]);
            }

            oldList = newList;//  وبكده أتغير العنوان بتاع الريفرنس ال كان موجود في الاستاك 
            //وعدش في وجود للأراي القديمة
        }
        //=====================
        static void ReverseList(ref List<int> oldList)
        {
            List<int> reversedList = new List<int>();
            for(int i=oldList.Count-1; i>=0; --i)
            {
                reversedList.Add(oldList[i]);
            }
            oldList = reversedList;
            Console.WriteLine("the list has been reversed :)");
        }
        //=====================
        static void ReverseList(List<int> list)
        {
            // two pointer techinque:)
            int l = 0;
            int r=list.Count-1;
            int tmp;
            while (l < r)
            {
                //swapping
                tmp = list[l];
                list[l] = list[r];
                list[r] = tmp;

                l++;
                r--;
            }
            Console.WriteLine("the list has been reversed :)");
        }   

        //=====================





    }
}
