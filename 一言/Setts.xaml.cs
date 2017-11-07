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
using Windows.System;
using Windows.UI.StartScreen;
using Windows.ApplicationModel.Background;
using Microsoft.Live;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;
using Windows.Storage.Pickers;
using Windows.ApplicationModel.Activation;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Graphics.Imaging;
using System.Diagnostics;
using Windows.Phone.UI.Input;
using Windows.UI;

// “基本页”项模板在 http://go.microsoft.com/fwlink/?LinkID=390556 上有介绍

namespace 一言
{
    /// <summary>
    /// 可独立使用或用于导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Setts : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public Setts()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
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
        /// 
        ApplicationDataContainer c = ApplicationData.Current.LocalSettings;

        static ApplicationDataContainer com = ApplicationData.Current.LocalSettings.CreateContainer("setting", ApplicationDataCreateDisposition.Always);
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            //if (SecondaryTile.Exists("tileId"))
            //{
            //    ts3.IsOn = true;
            //}
            //else
            //{
            //    ts3.IsOn = false;
            //}
            if (com.Values["ts1"].ToString() == "0")
            {
                ts1.IsOn = true; 
            }
            else
            {
                ts1.IsOn = false;
            }
            if (com.Values["ts2"].ToString() == "0")
            {
                cat.SelectedIndex = 0;
            }
            else if (com.Values["ts2"].ToString() == "1")
            {
                cat.SelectedIndex = 1;
            }
            else
            {
                cat.SelectedIndex = 2;
            }
            if (com.Values["ts4"].ToString() == "0")
            {
                ts4.IsOn = true;
            }
            else
            {
                ts4.IsOn = false;
            }
            if (com.Values["gtime"].ToString() == "30")
            {
                gtime.SelectedIndex = 0;
            }
            else if (com.Values["gtime"].ToString() == "60")
            {
                gtime.SelectedIndex = 1;
            }
            else if (com.Values["gtime"].ToString() == "180")
            {
                gtime.SelectedIndex = 2;
            }
            else if (com.Values["gtime"].ToString() == "360")
            {
                gtime.SelectedIndex = 3;
            }
            else
            {
                gtime.SelectedIndex = 4;
            }
            if (com.Values["ts5"].ToString() == "0")
            {
                ts5.IsOn = false;
            }
            else
            {
                ts5.IsOn = true;
            }
            if (com.Values["moban"].ToString() == "0")
            {
                moban.SelectedIndex = 0;
            }
            else if (com.Values["moban"].ToString() == "1")
            {
                moban.SelectedIndex = 1;
            }
            else if (com.Values["moban"].ToString() == "2")
            {
                moban.SelectedIndex = 2;
            }
            else if (com.Values["moban"].ToString() == "3")
            {
                moban.SelectedIndex = 3;
            }
            if (com.Values["Peek1"].ToString() == "1" && com.Values["moban"].ToString() == "1"&&com.Values.ContainsKey("PeekName1"))
            {
                ImageBrush imageBrush = new ImageBrush();
                imageBrush.ImageSource = new BitmapImage(new Uri("ms-appdata:///Local/PeekName1/" + com.Values["PeekName1"].ToString() + ".png"));
                    PeekImage.Source = imageBrush.ImageSource;
            }
            if (com.Values["moban"].ToString() == "2")
            {
                if ( com.Values.ContainsKey("PeekName21"))
                {
                    ImageBrush imageBrush = new ImageBrush();
                    imageBrush.ImageSource = new BitmapImage(new Uri("ms-appdata:///Local/PeekName21/" + com.Values["PeekName21"].ToString() + ".png"));
                    PeekImage21.Source = imageBrush.ImageSource;
                }   if (com.Values.ContainsKey("PeekName22"))
                {
                    ImageBrush imageBrush = new ImageBrush();
                    imageBrush.ImageSource = new BitmapImage(new Uri("ms-appdata:///Local/PeekName22/" + com.Values["PeekName22"].ToString() + ".png"));
                    PeekImage22.Source = imageBrush.ImageSource;
                }  if (com.Values.ContainsKey("PeekName23"))
                {
                    ImageBrush imageBrush = new ImageBrush();
                    imageBrush.ImageSource = new BitmapImage(new Uri("ms-appdata:///Local/PeekName23/" + com.Values["PeekName23"].ToString() + ".png"));
                    PeekImage23.Source = imageBrush.ImageSource;
                }  if (com.Values.ContainsKey("PeekName24"))
                {
                    ImageBrush imageBrush = new ImageBrush();
                    imageBrush.ImageSource = new BitmapImage(new Uri("ms-appdata:///Local/PeekName24/" + com.Values["PeekName24"].ToString() + ".png"));
                    PeekImage24.Source = imageBrush.ImageSource;
                }  if (com.Values.ContainsKey("PeekName25"))
                {
                    ImageBrush imageBrush = new ImageBrush();
                    imageBrush.ImageSource = new BitmapImage(new Uri("ms-appdata:///Local/PeekName25/" + com.Values["PeekName25"].ToString() + ".png"));
                    PeekImage25.Source = imageBrush.ImageSource;
                } 
            }
                
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


        private void gy_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(about));
        }
        private void ts1_Toggled(object sender, RoutedEventArgs e)
        {
            com.Values.Remove("ts1");
            ToggleSwitch ts1b = (ToggleSwitch)sender;
            if (ts1b.IsOn == true)
            {
                com.Values.Add("ts1", "0");
            }
            else
            {
                com.Values.Add("ts1", "1");
            }
        }

        private void ts2_Toggled(object sender, RoutedEventArgs e)
        {
            
            //var task = BackgroundTaskRegistration.AllTasks.Values.FirstOrDefault(t => t.Name == "tack1");
            //com.Values.Remove("ts2");
            //ToggleSwitch ts2b = (ToggleSwitch)sender;
            //if (ts2b.IsOn == true)
            //{
            //    com.Values.Add("ts2", "0");
            //    if (task == null)
            //    {
            //        var res = await BackgroundExecutionManager.RequestAccessAsync();
            //        if (res != BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity)
            //            return;

            //        // 注册
            //        BackgroundTaskBuilder bd = new BackgroundTaskBuilder();
            //        bd.Name = "tack1"; //任务名
            //        bd.TaskEntryPoint = "Basktask.task1"; //入口点
            //        // 设置触发器为计时器
            //        bd.SetTrigger(new TimeTrigger(30, false));
            //        BackgroundTaskRegistration reg = bd.Register();
            //        // 注册成功，显示结果
            //    }
            //}
            //else
            //{
            //    com.Values.Add("ts2", "1");
            //    if (task != null)
            //    {
            //        // 取消
            //        task.Unregister(true);
            //    }
            //}
        }

        //private async void ts3_Toggled(object sender, RoutedEventArgs e)
        //{
        //    ToggleSwitch ts3b = (ToggleSwitch)sender;
        //    if (ts3b.IsOn == true)
        //    {
        //        Uri uri = new Uri("ms-appx:///Assets/Logo.png");
        //        SecondaryTile tile = new SecondaryTile(
        //            "tileId",
        //            "一言",
        //            "显示的名字",
        //            uri,
        //            TileSize.Wide310x150
        //            );
        //        tile.VisualElements.Wide310x150Logo = new Uri("ms-appx:///Assets/WideLogo.png");
        //        //tile.VisualElements.Square71x71Logo = new Uri("ms-appx:///Assets/Square71x71Logo.png");
        //        tile.VisualElements.ShowNameOnWide310x150Logo = true;
        //        await tile.RequestCreateAsync();
        //    }
        //    else
        //    {
        //        SecondaryTile tile = new SecondaryTile("tileId");
        //        bool isDelete = await tile.RequestDeleteAsync();
        //    }
        //}

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            bool success = await Launcher.LaunchUriAsync(new Uri("ms-settings-lock:"));
        }
        private void cat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ComboBox cats = (ComboBox)sender;
            var taskt = BackgroundTaskRegistration.AllTasks.Values;
            com.Values.Remove("ts2");
            if(cats.SelectedIndex == 0)
            {
                com.Values.Add("ts2", "0");
                foreach (var i in taskt)
                {
                    i.Unregister(true);
                }
                ggtime.Visibility = Visibility.Collapsed;
                ggtime1.Visibility = Visibility.Collapsed;
            }
            else if(cats.SelectedIndex == 1)
            {
                com.Values.Add("ts2", "1");
                int s = (int)com.Values["gtime"];
                mytasck.tasck(s);
                ggtime.Visibility = Visibility.Visible;
                ggtime1.Visibility = Visibility.Visible;
            }
            else
            {
                    com.Values.Add("ts2", "2");
                    int s = (int)com.Values["gtime"];
                    mytasck.tasck(s);
                    ggtime.Visibility = Visibility.Visible;
                    ggtime1.Visibility = Visibility.Visible;
            }
        }

        private void ts4_Toggled(object sender, RoutedEventArgs e)
        {
            com.Values.Remove("ts4");
            ToggleSwitch ts4b = (ToggleSwitch)sender;
            if (ts4b.IsOn == true)
            {
                com.Values.Add("ts4", "0");
            }
            else
            {
                com.Values.Add("ts4", "1");
            }
        }

        private void gtime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox gtimes = (ComboBox)sender;
            com.Values.Remove("gtime");
            if (gtimes.SelectedIndex == 0)
            {
                com.Values.Add("gtime", 30);
            }
            else if (gtimes.SelectedIndex == 1)
            {
                com.Values.Add("gtime", 60);
            }
            else if (gtimes.SelectedIndex == 2)
            {
                com.Values.Add("gtime", 180);
            }
            else if (gtimes.SelectedIndex == 3)
            {
                com.Values.Add("gtime", 360);
            }
            else
            {
                com.Values.Add("gtime", 720);
            }
            int s = (int)com.Values["gtime"];
                mytasck.tasck(s);
            
        }

        private void ts5_Toggled(object sender, RoutedEventArgs e)
        {
            com.Values.Remove("ts5");
            ToggleSwitch ts1b = (ToggleSwitch)sender;
            if (ts1b.IsOn == false)
            {
                com.Values.Add("ts5", "0");
            }
            else
            {
                com.Values.Add("ts5", "1");
            }
        }

        private void c_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            openpng();
            com.Values.Remove("Peek1");
            com.Values.Add("Peek1", "1");
        }

        private static void openpng()
        {
            FileOpenPicker openPicker = new FileOpenPicker();

            openPicker.ViewMode = PickerViewMode.Thumbnail;

            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;

            openPicker.FileTypeFilter.Add(".jpg");

            openPicker.FileTypeFilter.Add(".jpeg");

            openPicker.FileTypeFilter.Add(".png");

            openPicker.PickSingleFileAndContinue();
        }
        FileOpenPickerContinuationEventArgs _filePickerEventArgs = null;

        public FileOpenPickerContinuationEventArgs FilePickerEvent
        {

            get { return _filePickerEventArgs; }

            set
            {

                _filePickerEventArgs = value;

                ContinueFileOpenPicker(_filePickerEventArgs);

            }

        }
        public async void ContinueFileOpenPicker(FileOpenPickerContinuationEventArgs args)
        {

            if (args.Files != null && args.Files.Count > 0)
            {

                StorageFile file = args.Files[0];
                
                IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);

                BitmapImage bitmapImage = new BitmapImage();

                bitmapImage.SetSource(fileStream);

                ImageBrush newback = new ImageBrush();
                if (com.Values["Peek1"].ToString() == "1" && com.Values["moban"].ToString() == "1")
                {
                    await SavePng(file, fileStream,"Peek1","PeekName1");
                    ImageBrush imageBrush = new ImageBrush();
                    imageBrush.ImageSource = new BitmapImage(new Uri("ms-appdata:///Local/PeekName1/" + file.Name + ".png"));
                    PeekImage.Source = imageBrush.ImageSource; 
                }
                else if (com.Values["moban"].ToString() == "2")
                {
                    if(com.Values["Peek2"].ToString()=="1")
                    {
                        await SavePng(file, fileStream, "Peek2", "PeekName21");
                        ImageBrush imageBrush = new ImageBrush();
                        imageBrush.ImageSource = new BitmapImage(new Uri("ms-appdata:///Local/PeekName21/" + file.Name + ".png"));
                        PeekImage21.Source = imageBrush.ImageSource; 
                    }
                    else if (com.Values["Peek2"].ToString() == "2")
                    {
                        await SavePng(file, fileStream, "Peek2", "PeekName22");
                        ImageBrush imageBrush = new ImageBrush();
                        imageBrush.ImageSource = new BitmapImage(new Uri("ms-appdata:///Local/PeekName22/" + file.Name + ".png"));
                        PeekImage22.Source = imageBrush.ImageSource;
                    }
                    else if (com.Values["Peek2"].ToString() == "3")
                    {
                        await SavePng(file, fileStream, "Peek2", "PeekName23");
                        ImageBrush imageBrush = new ImageBrush();
                        imageBrush.ImageSource = new BitmapImage(new Uri("ms-appdata:///Local/PeekName23/" + file.Name + ".png"));
                        PeekImage23.Source = imageBrush.ImageSource;
                    }
                    else if (com.Values["Peek2"].ToString() == "4")
                    {
                        await SavePng(file, fileStream, "Peek2", "PeekName24");
                        ImageBrush imageBrush = new ImageBrush();
                        imageBrush.ImageSource = new BitmapImage(new Uri("ms-appdata:///Local/PeekName24/" + file.Name + ".png"));
                        PeekImage24.Source = imageBrush.ImageSource;
                    }
                    else if (com.Values["Peek2"].ToString() == "5")
                    {
                        await SavePng(file, fileStream, "Peek2", "PeekName25");
                        ImageBrush imageBrush = new ImageBrush();
                        imageBrush.ImageSource = new BitmapImage(new Uri("ms-appdata:///Local/PeekName25/" + file.Name + ".png"));
                        PeekImage25.Source = imageBrush.ImageSource;
                    }

                }
            }
                

        }

        private static async System.Threading.Tasks.Task SavePng(StorageFile file, IRandomAccessStream fileStream,String s,String ss)
        {
            StorageFile storageFile = null; IRandomAccessStream outStream;
            if (com.Values.ContainsKey(ss))
            {
                com.Values.Remove(ss);
            }
            com.Values.Add(ss, file.Name);
            StorageFolder applicationFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync(ss, CreationCollisionOption.OpenIfExists);
            try
            {
               storageFile = await applicationFolder.CreateFileAsync(file.Name + ".png", CreationCollisionOption.OpenIfExists);

               outStream = await storageFile.OpenAsync(FileAccessMode.ReadWrite);
            }
            catch
            {
                return;

            }
            outStream.Size = 0;

            IRandomAccessStream inStream = fileStream;//供移植用

            BitmapDecoder decoder = await BitmapDecoder.CreateAsync(inStream);

            PixelDataProvider provider = await decoder.GetPixelDataAsync();

            byte[] data = provider.DetachPixelData();

            var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, outStream);

            encoder.SetPixelData(decoder.BitmapPixelFormat, decoder.BitmapAlphaMode, decoder.PixelWidth, decoder.PixelHeight, decoder.DpiX, decoder.DpiY, data);
            try
            {

                await encoder.FlushAsync();



            }

            catch (Exception err)
            {

                Debug.WriteLine(err.ToString());

            }

            finally
            {

                inStream.Dispose();

                outStream.Dispose();

            }
        }
//        public async void ReadImg()

//{

//    try
//    {

//        string fileName = @"Peek1.png";

//        StorageFolder applicationFolder = ApplicationData.Current.LocalFolder;

//        StorageFile storageFile = await applicationFolder.GetFileAsync(fileName);

//        IRandomAccessStream accessStream = await storageFile.OpenReadAsync();

//        BitmapImage bitmapImage = new BitmapImage();

//        bitmapImage.SetSource(accessStream);



//        ImageBrush back = new ImageBrush();

//        back.ImageSource = bitmapImage;

//        //normal.userback = back;

//        accessStream.Dispose();



//    }

//    catch (Exception ex)
//    {

//        string x = ex.ToString();

//    }





//}
        private void moban_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox mobans = (ComboBox)sender;
            com.Values.Remove("moban");
            if (mobans.SelectedIndex == 0)
            {
                com.Values.Add("moban", "0");
                moban0.Visibility = Visibility.Visible;
                moban1.Visibility = Visibility.Collapsed;
                moban2.Visibility = Visibility.Collapsed;
                moban3.Visibility = Visibility.Collapsed;
            }
            else if (mobans.SelectedIndex == 1)
            {
                moban0.Visibility = Visibility.Collapsed;
                moban1.Visibility = Visibility.Visible;
                moban2.Visibility = Visibility.Collapsed;
                moban3.Visibility = Visibility.Collapsed;
                com.Values.Add("moban", "1");
                if (com.Values["Peek1"].ToString() == "1" && com.Values["moban"].ToString() == "1" && com.Values.ContainsKey("PeekName1"))
                {
                    ImageBrush imageBrush = new ImageBrush();
                    imageBrush.ImageSource = new BitmapImage(new Uri("ms-appdata:///Local/PeekName1/" + com.Values["PeekName1"].ToString() + ".png"));
                    PeekImage.Source = imageBrush.ImageSource;
                }
            }
            else if (mobans.SelectedIndex == 2)
            {
                moban0.Visibility = Visibility.Collapsed;
                moban1.Visibility = Visibility.Collapsed;
                moban2.Visibility = Visibility.Visible;
                moban3.Visibility = Visibility.Collapsed;
                com.Values.Add("moban", "2");
                if (com.Values.ContainsKey("PeekName21"))
                {
                    ImageBrush imageBrush = new ImageBrush();
                    imageBrush.ImageSource = new BitmapImage(new Uri("ms-appdata:///Local/PeekName21/" + com.Values["PeekName21"].ToString() + ".png"));
                    PeekImage21.Source = imageBrush.ImageSource;
                } if (com.Values.ContainsKey("PeekName22"))
                {
                    ImageBrush imageBrush = new ImageBrush();
                    imageBrush.ImageSource = new BitmapImage(new Uri("ms-appdata:///Local/PeekName22/" + com.Values["PeekName22"].ToString() + ".png"));
                    PeekImage22.Source = imageBrush.ImageSource;
                } if (com.Values.ContainsKey("PeekName23"))
                {
                    ImageBrush imageBrush = new ImageBrush();
                    imageBrush.ImageSource = new BitmapImage(new Uri("ms-appdata:///Local/PeekName23/" + com.Values["PeekName23"].ToString() + ".png"));
                    PeekImage23.Source = imageBrush.ImageSource;
                } if (com.Values.ContainsKey("PeekName24"))
                {
                    ImageBrush imageBrush = new ImageBrush();
                    imageBrush.ImageSource = new BitmapImage(new Uri("ms-appdata:///Local/PeekName24/" + com.Values["PeekName24"].ToString() + ".png"));
                    PeekImage24.Source = imageBrush.ImageSource;
                } if (com.Values.ContainsKey("PeekName25"))
                {
                    ImageBrush imageBrush = new ImageBrush();
                    imageBrush.ImageSource = new BitmapImage(new Uri("ms-appdata:///Local/PeekName25/" + com.Values["PeekName25"].ToString() + ".png"));
                    PeekImage25.Source = imageBrush.ImageSource;
                } 
            }
            else if (mobans.SelectedIndex == 3)
            {
                moban0.Visibility = Visibility.Collapsed;
                moban1.Visibility = Visibility.Collapsed;
                moban2.Visibility = Visibility.Collapsed;
                moban3.Visibility = Visibility.Visible;
                com.Values.Add("moban", "3");
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            com.Values.Remove("Peek1");
            com.Values.Remove("PeekName1");
            com.Values.Add("Peek1", "0");
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Peek1.png"));
            PeekImage.Source = imageBrush.ImageSource;
            StorageFolder applicationFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("PeekName1", CreationCollisionOption.OpenIfExists);
            await applicationFolder.DeleteAsync(StorageDeleteOption.PermanentDelete);
        }

        private void Button_Click_mo2(object sender, RoutedEventArgs e)
        {
            com.Values.Remove("Peek2");
            if (com.Values.ContainsKey("PeekName21"))
            com.Values.Remove("PeekName21");
            if (com.Values.ContainsKey("PeekName22"))
            com.Values.Remove("PeekName22");
            if (com.Values.ContainsKey("PeekName23"))
            com.Values.Remove("PeekName23");
            if (com.Values.ContainsKey("PeekName24"))
            com.Values.Remove("PeekName24");
            if (com.Values.ContainsKey("PeekName25"))
            com.Values.Remove("PeekName25");
            com.Values.Add("Peek2", "0");
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/PeekC/1.png"));
            PeekImage21.Source = imageBrush.ImageSource;
            imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/PeekC/2.png"));
            PeekImage22.Source = imageBrush.ImageSource;
            imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/PeekC/3.png"));
            PeekImage23.Source = imageBrush.ImageSource;
            imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/PeekC/4.png"));
            PeekImage24.Source = imageBrush.ImageSource;
            imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/PeekC/5.png"));
            PeekImage25.Source = imageBrush.ImageSource;

        }


        private void Button_Click_21(object sender, RoutedEventArgs e)
        {
            openpng();
            com.Values.Remove("Peek2");
            com.Values.Add("Peek2", "1");
        }

        private void Button_Click_22(object sender, RoutedEventArgs e)
        {
            openpng();
            com.Values.Remove("Peek2");
            com.Values.Add("Peek2", "2");
        }

        private void Button_Click_23(object sender, RoutedEventArgs e)
        {
            openpng();
            com.Values.Remove("Peek2");
            com.Values.Add("Peek2", "3");
        }

        private void Button_Click_24(object sender, RoutedEventArgs e)
        {
            openpng();
            com.Values.Remove("Peek2");
            com.Values.Add("Peek2", "4");
        }

        private void Button_Click_25(object sender, RoutedEventArgs e)
        {
            openpng();
            com.Values.Remove("Peek2");
            com.Values.Add("Peek2", "5");
        }
        Brush cyanBrush = new SolidColorBrush(Colors.White);
        Brush grayBrush = new SolidColorBrush(Color.FromArgb(128,255,255,255));
        private void pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(pivot.SelectedIndex==0)
            {
                pivotxt1.Foreground = cyanBrush;
                pivotxt2.Foreground = grayBrush;
                pivotxt3.Foreground = grayBrush;
            }
            else if(pivot.SelectedIndex == 1)
            {
                pivotxt1.Foreground = grayBrush;
                pivotxt2.Foreground = cyanBrush;
                pivotxt3.Foreground = grayBrush;
            }
            else if (pivot.SelectedIndex == 2)
            {
                pivotxt1.Foreground = grayBrush;
                pivotxt2.Foreground = grayBrush;
                pivotxt3.Foreground = cyanBrush;
            }

        }
        //LiveLoginResult result;
        //private async void upOne_Click(object sender, RoutedEventArgs e)
        //{
        //    textOne.Text = "正在同步...";
        //    try
        //    {
        //        var authClient = new LiveAuthClient();//初始化，用来获取用户数据。
        //        result = await authClient.LoginAsync(new string[] { "wl.signin", "wl.skydrive", "wl.skydrive_update", "wl.offline_access" });
        //        if (result.Session != null)
        //        {
        //            var liveConnectClient = new LiveConnectClient(result.Session);
        //            //读取文件
        //            ApplicationDataContainer c = ApplicationData.Current.LocalSettings;
        //            var sd = new Dictionary<string, string>();
        //            foreach (var i in c.Values)
        //            {
        //                sd.Add(i.Key, i.Value.ToString());
        //            }
        //                StorageFolder folder = ApplicationData.Current.LocalFolder;
        //                StorageFile file = await folder.CreateFileAsync("2.txt", CreationCollisionOption.GenerateUniqueName);
        //                await FileIO.WriteTextAsync(file, sd.ToString(), Windows.Storage.Streams.UnicodeEncoding.Utf8);
        //                LiveUploadOperation uploadOperation = await liveConnectClient.CreateBackgroundUploadAsync(
        //                    "me/skydrive/", "一言", file, OverwriteOption.Rename);
        //                LiveOperationResult uploadResult = await uploadOperation.StartAsync();
        //                await file.DeleteAsync();
        //        }
        //        textOne.Text = "同步完成";
        //    }
        //    catch { textOne.Text = "同步失败"; }
        //}
        ////private async void loginOne()//登录
        ////{
        ////    try
        ////    {
        ////        var authClient = new LiveAuthClient();//初始化，用来获取用户数据。
        ////        result = await authClient.LoginAsync(new string[] { "wl.signin", "wl.skydrive", "wl.skydrive_update", "wl.offline_access" });
        ////        ////登录，里面的参数是 Scopes
        ////        //if (result.Status == LiveConnectSessionStatus.Connected)
        ////        //{
        ////        //    var connectClient = new LiveConnectClient(result.Session);
        ////        //    var meResult = await connectClient.GetAsync("me");
        ////        //}
        ////    }
        ////    catch (LiveAuthException ex) { }
        ////}
        //private async void deleteOne()//删除文件夹
        //{
        //    string id = string.Empty;
        //    LiveConnectClient liveClient = new LiveConnectClient(result.Session);
        //    LiveOperationResult operationResult = await liveClient.GetAsync("me/skydrive/search?q=Test");
        //    List<object> items = operationResult.Result["data"] as List<object>;
        //    IDictionary<string, object> file = items.First() as IDictionary<string, object>;
        //    id = file["id"].ToString();
        //    LiveOperationResult operationResult1 =
        //        await liveClient.DeleteAsync(id);
        
        //}
        //private async void oneC()//创建文件夹
        //{

        //    try
        //    {
        //        if (result.Session != null)
        //        {
        //            var folderData = new Dictionary<string, object>();
        //            folderData.Add("一言", "One");
        //            LiveConnectClient liveClient = new LiveConnectClient(result.Session);
        //            LiveOperationResult operationResult =
        //                await liveClient.PostAsync("me/skydrive", folderData);
        //            dynamic result1 = operationResult.Result;
        //        }

        //    }
        //    catch
        //    {
        //    }

        //}


    }
}
