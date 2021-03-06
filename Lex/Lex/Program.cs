using System;
using System.IO;
using System.Linq;


namespace Lex
{

    class caracter
    {
        
        public string nm;
        public int hp;
        public int ap;
        public int ch;
        public caracter(string name, int helth,int strength, int luck)
        {
            nm = name;
            hp = helth;
            ap = strength;
            ch = luck;
        }
        public void car() {
            Console.WriteLine(nm +" health:"+ hp +" strength:"+ ap +" luck:"+ ch);
        }
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            
            navigation();

        }
        static int intValidation(string input)
        {
            int inp;
            if (int.TryParse(input, out inp) == false)
            {
                Console.WriteLine("not valid input try again");
                inp = 0;
                navigation();
            }
           
                return inp;
            
        }
        static void arrayValidation(string input)
        {
            string[] arr = input.Split(',');
            int[] inp = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                if (int.TryParse(arr[i], out inp[i]) == false)
                {
                    Console.WriteLine("not valid input try again");

                    navigation();
                }
            }
     
            
        }
        //1
        static void hello()
        {
            Console.WriteLine("Hello World");
            navigation();
        }
        
        //2
        static void user()
        {
            Console.WriteLine("name");
            string Name = Console.ReadLine();

            Console.WriteLine("lastname");
            string LName = Console.ReadLine();

            Console.WriteLine("age");
            int Age = intValidation(Console.ReadLine());
            Console.WriteLine(" user is: " + Name + LName + Age);

            navigation();
        }
        //3
        static void colorCange()
        {
            if (Console.ForegroundColor != ConsoleColor.Green)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            
            navigation();
        }
        //4
        static void date()
        {
            DateTime date = DateTime.Today;
            Console.WriteLine(date);
            navigation();
        }
        //5
        static void bigNum()
        {
            Console.WriteLine("first nuber");
            int num1 = intValidation(Console.ReadLine());
            Console.WriteLine("second nuber");
            int num2 = intValidation(Console.ReadLine());

            if (num1 >= num2)
            {
                Console.WriteLine(num1 + "is bigger");
            }
            else
            {
                Console.WriteLine(num2 + "is bigger");
            }
            navigation();
        }
        //6
        static void guessNum()
        {
            int tries = 0;
            var r = new Random();
            int rand = r.Next(1, 100);

            Console.WriteLine("gues the number between 1 - 100");
            int num =intValidation(Console.ReadLine());

            while (num != rand)
            {
                tries++;
                if (num == 0)
                {}
                else if (num <= rand)
                {
                    Console.WriteLine("to low");
                }
                else
                {
                    Console.WriteLine("to heigh");
                }
                num =intValidation(Console.ReadLine()); ;
            }
            tries++;
                Console.WriteLine("congratulations toatal guesses:" + tries);
                navigation();
            
        }
        
        //7 
        static void fileWrite()
        {
            Console.WriteLine("Write new file");
            string text = Console.ReadLine();
            using (StreamWriter sw = File.CreateText(@"C:\Users\Hugo\source\repos\Lex\text\MyTest.txt"))
            {
                sw.WriteLine(text);
            }
            navigation();
        }
        //8
        static void fileRead()
        {
            using (StreamReader sr = File.OpenText(@"C:\Users\Hugo\source\repos\Lex\text\MyTest.txt"))
            {
                string s = sr.ReadLine();
                Console.WriteLine(s);
            }
            navigation();
        }
        //9
        static void deci()
        {
            Console.WriteLine("wright a decimal number use ,");
            double num;

            if(double.TryParse(Console.ReadLine(), out num)==false)
            {
                Console.WriteLine("not valid");
                deci();
            }
            
            num=Math.Pow(num, 10);
            Console.WriteLine(num);

            navigation();
        }
        //10
        static void multiplication()
        {
            for(int i = 1; i < 11; i++)
            {
                int[] Mset = new int[10];
                for (int j = 1; j < 11; j++)
                {
                    Mset[j-1] = j * i;
                    
                }
                Console.WriteLine(String.Join(",", Mset));
            }
            navigation();
        }
        //11
        static void arrayCreate()
        {
            var r = new Random();

            int[] sarr = new int[10];
            int[] rarr = new int[10];
            int[] darr = new int[10];

            for (int i = 0; i < 10; i++)
            {
                int rand = r.Next();

                darr[i] = rand;
                rarr[i] = rand;
            }
            
            for(int j =0;j <10; j++)
            {
                sarr[j] = darr.Min();
                darr = darr.Where(val => val != darr.Min()).ToArray();
                
            }
            Console.WriteLine(String.Join(",",rarr));
            Console.WriteLine(String.Join(",", sarr));

            navigation();

        }
        //12
        static void palindromeCheck()
        {
            Console.WriteLine("write a word");
            string word = Console.ReadLine().ToLower();

            char[] characters = word.ToCharArray();

            Array.Reverse(characters);
            
            string wor = new string(characters);

            if (wor == word)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

            navigation();
        }
        //13
        static void between()
        {
            int numb1;
            int numb2;

            Console.WriteLine("first nuber");
            int num1 = intValidation(Console.ReadLine());
            Console.WriteLine("second nuber");
            int num2 = intValidation(Console.ReadLine());

            if (num1 <= num2)
            {
                numb1 = num2;
                numb2 = num1;
            }
            else
            {
                numb1 = num1;
                numb2 = num2;
            }

            for (int i = numb2+1; i < numb1; i++)
            {
                Console.WriteLine(i);
            }

            navigation();
        }
        //14
        static void numSeperation()
        {
            Console.WriteLine("write nubers seperate them using ,");
            string numSeqence = Console.ReadLine();
            arrayValidation(numSeqence);

            int[] arr = numSeqence.Split(',').Select(int.Parse).ToArray();

            string even = "even";
            string uneven = "uneven";
            foreach (int i in arr)
            {
                
                double h= Convert.ToDouble(i);
                
                if (h * 0.5 -(int)(i * 0.5) == 0.5)
                {
                    uneven = uneven + " " + i;
                }
                else
                {
                    even = even + " " + i;
                }
            }
            Console.WriteLine(even);
            Console.WriteLine(uneven);

            navigation();
        }
        //15
        static void numAdition()
        {
            Console.WriteLine("write nubers seperate them using ,");
            string numSeqence = Console.ReadLine();
            arrayValidation(numSeqence);

            int[] arr = numSeqence.Split(',').Select(int.Parse).ToArray();
            Console.WriteLine(arr.Sum());

            navigation();
        }
        //16
        static void game()
        {
            var r = new Random();

            Console.WriteLine("Write youre name");
            string name=Console.ReadLine();
            caracter ca = new caracter(name, r.Next(), r.Next(), r.Next());

            
            Console.WriteLine("Write youre oponants name");
            string neme =Console.ReadLine();
            caracter ce = new caracter(neme, r.Next(), r.Next(), r.Next());

            ce.car();
            ca.car();

            navigation();
        }

            static void navigation()
        {
            
            Console.WriteLine("write the number coresponding to the funktion you whant to try");
            Console.WriteLine("0:exit 1:hello 2:user 3:colorChange 4:date 5:bigNum 6:guessNum 7:fileWrite 8:fileRead 9:deci 10:multiplication 11:arrayCreate 12:palindromeCheck 13:between 14:numSeperation 15:numAdition 16:game");

            string nav = Console.ReadLine();
            
            switch (nav)
            {
                case "0":
                    Environment.Exit(0);
                    break;

                case "1":
                    hello();
                    break;

                case "2":
                    user();
                    break;

                case "3":
                    colorCange();
                    break;

                case "4":
                    date();
                    break;

                case "5":
                    bigNum();
                    break;

                case "6":
                    guessNum();
                    break;

                case "7":
                    fileWrite();
                    break;

                case "8":
                    fileRead();
                    break;

                case "9":
                    deci();
                    break;

                case "10":
                    multiplication();
                    break;

                case "11":
                    arrayCreate();
                    break;

                case "12":
                    palindromeCheck();
                    break;

                case "13":
                    between();
                    break;

                case "14":
                    numSeperation();
                    break;

                case "15":
                    numAdition();
                    break;

                case "16":
                    game();
                    break;

                default:
                    Console.WriteLine("input not valid");
                    navigation();
                    break;
            }
        }
        
        
    }
}
