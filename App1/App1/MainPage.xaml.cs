using App1.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        public void ShowTablePage(object sender,EventArgs e )
        {
            Navigation.PushModalAsync(new MainTable());
        }

    }
}
