using baiTap.Emnity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace baiTap
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private member currentmember;
        public MainPage()
            
        {
            this.currentmember = new member();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            this.InitializeComponent();
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            this.currentmember.userName = this.UserName.Text;
            this.currentmember.email = this.Email.Text;
            this.currentmember.phone = this.UserName.Text;
            string jsonMember = JsonConvert.SerializeObject(this.currentmember);

            string userName = UserName. Text;
            string email = Email.Text;
            FileSavePicker savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
            savePicker.SuggestedFileName = "New Document";
            StorageFile File = await savePicker.PickSaveFileAsync();

            await FileIO.WriteTextAsync(File, jsonMember);

        }

        private async void Load_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".txt");
            StorageFile file = await openPicker.PickSingleFileAsync();

            string content = await Windows.Storage.FileIO.ReadTextAsync(file);
            currentmember = JsonConvert.DeserializeObject<member>(content);
            UserName.Text = currentmember.userName;
            Email.Text = currentmember.email;
            Phone.Text = currentmember.phone;

        }
    }
}
