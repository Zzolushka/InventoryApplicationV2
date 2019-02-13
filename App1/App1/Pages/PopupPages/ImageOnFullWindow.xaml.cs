using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Pages.PopupPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImageOnFullWindow : PopupPage
	{
		public ImageOnFullWindow (ImageSource imageSource)
		{
			InitializeComponent ();
            img.Source = imageSource;
		}

        public void CloseThisPage(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
        }
    }
}