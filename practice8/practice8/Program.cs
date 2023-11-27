using System;
using System.Collections.Generic;
using System.Threading;
using static System.Console;

namespace practice8
{
    class Program
    {
        static List<string> TstText = new List<string> { "Дядя Семён ехал из города домой. С ним была собака Жучка, Вдруг из леса выскочили волки. Жучка испугалась и прыгнула в сани. У дяди Семёна была хорошая лошадь. Она тоже испугалась и быстро помчалась по дороге. Деревня была близко. Показались огни в окнах. Волки отстали." };
        public static char[] words = TstText[0].ToCharArray();
        public static int bbb;
        static void Main()
        {
            WriteLine("Введи имя");
            string name = ReadLine();
            Start(name);
        }
        public static void Start(string name)
        {
            Clear();
            string numbersStr = string.Join("", words);
            WriteLine(numbersStr);
            ConsoleKeyInfo consoleKeyInfo = ReadKey();
            if (consoleKeyInfo.Key == ConsoleKey.Enter)
            {
                WriteLine();
                Thread timerThread = new Thread(() => Timer(name));
                timerThread.Start();
                var i = 0;
                CharCheck(i, name);
            }
        }
        public static void CharCheck(int i, string name)
        {
            while (true)
            {
                try {
                    ConsoleKeyInfo ewe = ReadKey(true);
                    if (ewe.KeyChar == words[i])
                    {
                        SetCursorPosition(i, 0);
                        ForegroundColor = ConsoleColor.Green;
                        Write(ewe.KeyChar);
                        i++;
                        bbb = i;
                    }
                    else CharCheck(i, name);
                }
                catch {WriteLine("Problem");}
            }
        }
        public static void Timer(string name)
        {
            int minutes = 1; int seconds = 0;
            while (minutes > 0 || seconds > 0)
            {
                ForegroundColor = ConsoleColor.White;
                SetCursorPosition(5, 5);
                WriteLine($"{minutes}:{seconds.ToString().PadLeft(2, '0')}");
                Thread.Sleep(1000); 
                seconds--;
                if (seconds < 0)
                {
                    minutes--;
                    seconds = 59;
                }
            }
            SetCursorPosition(5, 5);
            WriteLine("Таймер завершен!");
            Records(name);
        }
        public static void Records(string name) {
            ForegroundColor = ConsoleColor.White;
            Clear();
            WriteLine("Ваш результат");
            WriteLine($"{name}  {bbb}/мин   {bbb/60}/sec\n\n");
            ReadKey();
        }
    }
}
