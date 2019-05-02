using MeteoApp.Models;
using MeteoApp.Utilities;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MeteoApp
{
    public partial class App : Application
    {
        private static CityRequest cityRequest;
        private static WeatherRequest weatherRequest;
        static DatabaseHelper database;

        // singleton pattern
        public static DatabaseHelper Database
        {
            get
            {
                if (database == null) // se l'istanza è nulla, la creo
                    database = new DatabaseHelper();
                return database; // ritorno l'istanza
            }
        }

        public static CityRequest CityRequest
        {
            get
            {
                if (cityRequest == null)
                    return new CityRequest();
                return cityRequest;
            }
        }

        public static WeatherRequest WeatherRequest
        {
            get
            {
                if (weatherRequest == null)
                    return new WeatherRequest();
                return weatherRequest;
            }
        }

        public App()
        {
            InitializeComponent();

            var nav = new NavigationPage(new MeteoListPage())
            {
                BarBackgroundColor = Color.LightGreen,
                BarTextColor = Color.White
            };

            MainPage = nav;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
