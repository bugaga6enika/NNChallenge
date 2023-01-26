using System;
using CoreGraphics;
using FFImageLoading;
using Foundation;
using NNChallenge.Interfaces;
using UIKit;

namespace NNChallenge.iOS
{
    public class WeatherForcastTableViewCell : UITableViewCell
    {
        private readonly UILabel _temperatures;
        private readonly UILabel _date;
        private readonly UIImageView _imageView;

        public WeatherForcastTableViewCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId)
        {
            SelectionStyle = UITableViewCellSelectionStyle.Gray;
            _imageView = new UIImageView();

            _temperatures = new UILabel()
            {
                Font = UIFont.SystemFontOfSize(14),
                TextColor = UIColor.FromRGB(45, 45, 45),
                BackgroundColor = UIColor.Clear
            };

            _date = new UILabel()
            {
                Font = UIFont.SystemFontOfSize(14),
                TextColor = UIColor.FromRGB(45, 45, 45),
                BackgroundColor = UIColor.Clear
            };

            ContentView.AddSubviews(new UIView[] { _imageView, _temperatures, _date });
        }

        public void UpdateCell(IHourWeatherForecastVO hourWeatherForecast)
        {
            _imageView.Image = new UIImage();
            ImageService.Instance.LoadUrl(hourWeatherForecast.ForecastPitureURL).Into(_imageView);
            _temperatures.Text = $"{hourWeatherForecast.TeperatureCelcius}C / {hourWeatherForecast.TeperatureFahrenheit}F"; ;
            _date.Text = $"{hourWeatherForecast.Date.ToString("MMMM dd")}, {hourWeatherForecast.Date.ToString("yyyy")}  {hourWeatherForecast.Date.ToString("HH:mm")}";
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            _imageView.Frame = new CGRect(14, (ContentView.Bounds.Height / 2) - 18, 36, 36);
            _temperatures.Frame = new CGRect(70, 10, ContentView.Bounds.Width - 45, 26);
            _date.Frame = new CGRect(70, 28, ContentView.Bounds.Width - 45, 26);
        }
    }
}

