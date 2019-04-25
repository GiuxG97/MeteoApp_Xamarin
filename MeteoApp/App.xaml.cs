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

        public static WeatherRequest WeatherRequest
        {
            get
            {
                if (weatherRequest == null)
                    return new WeatherRequest();
                return weatherRequest;
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
