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

namespace 本地文件
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
            ShowLocalFiles();
        }
        private async void ShowLocalFiles()
        {
            //获得文件名
            StorageFolder folder= ApplicationData.Current.LocalFolder;
            //获得所有的文件
            var files= await folder.GetFilesAsync();
            for (int i = 0; i < files.Count; i++)
            {
                StorageFile file = files[i];
                filelist.Items.Add(new FileModel()
                {
                    FileName = file.Name,
                    FileContent = await FileIO.ReadTextAsync(file)
                });
            }
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //获得用户数据，然后保存到文件中
            string fileName = txtFileName.Text.Trim();
            string fileContent = txtContent.Text.Trim();
            if(fileName.Length==0||fileContent.Length==0)
            {
                await new MessageDialog("请填写完整信息").ShowAsync();
                return;
            }
            //下面就开始保存数据
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile file = await folder.CreateFileAsync(fileName,CreationCollisionOption.GenerateUniqueName);
            await FileIO.WriteTextAsync(file, fileContent, Windows.Storage.Streams.UnicodeEncoding.Utf8);
            await new MessageDialog("完成").ShowAsync();
            filelist.Items.Clear();
            ShowLocalFiles();
            
        }

        private async void filelist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //点击文件就打印出文件的内容
            FileModel fileModel = filelist.SelectedItem as FileModel;
            if (fileModel != null)
            {
                await new MessageDialog(fileModel.FileContent, fileModel.FileName).ShowAsync();
            }
        }
    }
}
