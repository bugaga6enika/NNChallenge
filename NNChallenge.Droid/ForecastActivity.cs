using Android.App;
using Android.OS;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using NNChallenge.Configuration.IoC;
using NNChallenge.Droid.ListAdapters;
using NNChallenge.Interfaces;
using NNChallenge.WeatherForcast;
using System.Linq;

namespace NNChallenge.Droid
{
    [Activity(Label = "ForecastActivity", Theme = "@style/AppTheme.NoActionBar")]
    public class ForecastActivity : AppCompatActivity
    {
        public const string LocationExtra = "Location";

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_forecast);
            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            // Create your application here

            string location = Intent.GetStringExtra(LocationExtra);

            var veatherForcastModel = new WeatherForcastModel(IoC.Resolve<IWeatherForcastRepository>());
            var result = await veatherForcastModel.CreateForcastForCityAsync(location);

            if (!result.HasErrors)
            {
                toolbar.Title = result.Data.City;
                var listView = FindViewById<Android.Widget.ListView>(Resource.Id.forcast_list);
                listView.Adapter = new HourForcastAdapter(this, result.Data.HourForecast.ToList());
            }
        }
    }
}
