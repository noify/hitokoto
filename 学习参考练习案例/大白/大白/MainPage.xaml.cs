using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=391641 上有介绍

namespace 大白
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
            if (tb.Text == "我是密码")
            {
                tb1.Text = "(●—●)";
               // i1.Visibility = Visibility.Visible ;
                tb2.Text = "你好,我是大白,你的私人健康顾问!1到10的十个等级里,你用几来形容你的疼痛?";
            }
            if (tb.Text == "10")
            {
                i1.Visibility = Visibility.Collapsed;
                i2.Visibility = Visibility.Visible;
                tb2.Text = "正在扫描你的身体.....";
            }
            if (tb.Text == "我还有救嘛?")
            {
                i1.Visibility = Visibility.Collapsed;
                i2.Visibility = Visibility.Collapsed;
                i3.Visibility = Visibility.Visible;
                tb2.Text = "扫描完成,你的大脑水含量严重超标,怀疑是脑进水,无法治疗!请问你对我的服务满意嘛";
            }
            if(tb.Text == "不满意")
            {
                tb2.Text = "无法治疗!请问你对我的服务满意嘛";
            }
            if(tb.Text=="满意")
            {
                i3.Visibility = Visibility.Collapsed;
                tb2.Text = "谢谢你的评价";
                tb1.Text = "(-—-)";
            }
        }
    }
}
