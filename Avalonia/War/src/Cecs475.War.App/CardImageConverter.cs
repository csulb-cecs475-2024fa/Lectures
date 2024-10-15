using Avalonia.Controls.Shapes;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Cecs475.War.Model;
using System;
using System.Globalization;

namespace Cecs475.War.App {
	public class CardImageConverter : IValueConverter {
		public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
			try {
				if (value is Card c) {
					string src = c.ToString().ToLower().Replace(' ', '_');
					return new Bitmap(AssetLoader.Open(new Uri($"avares://Cecs475.War.App/Resources/{src}.png")));
				}
				else {
					return new Bitmap(AssetLoader.Open(new Uri("avares://Cecs475.War.App/Resources/back.png")));
				}
			}
			catch (Exception) {
				return null;
			}
		}

		public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {
			throw new NotImplementedException();
		}
	}
}
