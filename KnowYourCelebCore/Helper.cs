using System;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

namespace KnowYourCelebCore
{
	public class Helper
	{
		public static BitmapImage ImageFromRelativePath(FrameworkElement parent, string path)
		{
			var uri = new Uri(parent.BaseUri, path);
			var result = new BitmapImage();
			result.UriSource = uri;
			return result;
		}

		public static List<T> Shuffle<T>(List<T> list)
		{
			Random rng = new Random();
			int n = list.Count;
			while (n > 1)
			{
				n--;
				int k = rng.Next(n + 1);
				T value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
			return list;
		}

		public static List<Rectangle> GetPixelList()
		{
			var pixelList = new List<Rectangle>();
			for (int i = 0; i < 250; i += 25)
			{
				for (int j = 0; j < 250; j += 25)
				{
					pixelList.Add(new Rectangle
					{
						Margin = new Thickness(i, j, 0, 0),
						Width = 30,
						Height = 30,
						Fill = new SolidColorBrush(Colors.White)
					});
				}
			} 
			return pixelList;
		}
}}