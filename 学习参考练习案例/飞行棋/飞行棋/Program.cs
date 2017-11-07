using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 飞行棋
{
    class Program
    {
        static int[] Map = new int[100];
        static int[] Player = new int[2];
        static string[] PlayerNames = new string[2];
        static bool[] Flags = new bool[2];
        static void Main(string[] args)
        {
            GameShow();
            GameLoad();
            ReadNames();
            DrawMaps();
            while (Player[0] < 99 && Player[1] < 99)
            {
                if (Flags[0])
                {
                    Flags[0] = false;
                }
                else
                {
                    PlayGame(0);
                }
                if (Flags[1])
                {
                    Flags[1] = false;
                }
                else
                {
                    PlayGame(1);
                }
            }
            if (Player[0] == 99)
            {
                Console.WriteLine("{0}无耻的战胜了{1}", PlayerNames[0], PlayerNames[1]);
                return;
            }
            if (Player[1] == 99)
            {
                Console.WriteLine("{0}无耻的战胜了{1}", PlayerNames[1], PlayerNames[0]);
                return;
            }
            Console.ReadKey(true);
        }
        public static void GameShow()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*******************************");
            Console.WriteLine("*******************************");
            Console.Write("************");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("飞行棋");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("*************");
            Console.WriteLine("");
            Console.WriteLine("*******************************");
            Console.WriteLine("*******************************");
        }
        public static void GameLoad()
        {
            int[] luckyturn = { 6, 23, 40, 55, 69, 83 };//幸运轮盘◎
            int[] landMine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 };//地雷☆
            int[] pause = { 9, 27, 60, 93 };//暂停▲
            int[] timeTunnel = { 20, 25, 45, 63, 72, 88, 90 };//时空隧道卐
            for (int i = 0; i < luckyturn.Length; i++)
            {
                Map[luckyturn[i]] = 1;
            }
            for (int i = 0; i < landMine.Length; i++)
            {
                Map[landMine[i]] = 2;
            }
            for (int i = 0; i < pause.Length; i++)
            {
                Map[pause[i]] = 3;
            }
            for (int i = 0; i < timeTunnel.Length; i++)
            {
                Map[timeTunnel[i]] = 4;
            }
        }
        public static void DrawGame(int i)
        {

            if (Player[0] == Player[1] && Player[0] == i)
            {
                Console.Write("<>");
            }
            else
            {
                if (Player[0] == i)
                {
                    Console.Write("A ");
                }
                else if (Player[1] == i)
                {
                    Console.Write("B ");
                }
                else
                {
                    switch (Map[i])
                    {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("□");
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("◎");
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("☆");
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("▲");
                            break;
                        case 4:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("卐");
                            break;
                    }
                }
            }
        }
        public static void DrawMaps()
        {
            //清屏
            Console.Clear();
            Console.WriteLine("幸运轮盘 ◎, 地雷 ☆,暂停 ▲,时空隧道 卐");
            //第一横行
            for (int i = 0; i < 30; i++)
            {
                DrawGame(i);
            }
            Console.WriteLine();
            //第一竖行
            for (int i = 30; i < 35; i++)
            {
                for (int n = 0; n < 29; n++)
                {
                    Console.Write("  ");
                }
                DrawGame(i);
                Console.WriteLine();
            }
            //第二横行
            for (int i = 64; i > 34; i--)
            {
                DrawGame(i);
            }
            Console.WriteLine();
            //第二竖行
            for (int i = 65; i < 70; i++)
            {
                DrawGame(i);
                Console.WriteLine();
            }
            //第三横行
            for (int i = 70; i < 100; i++)
            {
                DrawGame(i);
            }
            Console.WriteLine();
        }
        public static void ReadNames()
        {
            Console.WriteLine("请输入玩家A的姓名：");
            PlayerNames[0] = Console.ReadLine();
            while (PlayerNames[0] == "")
            {
                Console.WriteLine("不可以输入空白，请重新输入");
                PlayerNames[0] = Console.ReadLine();
            }
            Console.WriteLine("请输入玩家B的姓名：");
            PlayerNames[1] = Console.ReadLine();
            while (PlayerNames[1] == "" || PlayerNames[1] == PlayerNames[0])
            {
                if (PlayerNames[1] == "")
                {
                    Console.WriteLine("不可以输入空白，请重新输入");
                    PlayerNames[1] = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("玩家B的姓名不可以与玩家A的姓名相同，请重新输入");
                    PlayerNames[1] = Console.ReadLine();
                }
            }

        }
        public static void PlayGame(int i)
        {
            Console.WriteLine("{0}请按任意键掷骰子", PlayerNames[i]);
            Console.ReadKey(true);
            Random r = new Random();
            int rn = r.Next(1, 7);
            Console.WriteLine("{0}掷出了{1}，按任意键进行行动", PlayerNames[i], rn);
            Console.ReadKey(true);
            Player[i] += rn;
            if (Player[0] < 0)
            {
                Player[0] = 0;
            }
            if (Player[0] >= 99)
            {
                Player[0] = 99;
            }
            if (Player[1] < 0)
            {
                Player[1] = 0;
            }
            if (Player[1] >= 99)
            {
                Player[1] = 99;
            }
            if (Player[i] == Player[1 - i])
            {
                Player[1 - i] -= 6;
                DrawMaps();
                Console.WriteLine("{0}前进了{1}格，踩到了{2}，{3}回退6格", PlayerNames[i], rn, PlayerNames[1 - i], PlayerNames[1 - i]);
            }
            else
            {
                switch (Map[Player[i]])
                {
                    case 0:
                        DrawMaps();
                        Console.WriteLine("{0}前进了{1}格", PlayerNames[i], rn);
                        break;
                    case 1:
                        DrawMaps();
                        Console.WriteLine("{0}遇到了幸运轮盘  请选择：1————交换位置  2————轰炸对方", PlayerNames[i]);
                        string str = Console.ReadLine();
                        while (true)
                        {
                            if (str == "1")
                            {
                                int tmp = Player[i];
                                Player[i] = Player[1 - i];
                                Player[1 - i] = tmp;
                                DrawMaps();
                                Console.WriteLine("位置已交换");
                                return;
                            }
                            else if (str == "2")
                            {
                                Player[1 - i] -= 6;
                                DrawMaps();
                                Console.WriteLine("{0}后退6格", PlayerNames[1 - i]);
                                return;
                            }
                            else
                            {
                                Console.WriteLine("输入错误，请重新输入！1————交换位置  2————轰炸对方");
                                str = Console.ReadLine();
                            }
                        }
                        break;
                    case 2:
                        Player[i] -= 6;
                        DrawMaps();
                        Console.WriteLine("{0}踩到了地雷，退6格", PlayerNames[i]);
                        break;
                    case 3:
                        if(PlayerNames[i]==PlayerNames[0])
                        {
                            Flags[0] = true;
                        }
                        else
                        {
                            Flags[1] = true;
                        }
                        DrawMaps();
                        Console.WriteLine("{0}暂停一回合", PlayerNames[i]);
                        break;
                    case 4:
                        Player[i] += 10;
                        DrawMaps();
                        Console.WriteLine("{0}遇到了时空隧道，前进10格", PlayerNames[i]);
                        break;

                }
            }


        }
    }
}
