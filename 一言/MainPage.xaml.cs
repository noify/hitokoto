using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.StartScreen;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Background;
using Windows.Networking.Connectivity;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using Windows.Data.Json;
using Windows.System;
using Windows.Graphics.Imaging;
using System.Runtime.Serialization;
using Windows.UI.Input;
using Windows.ApplicationModel.Email;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI;
using SQLite;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=391641 上有介绍

namespace 一言
{
    
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Point start;
        String date,hoto,spng,res;
        ImageBrush imageBrush = new ImageBrush();
        Random r = new Random();
        String s, responseText,source;
        HttpClient hc = new HttpClient();
        DispatcherTimer dt = new DispatcherTimer();
        ApplicationDataContainer c = ApplicationData.Current.LocalSettings;
        ApplicationDataContainer com = ApplicationData.Current.LocalSettings.CreateContainer("setting", ApplicationDataCreateDisposition.Always);
        ApplicationDataContainer sql = ApplicationData.Current.LocalSettings.CreateContainer("sql", ApplicationDataCreateDisposition.Always);
        HttpResponseMessage response = new HttpResponseMessage();

        private const string taskName = "BlogFeedBackgroundTask";
        private const string taskEntryPoint = "BackgroundTasks.BlogFeedBackgroundTask"; 
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            rec.PointerPressed += con_PointerPressed;
            rec.PointerReleased += con_PointerReleased;
        }

        private void con_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint end = e.GetCurrentPoint(rec);
            double deltaY = end.Position.Y - start.Y;
            double deltaX = end.Position.X - start.X;
            double alpha = Math.Atan(deltaY / deltaX) * 180 / Math.PI;
            if (end.Position.X > start.X)//为右方
            {
                //负数为上
                //正数为下
                if (alpha > 45)
                {
                    //下方
                    res = "下方";
                }
                else if (alpha < -45)
                {
                    //上方
                    res = "上方";
                }
                else
                {
                    //右方
                    res = "右方";
                }
            }
            else if (end.Position.X == start.X)
            {
                //不知道
                //如果end.Y>start.Y向下
                if (end.Position.Y > start.Y)
                {
                    res = "下方";
                }
                else
                {
                    res = "上方";
                }
            }
            else//左方
            {
                //负数为下
                //正数为上
                if (alpha > 45)
                {
                    //上方
                    res = "上方";
                }
                else if (alpha < -45)
                {
                    //下方
                    res = "下方";
                }
                else
                {
                    //右方
                    res = "左方";
                }
            }
            if(res=="上方")
            {
                //await Savepng();
            }
            else if(res == "下方")
            {
                ApplicationDataContainer c = ApplicationData.Current.LocalSettings;
                if(!c.Values.ContainsKey(date))
                {
                    c.Values.Add(date, responseText);
                }
                Msg("一言收藏成功  "); return;
            }
            else if (res == "右方")
            {
                req();
                if (com.Values["ts1"].ToString() == "0")
                {
                    try
                    {

                        Tiler.ShowTile(hoto, source);
                    }
                    catch { Msg("showtile错误"); }
                }
            }
            else if (res == "左方")
            {
                this.Frame.Navigate(typeof(MyPage));
            }
        }

        private void con_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint p = e.GetCurrentPoint(rec);
            start = p.Position;
        }

        /// <summary>
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。
        /// 此参数通常用于配置页。</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: 准备此处显示的页面。

            // TODO: 如果您的应用程序包含多个页面，请确保
            // 通过注册以下事件来处理硬件“后退”按钮:
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed 事件。
            // 如果使用由某些模板提供的 NavigationHelper，
            // 则系统会为您处理该事件。
            //this.RegisterBackgroundTask(); 
            if (!com.Values.ContainsKey("ts1"))
            {
                com.Values.Add("ts1", "0");
            }
            if (!com.Values.ContainsKey("ts2"))
            {
                com.Values.Add("ts2", "1");
            }
            if (!com.Values.ContainsKey("ts4"))
            {
                com.Values.Add("ts4", "1");
            }
            if (!com.Values.ContainsKey("gtime"))
            {
                com.Values.Add("gtime", 30);
            }
            if (!com.Values.ContainsKey("ts5"))
            {
                com.Values.Add("ts5", "0");
            }
            if (!com.Values.ContainsKey("moban"))
            {
                com.Values.Add("moban", "0");
            }
            if (!com.Values.ContainsKey("Peek1"))
            {
                com.Values.Add("Peek1", "0");
            }
            if (!com.Values.ContainsKey("Peek2"))
            {
                com.Values.Add("Peek2", "0");
            }  
            StatusBar statusbar = StatusBar.GetForCurrentView();
            await statusbar.HideAsync();

            req();


            if (com.Values["ts2"].ToString() == "1") 
            {
                //注册后台任务
                int s = (int)com.Values["gtime"];
                    mytasck.tasck(s);
            }
            if (com.Values["ts4"].ToString() == "0")
            {
                rec.Visibility = Visibility.Visible;
            }
            else
            {
                rec.Visibility = Visibility.Collapsed;
            }
            if (SecondaryTile.Exists("tileId"))
            {
                SecondaryTile tile = new SecondaryTile("tileId");
                bool isDelete = await tile.RequestDeleteAsync();
                await new MessageDialog("为减少BUG，现在已经取消次要磁贴，请自行创建主磁贴(固定到屏幕)").ShowAsync();
            }
            if (!com.Values.ContainsKey("New150607"))
            {
                await new MessageDialog("●一言已经摆脱了网路的束缚\n●部分一言已有专属背景和磁贴更新图片\n●欢迎投稿一言").ShowAsync();
                com.Values.Add("New150607", 0);
            }
            //if (!com.Values.ContainsKey("SQL15607"))
            //{
            //StorageFile databaseFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/note.png"));
            //await databaseFile.CopyAsync(ApplicationData.Current.LocalFolder);
            //com.Values.Add("SQL15607", 0);
            //}
        }
         private void F5png()
        {
            if (source == "龙虎斗" || source == "黑执事" || source == "魔法禁书目录" || source == "魔法少女小圆" || source == "魔卡少女樱" || source == "鬼泣" || source == "食灵" || source == "青之驱魔师" || source == "问题儿童来自异世界" || source == "银魂"
                || source == "钢之炼金术师" || source == "进击的巨人" || source == "通灵王" || source == "这是僵尸吗" || source == "言叶之庭" || source == "美少女战士" || source == "缘之空" || source == "笨蛋测试召唤兽" || source == "穿越时空的少女" || source == "空之境界"
                || source == "秒速五厘米" || source == "火影忍者" || source == "狼与香辛料" || source == "物语" || source == "灼眼的夏娜" || source == "灌篮高手" || source == "潜行吧奈亚子" || source == "海贼王" || source == "死神" || source == "海猫鸣泣之时"
                || source == "某科学的超电磁炮" || source == "柯南" || source == "未闻花名" || source == "无头骑士异闻录" || source == "夏目友人帐" || source == "反叛的鲁鲁修" || source == "EVA" || source == "CLANNAD" || source == "Angel Beats!" || source == "高达"
                || source == "我的青春恋爱物语果然有问题" || source == "我的朋友很少" || source == "幸运星" || source == "寒蝉鸣泣之时" || source == "文学少女")
            {
                switch(source)
                {
                    case"Angel Beats!": spng = "ms-appx:///Assets/Sbg/01.png";break;
                    case "CLANNAD": spng = "ms-appx:///Assets/Sbg/02.png"; break;
                    case "EVA": spng = "ms-appx:///Assets/Sbg/03.png"; break;
                    case "笨蛋测试召唤兽": spng = "ms-appx:///Assets/Sbg/04.png"; break;
                    case "穿越时空的少女": spng = "ms-appx:///Assets/Sbg/05.png"; break;
                    case "反叛的鲁鲁修": spng = "ms-appx:///Assets/Sbg/06.png"; break;
                    case "钢之炼金术师": spng = "ms-appx:///Assets/Sbg/07.png"; break;
                    case "高达": spng = "ms-appx:///Assets/Sbg/08.png"; break;
                    case "灌篮高手": spng = "ms-appx:///Assets/Sbg/09.png"; break;
                    case "鬼泣": spng = "ms-appx:///Assets/Sbg/10.png"; break;
                    case "海猫鸣泣之时": spng = "ms-appx:///Assets/Sbg/11.png"; break;
                    case "海贼王": spng = "ms-appx:///Assets/Sbg/12.png"; break;
                    case "寒蝉鸣泣之时": spng = "ms-appx:///Assets/Sbg/13.png"; break;
                    case "黑执事": spng = "ms-appx:///Assets/Sbg/14.png"; break;
                    case "火影忍者": spng = "ms-appx:///Assets/Sbg/15.png"; break;
                    case "进击的巨人": spng = "ms-appx:///Assets/Sbg/16.png"; break;
                    case "柯南": spng = "ms-appx:///Assets/Sbg/17.png"; break;
                    case "空之境界": spng = "ms-appx:///Assets/Sbg/18.png"; break;
                    case "狼与香辛料": spng = "ms-appx:///Assets/Sbg/19.png"; break;
                    case "龙虎斗": spng = "ms-appx:///Assets/Sbg/20.png"; break;
                    case "美少女战士": spng = "ms-appx:///Assets/Sbg/21.png"; break;
                    case "秒速五厘米": spng = "ms-appx:///Assets/Sbg/22.png"; break;
                    case "魔法禁书目录": spng = "ms-appx:///Assets/Sbg/23.png"; break;
                    case "魔法少女小圆": spng = "ms-appx:///Assets/Sbg/24.png"; break;
                    case "魔卡少女樱": spng = "ms-appx:///Assets/Sbg/25.png"; break;
                    case "某科学的超电磁炮": spng = "ms-appx:///Assets/Sbg/26.png"; break;
                    case "潜行吧奈亚子": spng = "ms-appx:///Assets/Sbg/27.png"; break;
                    case "青之驱魔师": spng = "ms-appx:///Assets/Sbg/28.png"; break;
                    case "食灵": spng = "ms-appx:///Assets/Sbg/29.png"; break;
                    case "死神": spng = "ms-appx:///Assets/Sbg/30.png"; break;
                    case "通灵王": spng = "ms-appx:///Assets/Sbg/31.png"; break;
                    case "未闻花名": spng = "ms-appx:///Assets/Sbg/32.png"; break;
                    case "文学少女": spng = "ms-appx:///Assets/Sbg/33.png"; break;
                    case "问题儿童来自异世界": spng = "ms-appx:///Assets/Sbg/34.png"; break;
                    case "我的朋友很少": spng = "ms-appx:///Assets/Sbg/35.png"; break;
                    case "我的青春恋爱物语果然有问题": spng = "ms-appx:///Assets/Sbg/36.png"; break;
                    case "无头骑士异闻录": spng = "ms-appx:///Assets/Sbg/37.png"; break;
                    case "物语": spng = "ms-appx:///Assets/Sbg/38.png"; break;
                    case "夏目友人帐": spng = "ms-appx:///Assets/Sbg/39.png"; break;
                    case "幸运星": spng = "ms-appx:///Assets/Sbg/40.png"; break;
                    case "言叶之庭": spng = "ms-appx:///Assets/Sbg/41.png"; break;
                    case "银魂": spng = "ms-appx:///Assets/Sbg/42.png"; break;
                    case "缘之空": spng = "ms-appx:///Assets/Sbg/43.png"; break;
                    case "这是僵尸吗": spng = "ms-appx:///Assets/Sbg/44.png"; break;
                    case "灼眼的夏娜": spng = "ms-appx:///Assets/Sbg/45.png"; break;
                }
            }
            else
            {
                int pngint = r.Next(1, 54);
                spng = "ms-appx:///Assets/" + pngint + ".png";
            }
            //更换背景图
            imageBrush.ImageSource = new BitmapImage(new Uri(spng));
            g.Background = imageBrush;
        }
        
          
        private void b_Click(object sender, RoutedEventArgs e)
        {
            String nday = DateTime.Now.Day.ToString();
            String nmonth = DateTime.Now.Month.ToString();
           if (nday == "1" & nmonth == "6")
            {
                if (!com.Values.ContainsKey("JR61"))
                {
                    com.Values.Add("JR61", 0);
                    this.Frame.Navigate(typeof(jieri));
                }
            }
            req();
            

                if (com.Values["ts1"].ToString() == "0")
                {
                    try
                    {

                        Tiler.ShowTile(hoto, source);
                    }
                    catch { }
                }
            //ShowOut();
           
        }

        private void new_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(getNew));
            //try
            //{
            //    w.Visibility = Visibility.Visible;
            //    out1.Visibility = Visibility.Visible;
            //    myyi.Visibility = Visibility.Collapsed;
            //    F5.Visibility = Visibility.Collapsed;
            //    newget.Visibility = Visibility.Collapsed;
            //    bc.Visibility = Visibility.Collapsed;
            //    w.Navigate(new Uri("http://hitokoto.us/new.html"));
            //}
            //catch
            //{
            //    Msg("没有网络"); return;
            //}
        }


        private void my_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MyPage));
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer c = ApplicationData.Current.LocalSettings;
               //遍历c中有多少数据
                
                //ApplicationDataContainer com = ApplicationData.Current.LocalSettings.CreateContainer("", ApplicationDataCreateDisposition.Always);
                //ApplicationDataCompositeValue a = new ApplicationDataCompositeValue();
                //com.Values.Add(item,a);
                if(!c.Values.ContainsKey(date))
                {
                    c.Values.Add(date, responseText);
                }
                //outbug("收藏成功"); return;
                Msg("一言收藏成功  "); return;
        }

        
        private void Gy_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(about));
        }


        //类

        //private void ShowOut()
        //{
        //    XmlDocument badgeXml = BadgeUpdateManager.GetTemplateContent(BadgeTemplateType.BadgeGlyph);
        //    XmlElement badgeElement = (XmlElement)badgeXml.SelectSingleNode("/badge");
        //    badgeElement.SetAttribute("value", "newMessage");
        //    BadgeNotification badge = new BadgeNotification(badgeXml);
        //    BadgeUpdateManager.CreateBadgeUpdaterForApplication().Update(badge);
        //}
        private SQLiteAsyncConnection GetConn()
        {

            return new SQLiteAsyncConnection(ApplicationData.Current.LocalFolder.Path + "\\note.png");

        }
        private async void req()
        {
            if (!com.Values.ContainsKey("SQL15607"))
            {
                StorageFile databaseFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/note.png"));
                await databaseFile.CopyAsync(ApplicationData.Current.LocalFolder);
                com.Values.Add("SQL15607", 0);
                SQLiteAsyncConnection con = GetConn();
                var res = await con.Table<Note>().ToListAsync();
                sql.Values.Clear();
                foreach (var i in res)
                {
                    responseText = "{\"hitokoto\":\"" + i.hitokoto + "\",\"cat\":\"" + i.cat + "\",\"author\":\"" + i.author + "\",\"source\":\"" + i.source + "\",\"like\":" + i.like + ",\"date\":\"" + i.date + "\",\"catname\":\"" + i.catname + "\",\"id\":" + i.id + "}";
                    if (!sql.Values.ContainsKey(i.No.ToString()))
                        sql.Values.Add(i.No.ToString(), responseText);
                }
            }
            mt.Text = "正在加载...";
            mg.Visibility = Visibility.Visible;
            int ii = r.Next(0, 471);
            JsonObject hito = JsonObject.Parse(sql.Values[ii.ToString()] as String);
            String hitokoto = hito.GetNamedString("hitokoto");
            String cat = hito.GetNamedString("cat");
            String author = hito.GetNamedString("author");
            source = hito.GetNamedString("source");
            date = hito.GetNamedString("date");
            String catname = hito.GetNamedString("catname");
            if (com.Values["ts5"].ToString() == "0")
            {
                hoto = hitokoto;
            }
            else
            {
                if (source == "")
                {
                    hoto = hitokoto;
                }
                else
                {
                    hoto = hitokoto + "——" + source;
                }
            }
            a.Text = "『" + hitokoto + "』";
            a1.Text = "分类：" + catname;
            a2.Text = "投稿：" + author;
            if (source == "")
            {
                a3.Text = "无出处";
            }
            else
            {
                a3.Text = "出自：" + source;
            }
            a4.Text = "@" + date;
            //更换背景图
            F5png();
            mg.Visibility = Visibility.Collapsed;
            responseText = sql.Values[ii.ToString()] as String;
        }

        private async void outbug(String s)
        {

            await new MessageDialog(s).ShowAsync();
        }
        private async void RegisterBackgroundTask()
        {
            var backgroundAccessStatus = await BackgroundExecutionManager.RequestAccessAsync();
            if (backgroundAccessStatus == BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity ||
                backgroundAccessStatus == BackgroundAccessStatus.AllowedWithAlwaysOnRealTimeConnectivity)
            {
                foreach (var task in BackgroundTaskRegistration.AllTasks)
                {
                    if (task.Value.Name == taskName)
                    {
                        task.Value.Unregister(true);
                    }
                }

                BackgroundTaskBuilder taskBuilder = new BackgroundTaskBuilder();
                taskBuilder.Name = taskName;
                taskBuilder.TaskEntryPoint = taskEntryPoint;
                taskBuilder.SetTrigger(new TimeTrigger(15, false));
                var registration = taskBuilder.Register();
            }
        } 
        private async void loadtext(String s)
        {
            await StatusBar.GetForCurrentView().ShowAsync();

            var progInd = StatusBar.GetForCurrentView().ProgressIndicator;
            progInd.Text = s;

            await progInd.ShowAsync();
        }

        private void Msg(String s)
        {
            mt.Text = s;
            mg.Visibility = Visibility.Visible;
            dt.Interval = TimeSpan.FromSeconds(2);
            dt.Tick += timer_Tick;
            dt.Start();

        }
        private void timer_Tick(object sender, object e)
        {
            mg.Visibility = Visibility.Collapsed;
            dt.Stop();
        }




        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            await Savepng();
        }

        private async System.Threading.Tasks.Task Savepng()
        {
            StorageFolder folder = KnownFolders.SavedPictures;
            //BitmapImage bitmap = new BitmapImage(new Uri(spng));
            //imageBrush.ImageSource = new BitmapImage(new Uri(spng));
            //  RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap();
            //  await renderTargetBitmap.RenderAsync(g);
            //  BitmapDecoder bd ;
            //  ImageStream si;
            //  var pixelBuffer = await renderTargetBitmap.GetPixelsAsync();
            //await FileIO.WriteTextAsync(file, "我是刚刚写入的数据", Windows.Storage.Streams.UnicodeEncoding.Utf8);
            StorageFolder f = ApplicationData.Current.LocalFolder;
            //IReadOnlyList<StorageFolder> list;
            //list = await f.GetFoldersAsync() as IReadOnlyList<StorageFolder>;
            //foreach(var i in list)
            //{
            //    StorageFolder sf =i;
            //}
            StorageFile fp = await StorageFile.GetFileFromApplicationUriAsync(new Uri(spng));
            Stream st = await fp.OpenStreamForReadAsync();
            byte[] bytes = new byte[st.Length];
            st.Read(bytes, 0, bytes.Length);
            //foreach (var i in f.)
            //{
            //    String s = i.Key;
            //    if(spng==i.Key)
            //    {

            //        obji = i.Value;
            //    }
            //}
            //DataContractSerializer ser = new DataContractSerializer(typeof(object));
            //MemoryStream rems = new MemoryStream();
            //ser.WriteObject(rems, fp);
            //byte[] by = rems.ToArray();
            StorageFile file = await folder.CreateFileAsync("一言.png", CreationCollisionOption.GenerateUniqueName);
            await FileIO.WriteBytesAsync(file, bytes);
            Msg("图片保存完成  ");
        }

        private void setts_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Setts));
        }
        private void RegisterForShare()
        {
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += new TypedEventHandler<DataTransferManager,
                DataRequestedEventArgs>(this.ShareTextHandler);
           DataTransferManager.ShowShareUI();
        }

        private void ShareTextHandler(DataTransferManager sender, DataRequestedEventArgs e)
        {
            DataRequest request = e.Request;
            request.Data.Properties.Title = "一言  ";
            request.Data.Properties.Description = hoto;
            request.Data.SetText(hoto);
        }

        private void share_Click(object sender, RoutedEventArgs e)
        {
            RegisterForShare();
        }
        
    }
}
