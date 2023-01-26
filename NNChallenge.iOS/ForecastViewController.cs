using System;
using System.Linq;
using System.Reflection.Emit;
using NNChallenge.Configuration.IoC;
using NNChallenge.Interfaces;
using NNChallenge.WeatherForcast;
using UIKit;

namespace NNChallenge.iOS
{
    public partial class ForecastViewController : UIViewController
    {
        private readonly string _location;

        public ForecastViewController(string location) : base("ForecastViewController", null)
        {
            if (string.IsNullOrEmpty(location))
            {
                throw new ArgumentNullException(location);
            }

            _location = location;
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            var veatherForcastModel = new WeatherForcastModel(IoC.Resolve<IWeatherForcastRepository>());
            var result = await veatherForcastModel.CreateForcastForCityAsync(_location);

            if (!result.HasErrors)
            {
                Title = result.Data.City;
                var table = new UITableView(View.Bounds);
                table.RowHeight = 60f;
                table.Source = new WeatherForcastTableViewSource(result.Data.HourForecast);

                Add(table);
            }

            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

