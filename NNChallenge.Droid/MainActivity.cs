using System;
using Android.App;
using Android.OS;
using AndroidX.AppCompat.App;
using Android.Widget;
using Android.Content;
using System.Collections.Generic;
using NNChallenge.Constants;
using NNChallenge.Configuration.IoC;
using NNChallenge.Interfaces;

namespace NNChallenge.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private string _selectedLocation;
        private Spinner _spinnerLocations;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_location);

            Button buttonForecst = FindViewById<Button>(Resource.Id.button_forecast);
            buttonForecst.Click += OnForecastClick;

            _spinnerLocations = FindViewById<Spinner>(Resource.Id.spinner_location);
            _spinnerLocations.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(Spinner_ItemSelected);

            ArrayAdapter<String> adapter = new ArrayAdapter<String>(
                this,
                Android.Resource.Layout.SimpleSpinnerDropDownItem,
                LocationConstants.LOCATIONS
            );

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            _spinnerLocations.Adapter = adapter;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _spinnerLocations.ItemSelected -= new EventHandler<AdapterView.ItemSelectedEventArgs>(Spinner_ItemSelected);
        }

        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            _selectedLocation = spinner.GetItemAtPosition(e.Position).ToString();
        }

        private void OnForecastClick(object sender, EventArgs e)
        {
            var weatherForcastIntent = new Intent(this, typeof(ForecastActivity));
            weatherForcastIntent.PutExtra(ForecastActivity.LocationExtra, _selectedLocation);

            this.StartActivity(weatherForcastIntent);
        }
    }
}
