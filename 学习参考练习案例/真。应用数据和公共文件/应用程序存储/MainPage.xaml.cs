using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=391641 上有介绍

namespace 应用程序存储
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int num = 0;
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
            //保存数据
            //首先获得用户提供的数据
            //判断是否有容器
            //如果有容器就需要创建容器后再存储
            //如果没有容器就直接存储
            //刷新显示
            string container = txtContainer.Text.Trim();
            string inputKey = txtData.Text.Trim();
            ApplicationDataContainer c = ApplicationData.Current.LocalSettings;
            if (container.Length == 0 && inputKey.Length == 0) return;
            if (container.Length == 0)
            {
                foreach (var i in c.Values)
                {
                    if (i.Key == inputKey)
                    {
                        await new MessageDialog("已存在该键").ShowAsync(); return;
                    }

                }
            }
            else
            {
                foreach (var i in c.Containers)
                {

                    foreach (var subItem in i.Value.Values)
                    {
                        if (subItem.Key == inputKey)
                        {
                            await new MessageDialog("已存在该键").ShowAsync(); return;
                        }

                    }
                }

            }
            
            
            
            //表示用户没有数据
            if (container.Length == 0 && inputKey.Length == 0) return;
            if(container.Length==0)
            {
                //没有输入容器名
                ApplicationData.Current.LocalSettings.Values.Add(inputKey, "保存的值" + (num++));
            }
            else
            {
                //表示有容器名
                //创建容器
                ApplicationDataContainer com= ApplicationData.Current.LocalSettings.CreateContainer(container, ApplicationDataCreateDisposition.Always);
                //com.Values.Add(inputKey, "保存的值" + (num++));
                ApplicationDataCompositeValue a = new ApplicationDataCompositeValue();
                a.Add("键1", "值1");
                a.Add("键2", "值2");
                a.Add("键3", "值3");
                com.Values.Add(inputKey,a);

            }
            ShowDataContainer();
        }
        private void ShowDataContainer()
        {
            //将容器中的数据取出来展示
            ApplicationDataContainer c = ApplicationData.Current.LocalSettings;
            //遍历c中有多少数据
            List<string> list = new List<string>();
            foreach(var i in c.Values)
            {
                list.Add("根数据：" + i.Key + "," + i.Value);

            }
            //遍历其容器
            foreach (var i in c.Containers)
            {
                list.Add("子容器：" + i.Key + ",里面的数据有");
                foreach (var subItem in i.Value.Values)
                {
                    list.Add(" 子容器中数据：" + subItem.Key + "," + i.Value);

                }
            }
            res.Text = string.Join("\r\n" , list);
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string container = txtContainer.Text.Trim();
            string inputKey = txtData.Text.Trim();
            ApplicationDataContainer c = ApplicationData.Current.LocalSettings;
            if (container.Length == 0 && inputKey.Length == 0) return;
            if (container.Length == 0)
            {
                //在根容器处
                if (c.Values.ContainsKey(txtData.Text))
                {
                    c.Values.Remove(txtData.Text);
                    ShowDataContainer();
                }
                else
                {
                    await new MessageDialog("不存在该键").ShowAsync();
                }
            }
            else
            {
                ApplicationDataContainer com = ApplicationData.Current.LocalSettings.CreateContainer(container, ApplicationDataCreateDisposition.Always);
                if (com.Values.ContainsKey(txtData.Text))
                {
                    com.Values.Remove(txtData.Text);
                    ShowDataContainer();
                }
                else
                {
                    await new MessageDialog("不存在该键").ShowAsync();
                }

            }
            
        }
    }
}
