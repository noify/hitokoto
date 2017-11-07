using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=391641 上有介绍

namespace Toast通知
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument xml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);
            //往模版中添加数据
            XmlNodeList nodeList = xml.GetElementsByTagName("text");
            //此时已经是所有的text标签了
            nodeList[0].AppendChild(xml.CreateTextNode("我是第一个Toast通知"));
            //创建通知对象
            ToastNotification tn = new ToastNotification(xml);
            //显示通知
            ToastNotificationManager.CreateToastNotifier().Show(tn);
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            XmlDocument xml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            //选中第二个模版就需要两段文本
            XmlNodeList nodeList = xml.GetElementsByTagName("text");

            nodeList[0].AppendChild(xml.CreateTextNode("第二个案例的标题"));
            nodeList[1].AppendChild(xml.CreateTextNode("第二个案例的内容"));
            //创建通知对象
            ToastNotification tn = new ToastNotification(xml);
            //显示通知
            ToastNotificationManager.CreateToastNotifier().Show(tn);
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            string xmlString = @"<toast>
    <visual>
        <binding template=""ToastText03"">
            <text id=""1"">{0}</text>
            <text id=""2"">{1}</text>
        </binding>  
    </visual>
</toast>";
            xmlString = string.Format(xmlString, "你好", "hi");
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlString);
            //创建通知对象
            ToastNotification tn = new ToastNotification(xml);
            //显示通知
            ToastNotificationManager.CreateToastNotifier().Show(tn);
        }
    }
}
