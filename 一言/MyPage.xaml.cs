using 一言.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using Windows.UI.Popups;
using Windows.Data.Json;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.StartScreen;
using System.Runtime.Serialization;

// “基本页”项模板在 http://go.microsoft.com/fwlink/?LinkID=390556 上有介绍

namespace 一言
{
    /// <summary>
    /// 可独立使用或用于导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MyPage : Page
    {

        String a,b;
        List<String> cblist = new List<string>();
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        ApplicationDataContainer com = ApplicationData.Current.LocalSettings.CreateContainer("setting", ApplicationDataCreateDisposition.Always);
        public MyPage()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
            //准备集合
            ObservableCollection<ListBinding> l = new ObservableCollection<ListBinding>();
            list.ItemsSource = l;
        }

        /// <summary>
        /// 获取与此 <see cref="Page"/> 关联的 <see cref="NavigationHelper"/>。
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// 获取此 <see cref="Page"/> 的视图模型。
        /// 可将其更改为强类型视图模型。
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// 使用在导航过程中传递的内容填充页。  在从以前的会话
        /// 重新创建页时，也会提供任何已保存状态。
        /// </summary>
        /// <param name="sender">
        /// 事件的来源; 通常为 <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">事件数据，其中既提供在最初请求此页时传递给
        /// <see cref="Frame.Navigate(Type, Object)"/> 的导航参数，又提供
        /// 此页在以前会话期间保留的状态的
        /// 字典。 首次访问页面时，该状态将为 null。</param>
        
        private void ShowList()
        {
            ObservableCollection<ListBinding> collection = list.ItemsSource as ObservableCollection<ListBinding>;
            ApplicationDataContainer c = ApplicationData.Current.LocalSettings;
            //遍历c中有多少数据
            foreach (var i in c.Values)
            {
                JsonObject hito = null;

                try
                {
                    hito = JsonObject.Parse(i.Value as String);
                }
                catch {Msg("由于以前版本缓存错误，建议重新安装解决"); return; }
                String hitokoto = hito.GetNamedString("hitokoto");
                String cat = hito.GetNamedString("cat");
                String author = hito.GetNamedString("author");
                String source = hito.GetNamedString("source");
                String catname = hito.GetNamedString("catname");
                a = "『" + hitokoto + "』";
                String a1 = catname;
                String a2 = "投稿：" + author;
                String a3;
                if (source == "")
                {
                    a3 = "无出处";
                }
                else
                {
                    a3 = "by" + source;
                }
                String a4 = "@" + i.Key;
                collection.Add(new ListBinding() { ListViewButtonName = i.Key, ListViewText = a, ListViewText2 = a1+ "  " +a3+ "  " +a4 });
            }
        }
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            ObservableCollection<ListBinding> collection = list.ItemsSource as ObservableCollection<ListBinding>;
            collection.Clear();
            ShowList();
            //ImageBrush imageBrush = new ImageBrush(); 
            //imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/01.png"));
            //gr.Background = imageBrush;
            //tbg.Background = imageBrush;
        }

        /// <summary>
        /// 保留与此页关联的状态，以防挂起应用程序或
        /// 从导航缓存中放弃此页。值必须符合
        /// <see cref="SuspensionManager.SessionState"/> 的序列化要求。
        /// </summary>
        /// <param name="sender">事件的来源；通常为 <see cref="NavigationHelper"/></param>
        ///<param name="e">提供要使用可序列化状态填充的空字典
        ///的事件数据。</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper 注册

        /// <summary>
        /// 此部分中提供的方法只是用于使
        /// NavigationHelper 可响应页面的导航方法。
        /// <para>
        /// 应将页面特有的逻辑放入用于
        /// <see cref="NavigationHelper.LoadState"/>
        /// 和 <see cref="NavigationHelper.SaveState"/> 的事件处理程序中。
        /// 除了在会话期间保留的页面状态之外
        /// LoadState 方法中还提供导航参数。
        /// </para>
        /// </summary>
        /// <param name="e">提供导航方法数据和
        /// 无法取消导航请求的事件处理程序。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox btn = (CheckBox)sender;
            cblist.Add(btn.DataContext.ToString());
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox btn = (CheckBox)sender;
            cblist.Remove(btn.DataContext.ToString());
        }

        private void sc_Click(object sender, RoutedEventArgs e)
        {
            if(cblist.Count==0)
            {
                Msg("请选择你需要删除的一言  ");
            }
            else
            {

                ApplicationDataContainer c = ApplicationData.Current.LocalSettings;
                foreach(var i in cblist)
                {
                    if (c.Values.ContainsKey(i.ToString()))
                    {
                        c.Values.Remove(i.ToString());
                        ObservableCollection<ListBinding> collection = list.ItemsSource as ObservableCollection<ListBinding>;
                        collection.Clear();
                        ShowList();
                        Msg("删除成功  ");
                    }
                }
                cblist.Clear();
            }

            //cblist.Clear();
        }
        DispatcherTimer dt = new DispatcherTimer();
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

        //private void qd_Click(object sender, RoutedEventArgs e)
        //{
        //    tb.Visibility = Visibility.Collapsed;
        //    tb1.Visibility = Visibility.Collapsed;
        //    qd.Visibility = Visibility.Collapsed;
        //    qx.Visibility = Visibility.Collapsed;
        //    sc.Visibility = Visibility.Visible;
        //    tj.Visibility = Visibility.Visible;
        //    tb2.Visibility = Visibility.Collapsed;
        //    tbg.Visibility = Visibility.Collapsed;
        //    show.Visibility = Visibility.Visible;
        //    String daten = DateTime.Now.ToString();
        //    String s = "{\"hitokoto\":\"" + tb.Text + "\",\"cat\":\"\",\"author\":\"\",\"source\":\""+tb2.Text+"\",\"like\":29,\"date\":\"\",\"catname\":\"" + tb1.Text + "\",\"id\":1319085892000}";
        //    tb.Text = tb1.Text = tb2.Text = "";
        //    ApplicationDataContainer c = ApplicationData.Current.LocalSettings;
        //    try
        //    {
        //        ApplicationData.Current.LocalSettings.Values.Add(daten, s);
        //    }
        //    catch
        //    {
        //        Msg("已保存过"); return;
        //    }
        //    Msg("保存成功"); 
        //    ObservableCollection<ListBinding> collection = list.ItemsSource as ObservableCollection<ListBinding>;
        //    collection.Clear();
        //    ShowList();
        //}


        private void tj_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MyNew));
            //tb.Visibility = Visibility.Visible;
            //tb1.Visibility = Visibility.Visible;
            //qd.Visibility = Visibility.Visible;
            //qx.Visibility = Visibility.Visible;
            //sc.Visibility = Visibility.Collapsed;
            //tj.Visibility = Visibility.Collapsed;
            //tb2.Visibility = Visibility.Visible;
            //tbg.Visibility = Visibility.Visible;
            //show.Visibility = Visibility.Collapsed;
        }

        //private void qx_Click(object sender, RoutedEventArgs e)
        //{
        //    tb.Visibility = Visibility.Collapsed;
        //    tb1.Visibility = Visibility.Collapsed;
        //    qd.Visibility = Visibility.Collapsed;
        //    qx.Visibility = Visibility.Collapsed;
        //    sc.Visibility = Visibility.Visible;
        //    tj.Visibility = Visibility.Visible;
        //    tb2.Visibility = Visibility.Collapsed;
        //    tbg.Visibility = Visibility.Collapsed;
        //    show.Visibility = Visibility.Visible;

        //}
        private async void show_Click(object sender, RoutedEventArgs e)
        {
            
            if (cblist.Count != 1 && cblist.Count != 0)
            {
                Msg("只能选择一项  ");
            }
            else if(cblist.Count == 0)
            {
                Msg("请选择你需要发送的一言  ");
            }
            else
            {

                ApplicationDataContainer c = ApplicationData.Current.LocalSettings;
                foreach (var i in c.Values)
                {
                    if (i.Key==cblist[0].ToString())
                    {
                        try
                        {
                            a = JsonObject.Parse(i.Value as String).GetNamedString("hitokoto");
                            String source = JsonObject.Parse(i.Value as String).GetNamedString("source");
                            if (com.Values["ts5"].ToString() == "0")
                            {
                            }
                            else
                            {
                                if (source == "")
                                {
                                }
                                else
                                {
                                    a = a + "——" + source;
                                }
                            }
                            Tiler.ShowTile(a, source);
                            Msg("发送成功  ");
                            if (!com.Values.ContainsKey("jg1"))
                            {
                                await new MessageDialog("如需发送我的一言,需将[设置]里的[自动更新磁贴]以及[后台更新磁贴]关闭,因为你发送出去的一言可能会被自动或者后台更新的一言所取代").ShowAsync();
                                com.Values.Add("jg1", "0");
                            }
                        }
                        catch { }
                        
                    }
                }

            }
        }

        private void lb_Click(object sender, RoutedEventArgs e)
        {
            if (cblist.Count != 1 && cblist.Count != 0)
            {
                Msg("只能选择一项  ");
            }
            else if (cblist.Count == 0)
            {
                Msg("请选择你需要编辑的一言  ");
            }
            else
            {
                ApplicationDataContainer c = ApplicationData.Current.LocalSettings;
                foreach (var i in c.Values)
                {
                    if (i.Key == cblist[0].ToString())
                    {
                        b = i.Value as String;
                        this.Frame.Navigate(typeof(ChangeNew), b);
                    }
                }
            }
        }


    }
}
