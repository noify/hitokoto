using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市收银系统
{
    class CangKu
    {
        List<List<ProductFather>> list = new List<List<ProductFather>>();
   
        public CangKu()
        {
            list.Add(new List<ProductFather>());
            list.Add(new List<ProductFather>());
            list.Add(new List<ProductFather>());
            list.Add(new List<ProductFather>());
        }
        public void Jinpros(string strType, int count)
        {
            for (int i = 0; i < count; i++)
            {
                switch (strType)
                {
                    case "Nokia": list[0].Add(new Nokia(Guid.NewGuid().ToString(), 9999, "诺基亚手机"));
                        break;
                    case "Tencent": list[1].Add(new Tencent(Guid.NewGuid().ToString(), 9998, "QQXX"));
                        break;
                    case "SamSung": list[2].Add(new SamSung(Guid.NewGuid().ToString(), 3222, "三星平板"));
                        break;
                    case "Apple": list[3].Add(new Apple(Guid.NewGuid().ToString(), 3222, "苹果电脑"));
                        break;
                }
            }
        }
        public void Qupros(string strType, int count)
        {
            ProductFather[] pros = new ProductFather[count];
            for (int i = 0; i < pros.Length; i++)
            {
                switch (strType)
                {
                    case ("Nokia"):
                        if (list[0].Count == 0)
                        {
                            Console.WriteLine("仓库里的诺基亚手机数量不足");
                            break;
                        }
                        else
                        {
                            pros[i] = list[0][0];
                            list[0].RemoveAt(0);
                            break;
                        }
                    case ("Tencent"):
                        if (list[1].Count == 0)
                        {
                            Console.WriteLine("仓库里的QQxx数量不足");
                            break;
                        }
                        else
                        {
                            pros[i] = list[1][0];
                            list[1].RemoveAt(0);
                            break;
                        }
                    case ("Apple"):
                        if (list[3].Count == 0)
                        {
                            Console.WriteLine("仓库里的苹果电脑数量不足");
                            break;
                        }
                        else
                        {
                            pros[i] = list[3][0];
                            list[3].RemoveAt(0);
                            break;
                        }
                    case ("SamSung"):
                        if (list[2].Count == 0)
                        {
                            Console.WriteLine("仓库里的三星平板数量不足");
                            break;
                        }
                        else
                        {
                            pros[i] = list[2][0];
                            list[2].RemoveAt(0);
                            break;
                        }
                }
            }
        }
        public void Showpros()
        {
            foreach(var item in list)
            {
                Console.WriteLine("我们超市有：{0},有{1}个，每个{2}元。",item[0].Name,item.Count,item[0].Price);
            }
        }
    }
}
