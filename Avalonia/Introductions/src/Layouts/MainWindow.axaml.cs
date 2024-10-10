using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Layouts {
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}

		private void mWrapBtn_Click(object sender, RoutedEventArgs e) {
			var panel = new WrapLayout();
			panel.Show();
		}

		private void mDockBtn_Click(object sender, RoutedEventArgs e) {
			var panel = new DockLayout();
			panel.Show();
		}

		private void mStackBtn_Click(object sender, RoutedEventArgs e) {
			var panel = new StackLayout();
			panel.Show();
		}

		private void mGridBtn_Click(object sender, RoutedEventArgs e) {
			var panel = new GridLayout();
			panel.Show();
		}
	}
}