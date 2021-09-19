using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthClub
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            SQLiteConnection conn = DependencyService.Get<SQLiteInterface>().GetConnectionForDatabase();
            MainPage = new NavigationPage(new MainPage());
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
