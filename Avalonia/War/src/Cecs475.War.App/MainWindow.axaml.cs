using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Cecs475.War.App {
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}

		private void mDealButton_Click(object sender, RoutedEventArgs e) {
			// Retrieve the ViewModel from the window, then invoke the DealOneCard method.
			var model = (WarViewModel)this.FindResource("WarViewModel")!;
			model.DealOneCard();


			// NOTICE: we do not update the Images, the score labels, or any other control
			// ourself. They are all updated through data bindings to the ViewModel.
			// AMAZING.
		}
	}
}