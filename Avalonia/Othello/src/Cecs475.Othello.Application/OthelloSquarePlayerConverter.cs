using Avalonia.Controls.Shapes;
using Avalonia.Data.Converters;
using Avalonia.Media;
using Avalonia.Media.Immutable;
using System;
using System.Globalization;

namespace Cecs475.Othello.AvaloniaApp {

	/// <summary>
	/// Converts from an integer player number to an Ellipse representing that player's token.
	/// </summary>
	public class OthelloSquarePlayerConverter : IValueConverter {

		public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
			if (value is not int player) {
				throw new ArgumentException("Must bind OthelloSquarePlayerConverter to an integer property");
			}
			if (player == 0) {
				return null;
			}

			Ellipse token = new Ellipse() {
				Fill = GetFillBrush(player)
			};
			return token;
		}

		private static IImmutableSolidColorBrush GetFillBrush(int player) {
			if (player == 1)
				return Brushes.Black;
			return Brushes.White;
		}

		public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {
			throw new NotImplementedException();
		}
	}
}
