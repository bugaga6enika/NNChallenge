using System;
using Foundation;
using NNChallenge.Interfaces;
using UIKit;

namespace NNChallenge.iOS
{
    public class WeatherForcastTableViewSource : UITableViewSource
    {
        private readonly IHourWeatherForecastVO[] _items;
        private readonly NSString CellIdentifier = new NSString("WeatherForcastTableCell");

        public WeatherForcastTableViewSource(IHourWeatherForecastVO[] items)
        {
            _items = items;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var item = _items[indexPath.Row];

            var cell = tableView.DequeueReusableCell(CellIdentifier) as WeatherForcastTableViewCell;
            if (cell == null)
            {
                cell = new WeatherForcastTableViewCell(CellIdentifier);
            }

            cell.UpdateCell(item);

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _items.Length;
        }
    }
}

