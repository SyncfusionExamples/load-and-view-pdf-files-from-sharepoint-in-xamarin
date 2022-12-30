using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SharePoint
{
    public partial class App : Application
    {
        public static object ParentWindow { get; set; }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new DocumentsPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
