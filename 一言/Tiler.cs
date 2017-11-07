using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Notifications;
using Windows.UI.StartScreen;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace 一言
{
    class Tiler
    {
        static ApplicationDataContainer com = ApplicationData.Current.LocalSettings.CreateContainer("setting", ApplicationDataCreateDisposition.Always);
        public static void ShowTile(String hoto, String source)
        {
            TileUpdateManager.CreateTileUpdaterForApplication().EnableNotificationQueueForWide310x150(false);
            if (com.Values["moban"].ToString() == "0")
            {
                //一般磁贴
                ShowTileW(hoto);
            }
            else if (com.Values["moban"].ToString() == "1")
            {
                //翻转磁贴
                ShowTilePeek(hoto, source);
            }
            else if (com.Values["moban"].ToString() == "2")
            {
                //人脉翻转磁贴
                ShowTilePeekC(hoto);
            }
            else if (com.Values["moban"].ToString() == "3")
            {
                TileUpdateManager.CreateTileUpdaterForApplication().EnableNotificationQueueForWide310x150(true);
                //一般磁贴
                ShowTileW(hoto);
                //人脉翻转磁贴
                ShowTilePeekC(hoto);
                //一般磁贴
                ShowTileW(hoto);
                //翻转磁贴
                ShowTilePeek(hoto, source);
                //一般磁贴
                ShowTileW(hoto);
            }
        }
        //一般磁贴
        public static void ShowTileW(String hoto)
        {
            //创建磁贴通知
            XmlDocument xml;
            if (hoto.Length > 36)
            {
                xml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150Text04);
            }
            else
            {
                xml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150Text03);
            }
            XmlNodeList list = xml.GetElementsByTagName("text");
            //添加消息
            list[0].AppendChild(xml.CreateTextNode(hoto));
            //list[1].AppendChild(xml.CreateTextNode(item));
            //list[2].AppendChild(xml.CreateTextNode(item));
            TileNotification tn = new TileNotification(xml);
            //设置消息消失时间
            //tn.ExpirationTime = DateTime.Now.AddSeconds(10);
            //显示消息
            //TileUpdateManager.CreateTileUpdaterForSecondaryTile("tileId").Update(tn);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tn);
        }
        //翻转磁贴
        public static void ShowTilePeek(String hoto, String source)
        {
            XmlDocument xml;
            if (hoto.Length > 36)
            {
                xml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150PeekImage04);
            }
            else
            {
                xml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150PeekImage03);
            }
            XmlNodeList list = xml.GetElementsByTagName("text");
            XmlNodeList list1 = xml.GetElementsByTagName("image");
            list[0].AppendChild(xml.CreateTextNode(hoto));
            if (source == "龙虎斗" || source == "黑执事" || source == "魔法禁书目录" || source == "魔法少女小圆" || source == "魔卡少女樱" || source == "鬼泣" || source == "食灵" || source == "青之驱魔师" || source == "问题儿童来自异世界" || source == "银魂"
               || source == "钢之炼金术师" || source == "进击的巨人" || source == "通灵王" || source == "这是僵尸吗" || source == "言叶之庭" || source == "美少女战士" || source == "缘之空" || source == "笨蛋测试召唤兽" || source == "穿越时空的少女" || source == "空之境界"
               || source == "秒速五厘米" || source == "火影忍者" || source == "狼与香辛料" || source == "物语" || source == "灼眼的夏娜" || source == "灌篮高手" || source == "潜行吧奈亚子" || source == "海贼王" || source == "死神" || source == "海猫鸣泣之时"
               || source == "某科学的超电磁炮" || source == "柯南" || source == "未闻花名" || source == "无头骑士异闻录" || source == "夏目友人帐" || source == "反叛的鲁鲁修" || source == "EVA" || source == "CLANNAD" || source == "Angel Beats!" || source == "高达"
               || source == "我的青春恋爱物语果然有问题" || source == "我的朋友很少" || source == "幸运星" || source == "寒蝉鸣泣之时" || source == "文学少女")
            {
                ((XmlElement)list1[0]).SetAttribute("src", "ms-appx:///Assets/St/" + source + ".png"); 
            }
            else
            {
                if (com.Values["Peek1"].ToString() == "1" && (com.Values["moban"].ToString() == "1" || com.Values["moban"].ToString() == "3"))
                {
                    ((XmlElement)list1[0]).SetAttribute("src", "ms-appdata:///Local/PeekName1/" + com.Values["PeekName1"].ToString() + ".png");
                }
                else
                {
                    ((XmlElement)list1[0]).SetAttribute("src", "ms-appx:///Assets/WideLogo.scale-240.png");
                }
            }
            TileNotification tn = new TileNotification(xml);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tn);
        }
        //人脉翻转磁贴
        public static void ShowTilePeekC(String hoto)
        {
            XmlDocument xml;
            if (hoto.Length > 36)
            {
                xml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150PeekImageCollection04);
            }
            else
            {
                xml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150PeekImageCollection03);
            }
            XmlNodeList list = xml.GetElementsByTagName("text");
            XmlNodeList list1 = xml.GetElementsByTagName("image");
            list[0].AppendChild(xml.CreateTextNode(hoto));
            if (com.Values["Peek2"].ToString() != "0")
            {
                if (com.Values.ContainsKey("PeekName21"))
                {
                    ((XmlElement)list1[0]).SetAttribute("src", "ms-appdata:///Local/PeekName21/" + com.Values["PeekName21"].ToString() + ".png");
                }
                else
                {
                    ((XmlElement)list1[0]).SetAttribute("src", "ms-appx:///Assets/PeekC/1.png");
                }
                if (com.Values.ContainsKey("PeekName22"))
                {
                    ((XmlElement)list1[1]).SetAttribute("src", "ms-appdata:///Local/PeekName22/" + com.Values["PeekName22"].ToString() + ".png");
                }
                else
                {
                    ((XmlElement)list1[1]).SetAttribute("src", "ms-appx:///Assets/PeekC/2.png");
                } if (com.Values.ContainsKey("PeekName23"))
                {
                    ((XmlElement)list1[2]).SetAttribute("src", "ms-appdata:///Local/PeekName23/" + com.Values["PeekName23"].ToString() + ".png");
                }
                else
                {
                    ((XmlElement)list1[2]).SetAttribute("src", "ms-appx:///Assets/PeekC/3.png");
                } if (com.Values.ContainsKey("PeekName24"))
                {
                    ((XmlElement)list1[3]).SetAttribute("src", "ms-appdata:///Local/PeekName24/" + com.Values["PeekName24"].ToString() + ".png");
                }
                else
                {
                    ((XmlElement)list1[3]).SetAttribute("src", "ms-appx:///Assets/PeekC/4.png");
                } if (com.Values.ContainsKey("PeekName25"))
                {
                    ((XmlElement)list1[4]).SetAttribute("src", "ms-appdata:///Local/PeekName25/" + com.Values["PeekName25"].ToString() + ".png");
                }
                else
                {
                    ((XmlElement)list1[4]).SetAttribute("src", "ms-appx:///Assets/PeekC/5.png");
                }
            }
            else
            {
                ((XmlElement)list1[0]).SetAttribute("src", "ms-appx:///Assets/PeekC/1.png");
                ((XmlElement)list1[1]).SetAttribute("src", "ms-appx:///Assets/PeekC/2.png");
                ((XmlElement)list1[2]).SetAttribute("src", "ms-appx:///Assets/PeekC/3.png");
                ((XmlElement)list1[3]).SetAttribute("src", "ms-appx:///Assets/PeekC/4.png");
                ((XmlElement)list1[4]).SetAttribute("src", "ms-appx:///Assets/PeekC/5.png");

            }
            TileNotification tn = new TileNotification(xml);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tn);
        }
        
    }
}
