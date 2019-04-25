using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MeteoApp.Utilities;
using Acr.UserDialogs;

namespace MeteoApp
{
    public partial class MeteoListPage : ContentPage
    {
        MeteoListViewModel MeteoListViewModel = new MeteoListViewModel();

        public MeteoListPage()
        {
            InitializeComponent();

            BindingContext = MeteoListViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void ShowPrompt()
        {
            var pResult = await UserDialogs.Instance.PromptAsync(new PromptConfig
            {
                InputType = InputType.Name,
                OkText = "OK",
                Title = "Insert a city",
            });
            

            if (pResult.Ok && !string.IsNullOrWhiteSpace(pResult.Text))
            {
                var newCity = await App.CityRequest.DoRequestAsync(pResult.Text);

                //TODO: non va questa funzione e non si sa il perchè, da eccezione perchè esce ignorando il parsing (provare a debuggare per capire)
                var weather = await App.WeatherRequest.DoRequestAsync(new Entry
                {
                    Name = "como",
                    Lat = 45.81,
                    Lon = 9.09
                });

                MeteoListViewModel.Entries.Add(newCity);
            }
        }

        void OnItemAdded(object sender, EventArgs e)
        {
            //DisplayAlert("Messaggio", "Testo", "OK");
            ShowPrompt();
          //MeteoListViewModel.Entries.Add(...)
        }

        void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                //TODO: mettere qui il risultato della richiesta del weather e passarlo nel costruttore sotto (non va e non so il perchè)
                Navigation.PushAsync(new MeteoItemPage()
                {
                    BindingContext = new MeteoItemViewModel(e.SelectedItem as Entry)
                });
            }
        }
    }
}
