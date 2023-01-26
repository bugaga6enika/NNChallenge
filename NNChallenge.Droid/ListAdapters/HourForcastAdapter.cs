using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using Google.Android.Material.Tabs;
using NNChallenge.Interfaces;
using Square.Picasso;

namespace NNChallenge.Droid.ListAdapters
{
    public class HourForcastAdapter : BaseAdapter<IHourWeatherForecastVO>
    {
        private readonly Activity _context;
        private readonly List<IHourWeatherForecastVO> _items;

        public HourForcastAdapter(Activity context, List<IHourWeatherForecastVO> items) : base()
        {
            _context = context;
            _items = items;
        }

        public override IHourWeatherForecastVO this[int position] => _items[position];

        public override int Count => _items.Count;

        public override long GetItemId(int position) => position;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _items[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = _context.LayoutInflater.Inflate(Resource.Layout.hour_forecast, null);

            view.FindViewById<TextView>(Resource.Id.temperatures).Text = $"{item.TeperatureCelcius}C / {item.TeperatureFahrenheit}F";
            view.FindViewById<TextView>(Resource.Id.hour).Text = $"{item.Date.ToString("MMMM dd")}, {item.Date.ToString("yyyy")}  {item.Date.ToString("HH:mm")}";
            var imageView = view.FindViewById<ImageView>(Resource.Id.condition);
            Picasso.Get()
                .Load(item.ForecastPitureURL)
                .Into(imageView);

            return view;
        }
    }
}

