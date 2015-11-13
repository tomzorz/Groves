using System.Collections.Generic;
using Windows.ApplicationModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Resources;
using Groves.FakeMarkupExtensions;
using Groves.FakeMarkupExtensions.BuiltIn;

namespace GrovesDemos.Demos.FakeMarkupExtensions
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class FakeMarkupExtensionsDemo : Page
	{
		public FakeMarkupExtensionsDemo()
		{
			this.InitializeComponent();
			Loaded += FakeMarkupExtensionsDemo_Loaded;
		}

		private void FakeMarkupExtensionsDemo_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
		{
			var list = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h" };
			AlternatorDemoItemsControl.ItemsSource = list;
		}
	}
}
