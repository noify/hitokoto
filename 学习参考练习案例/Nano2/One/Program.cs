using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One
{
    class Program
    {
        static void Main(string[] args)
        //////////
        //
        ///
        ////
        {


            //Console.WriteLine("Hello World!");
            //Console.ReadKey();
            //Console.WriteLine("Hello World too!");
            //Console.ReadKey();
            //Console.writelie("");
            //Console.ReadKey();



            //            Console.WriteLine(@"
            //***************************
            //* 这是我的第一个C#应用程序*
            //***************************");
            //            Console.ReadKey();


            //Console.WriteLine("请输入姓名：");
            //string name=Console.ReadLine();
            //Console.WriteLine("请输入年龄：");
            //string age = Console.ReadLine();
            //Console.WriteLine("请输入家住地址：");
            //string dizhi = Console.ReadLine();
            //Console.WriteLine("请输入邮箱：");
            //string youxiang = Console.ReadLine();
            //Console.WriteLine("请输入工资");
            //string gongzhi = Console.ReadLine();
            //Console.WriteLine("我是{0},我{1}了,家住{2},邮箱是{3},我的工资有{4}",name,age,dizhi,youxiang,gongzhi);
            //Console.ReadKey();




            //int a = 10;
            //int b = 5;
            //Console.WriteLine("目前a是{0}，b是{1}，请交换两者的变量",a,b);
            //int c = a;
            //a = b;
            //b = c;
            //Console.WriteLine("已交换变量，现在a是{0}，b是{1}", a, b);
            //Console.ReadKey();



            //int a = 20;
            //int b = 5;
            //Console.WriteLine("目前a是{0}，b是{1}，请交换两者的变量", a, b);
            //b = a + b;
            //a = b - a;
            //b = b - a;
            //Console.WriteLine("已交换变量，现在a是{0}，b是{1}", a, b);
            //Console.ReadKey();


            //Console.WriteLine("请问你喜欢吃什么？");
            //string a = Console.ReadLine();
            //Console.WriteLine("{0}很难吃的！！！！！！", a);
            //Console.ReadKey();


            //int a = 100;
            //int b = 20;
            //int c = a + b;
            //Console.WriteLine("2个数的和为" + c);

            //double pi = 3.14;
            //int r = 5;
            //double mianji = pi * r * r;
            //double zhouchang = 2 * pi * r;
            //Console.WriteLine("圆的面积是{0}，周长是{1}", mianji, zhouchang);

            //int t = 35;
            //int k = 120;
            //int m = 3 * t + 2 * k;
            //double m2 = m * 0.88;
            //Console.WriteLine("小明应付{0}，打8.8折以后为{1}", m, m2);

            //Console.ReadKey();



            //练习,编程实现计算几天(如46天)是几周零几 天.
            //练习:编程实现107653秒是几天几小时几分钟几秒?
            //修改上面的题目,让用户输入.
            //小时(Hour),分钟(Minute),秒(Seconds)
            //Console.WriteLine("请输入天数");
            //string day = Console.ReadLine();
            //int day1 = Convert.ToInt32(day);
            //int z = day1 / 7;
            //int t = day1 % 7;
            //Console.WriteLine("{0}天是{1}周零{2}天",day,z,t);

            //int second = 107653;
            //int day2 = second / (60 * 60 * 24);
            //int s1 = second % (60 * 60 * 24);
            //int hou = s1 / (60 * 60);
            //int s2 = s1 % (60 * 60);
            //int minut = s2 / 60;
            //int s3 = s2 % 60;
            //Console.WriteLine("107653秒是{0}天{1}小时{2}分钟{3}秒", day2, hou, minut, s3);

            //Console.ReadKey();


            //让用户输入老苏的语文和数学成绩,输出以下判断是否正确,正确输出True,错误输出False
            //1)老苏的语文和数学成绩都大于90分
            //2)语文和数学有一门是大于90分的

            //Console.WriteLine("请输入老苏的语文成绩：");
            //int yw = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("请输入老苏的数学成绩：");
            //int sx = Convert.ToInt32(Console.ReadLine());
            //bool a = yw > 90 && sx > 90;
            //bool b = yw > 90 || sx > 90;
            //Console.WriteLine("{0}\n{1}",a,b);
            //Console.ReadKey();



            //            写下判断闰年的表达式,设待判断的年份变量为year.
            //润年的判定(符合下面两个条件之一):
            //年份能够被400整除.(2000)
            //年份能够被4整除但不能被100整除.(2008)
            //让用户输入一个年份,如果是润年,则输出true,如果不是,则输出false.
            //2100/1600/1800/2009年是闰年吗？

            //Console.WriteLine("请输入年份：");
            //int year = Convert.ToInt32(Console.ReadLine());
            //bool a = (year % 100 == 0) || (year % 4 == 0 && year % 100 != 0);
            //Console.WriteLine(a);
            //Console.ReadKey();






            //            让用户输入年龄,如果输入的年龄大于23(含)岁,则给用户显示你到了结婚的年龄了.
            //如果老苏的(chinese  music)
            //语文成绩大于90并且音乐成绩大于80
            //语文成绩等于100并且音乐成绩大于70,则奖励100元.
            //让用户输入用户名和密码,如果用户名为admin,密码为mypass,则提示登录成功.

            //Console.WriteLine("请输入年龄：");
            //int age = Convert.ToInt32(Console.ReadLine());
            //if (age >= 23)
            //{
            //    Console.WriteLine("你可以结婚了");

            //}
            //Console.ReadKey();

            //Console.WriteLine("请输入老苏的语文成绩：");
            //int yw = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("请输入老苏的音乐成绩：");
            //int yy = Convert.ToInt32(Console.ReadLine());
            //bool a = (yw > 90 && yy > 80) || (yw == 100 && yy > 70);
            //if (a)
            //{
            //    Console.WriteLine("奖励100元！");
            
            //}
            //Console.ReadKey();

            //Console.WriteLine("请输入用户名：");
            //string yhm =Console.ReadLine();
            //Console.WriteLine("请输入密码：");
            //string mm =Console.ReadLine();
            //bool a = yhm == "admin" && mm == "mypass";
            //if (a)
            //{
            //    Console.WriteLine("登录成功！");
            
            //}
            //Console.ReadKey();






            //            1、老苏买了一筐鸡蛋，如果坏蛋少于5个，他就吃掉，否则他就去退货
            //2、 要求用户输入两个数a、b，如果a和b整除或者a加b大于100，则输出a的值，否则输出b的值
            //3、对学员的结业考试成绩评测(考虑用if好还是用if-else好)
            //          成绩>=90 ：A      
            // 90>成绩>=80 ：B 	
            // 80>成绩>=70 ：C
            // 70>成绩>=60 ：D
            //          成绩<60  ：E

            //Console.WriteLine("坏蛋有几个");
            //int hd = Convert.ToInt32(Console.ReadLine());
            //if (hd < 5)
            //{
            //    Console.WriteLine("吃掉");

            //}
            //else
            //{
            //    Console.WriteLine("退货");
 
            //}
            //Console.ReadKey();

            //Console.WriteLine("请输入a：");
            //int a = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("请输入b：");
            //int b = Convert.ToInt32(Console.ReadLine());
            //bool c = a % b == 0 || a + b > 100;
            //if (c)
            //{
            //    Console.WriteLine(a);

            //}
            //else
            //{
            //    Console.WriteLine(b);
            
            //}
            //Console.ReadKey();

            //Console.WriteLine("请输入成绩：");
            //int c=Convert.ToInt32(Console.ReadLine());
            //if(c>=90)
            //{
            //    Console.WriteLine("a");
            //}
            //else if(c>=80)
            //{
            //    Console.WriteLine("b");
            //}
            //else if (c >= 70)
            //{
            //    Console.WriteLine("c");
            //}
            //else if (c >= 60)
            //{
            //    Console.WriteLine("d");
            //}
            //else
            //{
            //    Console.WriteLine("e");
            //}
            //Console.ReadKey();




            //练习1：提示用户输入密码，如果密码是“88888”则提示正确，否则要求再输入一次，
            //       如果密码是“88888”则提示正确，否则提示错误,程序结束。(如果我的密码里有英文还要转换吗,密码:abc1)
            //练习2：提示用户输入用户名，然后再提示输入密码，如果用户名是“admin”并且密码是“88888”，
            //       则提示正确，否则，如果用户名不是admin还提示用户用户名不存在,如果用户名是admin则提示密码错误.
            //练习3：提示用户输入年龄，如果大于等于18，则告知用户可以查看，如果小于10岁，
            //       则告知不允许查看，如果大于等于10岁并且小于18，则提示用户是否继续查看（yes、no），
            //       如果输入的是yes则提示用户请查看，否则提示"退出,你放弃查看"。

            //Console.WriteLine("请输入用户名：");
            //string yhm = Console.ReadLine();
            //Console.WriteLine("请输入密码：");
            //string mm = Console.ReadLine();
            //if (yhm == "admin" && mm == "888888")
            //{
            //    Console.WriteLine("登录成功！");
            //}
            //else if (yhm != "admin" && mm == "888888")
            //{
            //    Console.WriteLine("用户名不存在！");
            //}
            //else if (yhm == "admin" && mm != "888888")
            //{
            //    Console.WriteLine("密码错误！");
            //}
            //else if (yhm != "admin" && mm != "888888")
            //{
            //    Console.WriteLine("登录错误！");
            //}
            //Console.ReadKey();

            //Console.WriteLine("请输入年龄：");
            //int age = Convert.ToInt32(Console.ReadLine());
            //if (age >= 18)
            //{
            //    Console.WriteLine("可以查看");
            //}
            //else if (age >= 10)
            //{
            //    Console.WriteLine("是否继续查看？（yes/no）");
            //    string a = Console.ReadLine();
            //    if (a == "yes")
            //    {
            //        Console.WriteLine("请查看");
            //    }
            //    else if (a == "no")
            //    {
            //        Console.WriteLine("退出，你放弃查看");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("不允许查看");
            //}
            //Console.ReadKey();


            //            打印100次"欢迎您来传智播客学习"
            //输入班级人数,然后依次输入学员成绩，计算班级学员的平均成绩和总成绩
            //老师问学生,这道题你会做了吗?如果学生答"会了(y)",则可以放学.如果学生不会做(n),则老师再讲一遍,再问学生是否会做了......
            //直到学生会为止,才可以放学.
            //直到学生会或老师给他讲了10遍还不会,都要放学
            //2006年培养学员80000人，每年增长25%，请问按此增长速度，到哪一年培训学员人数将达到20万人？

            //int i = 1;
            //while (i <= 100)
            //{
            //    Console.WriteLine("欢迎来到NHK！"+i);
            //    i++;
            //}
            //Console.ReadKey();

            //int i = 1;
            //string a = "n";
            //while (i <= 10 && a == "n")
            //{
            //    Console.WriteLine("这道题目你会做了嘛？（y/n）第{0}遍",i);
            //    a = Console.ReadLine();
            //    i++;
            //}
            //if (i == 11)
            //{
            //    Console.WriteLine("怎么还不会，时间到了，放学");
            //}
            //else if(a=="y")
            //{
            //    Console.WriteLine("会了吧，放学！");
            //}
            //Console.ReadKey();

            //int a = 1; int sum = 0; int i = 0; int u = 1;
            //do
            //{
            //    Console.WriteLine("请输入班级人数：");
            //    try
            //    {
            //        i = Convert.ToInt32(Console.ReadLine());
            //        Console.WriteLine("请依次输入学生的成绩：");
            //        while (a <= i)
            //        {

            //            try
            //            {

            //                Console.WriteLine("请输入{0}号学生的成绩：", a);
            //                int score = Convert.ToInt32(Console.ReadLine());
            //                sum += score;
            //                a++;
            //                u = 1;

            //            }
            //            catch
            //            {
            //                Console.WriteLine("学生的成绩输入有误，请输入正整数！");
            //            }

            //        }
            //    }
            //    catch
            //    {
            //        Console.WriteLine("班级人数输入有误，请输入正整数！");
            //        u = 0;
            //    }
            //}
            //while (u == 0);
            //Console.WriteLine("班级学生的总成绩为{0}，平均成绩为{1}", sum, sum / i);
            //Console.ReadKey();

            //double i = 80000; int year = 2006;
            //Console.WriteLine("请输入预期达到的学生人数：");
            //int a = Convert.ToInt32(Console.ReadLine());
            //while (i < a)
            //{
            //    i *= 1.25;
            //    year++;

            //}
            //Console.WriteLine("在{0}年的时候，学生人数达到{1}", year, i);
            //Console.ReadKey();







            //练习1：计算1到100之间整数的和；
            //练习2：要求用户输入用户名和密码，只要不是admin、888888就一直提示用户名或密码错误,请重新输入。
            //练习3:不断要求用户输入学生姓名,输入q结束.
            //练习4：不断要求用户输入一个数字，然后打印这个数字的二倍，当用户输入q的时候程序退出。
            //练习5：不断要求用户输入一个数字（假定用户输入的都是正整数），当用户输入end的时候显示刚才输入的数字中的最大值

            //int i=1;int a=2;
            //do
            //{
            //    i += a;
            //    a++;
            //} while (a <= 100);
            //Console.WriteLine(i);
            //Console.ReadLine();
            
            //string a="";
            //do
            //{
            //    Console.WriteLine("输入学生姓名，输入q结束");
            //    a = Console.ReadLine();
            //}
            //while (a != "q");
            //Console.ReadKey();

            //string a = " ";
            //int b = 0;
            //do
            //{
            //    Console.WriteLine("输入一个正整数,当输入end的时候显示刚才输入的数字中的最大值");
            //    a = Console.ReadLine();
            //    if (a != "end")
            //    {
            //        try
            //        {
            //            int c = Convert.ToInt32(a);
            //            if (c > b)
            //            {
            //                b = c;
            //            }
            //        }
            //        catch
            //        {
            //            Console.WriteLine("输入有误！");
            //        }
            //    }
            //} while (a != "end");
            //Console.WriteLine("刚才输入的最大值为{0}", b);
            //Console.ReadKey();




            //for (int i = 1; i <= 9; i++)
            //{
            //    for (int j = 1; j <= i; j++)
            //    {
            //        Console.Write("{0}*{1}={2}\t", j, i, i * j);
            //    }
            //    Console.Write("\n");
            //}
            //Console.ReadKey();


            // 练习2：在while中用break实现要求用户一直输入用户名和密码，只要不是admin、88888就一直提示要求重新输入,如果正确则提登录成功.

            //string name = "";
            //string pwd = "";
            //while (name != "admin" && pwd != "888888") 
            //{
            //    Console.WriteLine("请输入用户名：");
            //    name = Console.ReadLine();
            //    Console.WriteLine("请输入密码：");
            //    pwd = Console.ReadLine();
            //    if(name != "admin" && pwd != "888888")
            //    {
            //        Console.WriteLine("请重新输入！");
            //    }
            //}
            //Console.WriteLine("登陆成功！");
            //Console.ReadKey();



            //int i = 0;
            //bool b = int.TryParse("32", out i);
            //Console.WriteLine("{0}\n{1}",b,i);
            //Console.ReadKey();






            //练习1:循环录入5个人的年龄并计算平均年龄,如果录入的数据出现负数或大于100的数,立即停止输入并报错.
            //练习2：在while中用break实现要求用户一直输入用户名和密码，只要不是admin、88888就一直提示要求重新输入,如果正确则提登录成功.
            //1~100之间的整数相加，得到累加值大于20的当前数(比如:1+2+3+4+5+6=21)结果6

            //int sum = 0;
            //bool b=true;
            //for (int i = 1; i <= 5; i++)
            //{
            //    Console.WriteLine("请输入第{0}个人的年龄：",i);
            //    int age = int.Parse(Console.ReadLine());
            //    sum += age;
            //    if (age < 0 || age > 100)
            //    {
            //        Console.WriteLine("输入错误！");
            //        b = false;
            //        break;
            //    }
            //}
            //if(b)
            //{
            //    Console.WriteLine("这5个人的平均年龄为{0}", sum / 5);
            //}
            //Console.ReadKey();


            //int i = 1;
            //while (i <= 100)
            //{
            //    if (i % 7 == 0)
            //    {
            //        Console.Write(i);
            //        Console.WriteLine();
            //    }
            //    i++;
            //}
            //Console.ReadKey();

            //int i = 1;
            //int sum = 0;
            //while (i <= 100)
            //{
            //    if (i % 7 == 0)
            //    {
            //        i++;
            //        continue;
            //    }
            //    sum += i;
            //    i++;
            //}
            //Console.WriteLine(sum);
            //Console.ReadKey();


            //Console.WriteLine("请输入2个值比较大小：");
            //int m = int.Parse(Console.ReadLine());
            //int n = int.Parse(Console.ReadLine());
            //int i = m > n ? m : n;
            //Console.WriteLine("最大的值是{0}", i);
            //Console.ReadKey();

            //练习1：从一个整数数组中取出最大的整数,最小整数,总和,平均值
            //练习2：计算一个整数数组的所有元素的和。
            //练习3:数组里面都是人的名字,分割成:例如:老杨|老苏|老邹…”
            //(老杨,老苏,老邹,老虎,老牛,老蒋,老王,老马)
            //练习4：将一个整数数组的每一个元素进行如下的处理：如果元素是正数则将这个位置的元素的值加1，如果元素是负数则将这个位置的元素的值减1,如果元素是0,则不变。
            //练习5：将一个字符串数组的元素的顺序进行反转。{“我”,“是”,”好人”} {“好人”,”是”,”我”}。第i个和第length-i-1个进行交换。	



            //int[] a = { 1, 5, 9, 3, 8, 4, 12, 0, -2 };
            //int max = a[1];
            //int min = a[1];
            //int sum = 0;
            //for (int i = 0; i < a.Length; i++)
            //{
            //    if (a[i] > max)
            //    {
            //        max = a[i];
            //    }
            //    if (a[i] < min)
            //    {
            //        min = a[i];
            //    }
            //    sum += a[i];
            //}
            //Console.WriteLine("数组的最大值为{0}，最小值为{1}，总和为{2}，平均值为{3}。", max, min, sum, sum / a.Length);
            //Console.ReadKey();



            
            //string[] a = {"老杨", "老苏", "老邹", "老虎", "老牛", "老蒋", "老王", "老马"};
            //string str = null;
            //for (int i = 0; i < a.Length-1; i++)
            //{
            //    str += a[i] + "|";
            //}
            //Console.WriteLine(str+a[a.Length-1]);
            //Console.ReadKey();



            //int[] a = { -1, 5, -9, 3, 8, -4, 12, 0, -2 };
            //int max = a[1];
            //int min = a[1];
            //for (int i = 0; i < a.Length; i++)
            //{
            //    if (a[i] > 0)
            //    {
            //        a[i]+=1;
            //    }
            //    if (a[i] < 0)
            //    {
            //        a[i]-=1;
            //    }
            //}
            //Console.WriteLine(a);
            //Console.ReadKey();


            Console.WriteLine("是否进去求数组平均值程序？（yes）");
            string str = Console.ReadLine();
            Sint(str);




        }

       public static double _tmp = 0;
        public static void Sint(string str)
        {
            if(str=="yes")
            {
                Console.WriteLine("请输入数组的位数:");
                int p = int.Parse(Console.ReadLine());
                int[] a = new int[p];
                for (int i = 0; i < a.Length; i++)
                {
                    Console.WriteLine("请输入第{0}个数:", i + 1);
                    a[i] = int.Parse(Console.ReadLine());
                }
                for (int i = 0; i < a.Length; i++)
                {
                    _tmp += a[i];
                    if (i == a.Length - 1)
                    {
                        _tmp = _tmp / a.Length;
                        Console.WriteLine("该数组的平均值为{0}", _tmp);
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                Console.WriteLine("退出程序");
            }

        }
    }
}
