using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=391641 上有介绍

namespace 使用HttpClient获取网络数据
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //查询单词
            string wd = wds.Text.Trim();
            if (wd.Length == 0) return;
            string searchUri = "http://www.bing.com/dict/search?intlF=0&q=" + wd;
            HttpClient client = new HttpClient();
            string html =await client.GetStringAsync(searchUri);
            //def.+?</li>
            MatchCollection mc = Regex.Matches(html,@"""def""([\s\S]+?)</li>");
            List<string> list = new List<string>();
            for(int i=0;i<mc.Count;i++)
            {
                list.Add(mc[i].Groups[1].Value);
            }
            res.Text = string.Join("\r\n", list);
        }
    }
}
