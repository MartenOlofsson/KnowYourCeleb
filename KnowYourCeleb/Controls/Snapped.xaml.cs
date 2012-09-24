using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace KnowYourCeleb.Controls
{
	public sealed partial class Snapped : UserControl
	{
		public Snapped()
		{
			InitializeComponent();
			SetImage("ladygaga.jpg");
		}

		public event EventHandler Changed;


		private void SetImage(string path)
		{
			var imageIcon = new Image();
			imageIcon.Width = 250;
			imageIcon.Height = 250;
			imageIcon.Source = ImageFromRelativePath(this, path);
			MainCanvas.Children.Add(imageIcon);
			Canvas.SetLeft(imageIcon, 0);
			Canvas.SetTop(imageIcon, 0);
		}

		public static BitmapImage ImageFromRelativePath(FrameworkElement parent, string path)
		{
			var uri = new Uri(parent.BaseUri, path);
			var result = new BitmapImage();
			result.UriSource = uri;
			return result;
		}

		private void FirstButton(object sender, RoutedEventArgs e)
		{

		}

		private void SecondButton(object sender, RoutedEventArgs e)
		{

		}

		private void ThirdButton(object sender, RoutedEventArgs e)
		{

		}

		private void FourthButton(object sender, RoutedEventArgs e)
		{

		}
	}
}