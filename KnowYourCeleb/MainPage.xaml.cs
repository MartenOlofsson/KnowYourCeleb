using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace KnowYourCeleb
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
		public MainPage()
		{
			this.InitializeComponent();
			Window.Current.SizeChanged += CurrentOnSizeChanged;
		}

		private void CurrentOnSizeChanged(object sender, WindowSizeChangedEventArgs e)
		{
			var viewState = ApplicationView.Value;
			

			if (viewState == ApplicationViewState.Snapped)
			{
				NormalView.Visibility = Visibility.Collapsed;
				SnappedView.Visibility = Visibility.Visible;
				NormalView.Dispose();
				NormalView.SetupGame();

			}
			else
			{
				NormalView.Visibility = Visibility.Visible;
				SnappedView.Visibility = Visibility.Collapsed;
				SnappedView.Dispose();
				SnappedView.SetupGame();
				
			}
		}

		/// <summary>
		/// Invoked when this page is about to be displayed in a Frame.
		/// </summary>
		/// <param name="e">Event data that describes how this page was reached.  The Parameter
		/// property is typically used to configure the page.</param>
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
		}

		private void NormalView_Changed(object sender, EventArgs e)
		{
			
		}

		private void SnappedView_Changed(object sender, EventArgs e)
		{
			

		}

		private void NormalView_Loaded(object sender, RoutedEventArgs e)
		{

		}

    }
}
