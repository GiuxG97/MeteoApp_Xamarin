﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MeteoApp
{
    public partial class MeteoItemPage : ContentPage
    {
        public MeteoItemPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            System.Diagnostics.Debug.WriteLine("LOC " + nameLocation.Text);
            await populateAsync(((MeteoItemViewModel)BindingContext).Entry);
        }

        /*protected override void OnAppearing()
        {
            base.OnAppearing();
            System.Diagnostics.Debug.WriteLine("LOC " + nameLocation.Text);
            populateAsync(nameLocation.Text);
        }*/

        private async System.Threading.Tasks.Task populateAsync(Entry entryBC)
        {
            Entry e=await App.WeatherRequest.DoRequestAsync(entryBC);
            System.Diagnostics.Debug.WriteLine(e.Condition);
            BindingContext = new MeteoItemViewModel(e as Entry);
        }
    }
}
