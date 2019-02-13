using App1.Pages.PopupPages;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FirstPage : ContentPage
	{
		public FirstPage ()
		{
			InitializeComponent ();
            ImgFrame.IsVisible = false;

            AddItemsToPicker(FirstPicker);
            AddItemsToPicker(SecondPicker);
            AddItemsToPicker(LastPicker);
        }

        public void OnImageTapped(object sender,EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new ImageOnFullWindow(img.Source));
        }

        private async void OpenCamera(object sender, EventArgs e)
        {
            if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
            {
                MediaFile file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                    Directory = "Receipts",
                    Name = $"{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.jpg",
                   
                });

                if (file == null)
                    return;

                img.Source = ImageSource.FromFile(file.Path);

                ImgFrame.IsVisible = true;
                ButtonFrame.IsVisible = false;

            }
        }

        private void AddItemsToPicker(Picker picker)
        {
            picker.Items.Add("First item");
            picker.Items.Add("Second item");
            picker.Items.Add("Last item");
        }
    }
}