using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Layouts;

public partial class GridLayout : Window {
	public GridLayout() {
		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e) {
		myButton.Content = "Yay";
	}
}