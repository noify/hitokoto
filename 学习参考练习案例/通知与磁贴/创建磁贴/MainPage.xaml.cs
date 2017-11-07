using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.StartScreen;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=391641 上有介绍

namespace 创建磁贴
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string tileId="tileId";
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。
        /// 此参数通常用于配置页。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: 准备此处显示的页面。

            // TODO: 如果您的应用程序包含多个页面，请确保
            // 通过注册以下事件来处理硬件“后退”按钮:
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed 事件。
            // 如果使用由某些模板提供的 NavigationHelper，
            // 则系统会为您处理该事件。
            //判断磁贴是否存在，如果存在则修改文本删除磁贴
           if(SecondaryTile.Exists(tileId))
           {
               b.Visibility = Visibility.Collapsed;
               b1.Visibility = Visibility.Visible;
           }
            else
           {
               b1.Visibility = Visibility.Collapsed;
               b.Visibility = Visibility.Visible;
           }
        }

        
       
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            b.Visibility = Visibility.Collapsed;
            b1.Visibility = Visibility.Visible;
            //构造方法SecondaryTile
            //wp中有一个uri访问方案
            //凡是在手机安装包中的文件使用
            //ms-appx:///来访问
            Uri uri = new Uri("ms-appx:///Assets/Logo.png");
            SecondaryTile tile = new SecondaryTile(
                tileId,
                "返回给磁贴使用的代码的参数",
                "显示的名字",
                uri,
                TileSize.Square150x150
                );
            tile.VisualElements.Wide310x150Logo = new Uri("ms-appx:///Assets/WideLogo.png");
            tile.VisualElements.Square71x71Logo = new Uri("ms-appx:///Assets/Square71x71Logo.png");
            tile.VisualElements.ShowNameOnWide310x150Logo = true;
            tile.VisualElements.ShowNameOnSquare150x150Logo = true;
            await tile.RequestCreateAsync();

            
        }

        private async void b1_Click(object sender, RoutedEventArgs e)
        {
            b1.Visibility = Visibility.Collapsed;
            b.Visibility = Visibility.Visible;
            //删除
            //先获得磁贴，然后调用RequestDeleteAsync方法
            SecondaryTile tile = new SecondaryTile(tileId);
            bool isDelete = await tile.RequestDeleteAsync();
            if(isDelete)
            {
                await new MessageDialog("磁贴已删除").ShowAsync();
            }
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            //创建磁贴通知
            XmlDocument xml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150Text01);
            XmlNodeList list = xml.GetElementsByTagName("text");
            //添加消息
            list[0].AppendChild(xml.CreateTextNode("我是大标题"));
            list[1].AppendChild(xml.CreateTextNode("第一行文字"));
            list[2].AppendChild(xml.CreateTextNode("第二行文字"));
            list[3].AppendChild(xml.CreateTextNode("第三行文字"));
            list[4].AppendChild(xml.CreateTextNode("第四行文字"));
            TileNotification tn = new TileNotification(xml);
            //设置消息消失时间
            tn.ExpirationTime = DateTime.Now.AddSeconds(10);
            //显示消息
            TileUpdateManager.CreateTileUpdaterForSecondaryTile(tileId).Update(tn);
        }
    }
}
