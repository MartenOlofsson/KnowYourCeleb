using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace KnowYourCeleb.Controls
{
	public sealed partial class Snapped : UserControl
	{
		public event EventHandler Changed;

		public Snapped()
		{
			this.InitializeComponent();
		}

		private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				double height = int.Parse(TextBoxHeight.Text);
				double weight = int.Parse(TextBoxWeight.Text);

				if (height < 1 || height > 250)
				{
					ShowDialog("Höjd måste vara ett giltigt heltal inom intervallet 1-250");
					return;
				}
				else if (weight < 1 || weight > 900)
				{
					ShowDialog("Vikt måste vara ett giltigt heltal inom intervallet 1-900");
					return;
				}

				height = height / 100d;

				double bmi = weight / (height * height);

				Animate(bmi);

				if (Changed != null)
				{
					Changed(bmi, EventArgs.Empty);
				}
			}
			catch (Exception exception)
			{
				ShowDialog("Höjd och Vikt måste vara positiva giltiga heltal");
			}
		}

		private void ShowDialog(string content)
		{
			new MessageDialog(content, "Beräkningsfel").ShowAsync();
		}

		public void Animate(double bmi)
		{
			TextBlockBmi.Text = string.Format("{0:0.0}", bmi);

			double to = 0;
			double percentage = 0;

			if (bmi <= 18.5)
			{
				percentage = bmi / 18.5;
				to = 80 * percentage;
			}
			else if (bmi <= 24.9)
			{
				percentage = bmi / 24.9;
				to = 150 * percentage;
			}
			else if (bmi <= 29.9)
			{
				percentage = bmi / 29.9;
				to = 220 * percentage;
			}
			else
			{
				percentage = Math.Min(1, bmi / 30);
				to = 280 * percentage;
			}

			DoubleAnimationWidth.To = to;
			DoubleAnimationHeight.To = to;

			StoryboardAnimate.Begin();
		}


	}
}
