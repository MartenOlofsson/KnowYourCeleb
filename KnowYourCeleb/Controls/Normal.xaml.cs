﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KnowYourCelebCore;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace KnowYourCeleb.Controls
{
	public sealed partial class Normal : UserControl
	{
		public event EventHandler Changed;
		private DispatcherTimer _timer;
		private List<Celebrity> _allcelebrityList;
		private List<Celebrity> _celebrityList;
		private string _currentCeleb;
		private int _timecounter;
		private int _difficultyLevel = 2;
		private List<Rectangle> _pixelList;

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

		public Normal()
		{
			InitializeComponent();
			RadioRookie.IsChecked = true;
			Setup();
			SetupGame();
		}

		private void TimerTick(object sender, object e)
		{
			_timecounter -= _difficultyLevel/2;
			if(_timecounter < 0)
			{
				CompletedTheGame(false);
			}
			else
			{
				if (_pixelList.Count > 0)
				{
					var rand = new Random();
					int r = rand.Next(0, _pixelList.Count);
					MainCanvas.Children.Remove(_pixelList[r]);
					_pixelList.RemoveAt(r);
				}
				UpdateProgress();
			}
		}

		public void SetupGame()
		{	
			Setup();
			_timer = new DispatcherTimer();
			_timer.Tick += TimerTick;
			var times = TimeSpan.FromMilliseconds(10);
			_timer.Interval = times;
			_currentCeleb = string.Empty;
			_celebrityList = CelebrityHandler.GetAllCelebs();
			_celebrityList = Helper.Shuffle(_celebrityList);
			_allcelebrityList = CelebrityHandler.GetAllCelebs();
			
			
			
		}

		private void Setup()
		{
			_timecounter = 400;
			Rektangle.Width = 200;
			StartButton.IsEnabled = true;
			GameButtons.Visibility = Visibility.Collapsed;
			LoadPixels();
			foreach (Rectangle pixel in _pixelList)
			{
				MainCanvas.Children.Add(pixel);
			}
			SetImage("nopicture.jpg");
		}

		private void FirstButton(object sender, RoutedEventArgs e)
		{
			HandleClick(First.Content.ToString(), false);
		}

		private void SecondButton(object sender, RoutedEventArgs e)
		{
			HandleClick(Second.Content.ToString(), false);
		}

		private void ThirdButton(object sender, RoutedEventArgs e)
		{
			HandleClick(Third.Content.ToString(), false);
		}

		private void FourthButton(object sender, RoutedEventArgs e)
		{
			HandleClick(Fourth.Content.ToString(),false);
		}

		private void HandleClick(string answer, bool start)
		{	
			LoadPixels();
			if (_celebrityList.Count == 0)
			{
				CompletedTheGame(true);
			}
			else 
			{
				var correctAnswer = answer.ToLower() == _currentCeleb.ToLower();
				var updateTime = CalculateProgress(start, correctAnswer);
				_timecounter += updateTime;				
				var randomizer = new Random();
				int randomNumber = randomizer.Next(0, _celebrityList.Count);
				Celebrity celeb = _celebrityList[randomNumber];
				_currentCeleb = celeb.Name;
				_celebrityList.RemoveAt(randomNumber);
				SetButtonValues(celeb);
				
				SetImage(celeb.Image);
				
				foreach (Rectangle pixel in _pixelList)
				{
					MainCanvas.Children.Add(pixel);
				}
			}
			UpdateProgress();

		}

		private int CalculateProgress(bool start, bool correctAnswer)
		{
			if(start)
				return 0;

			if(correctAnswer)
				return 40;

			return -30;
		}

		private void SetButtonValues(Celebrity celeb)
		{
			_allcelebrityList = Helper.Shuffle(_allcelebrityList);

			List<Celebrity> celebsWithSameGender = celeb.Male
				? _allcelebrityList.Where(c => c.Male).Where(
					c => c.Name.ToLower() != celeb.Name.ToLower()).Take(3).ToList()
				: _allcelebrityList.Where(c => c.Male != true).Where(
					c => c.Name.ToLower() != celeb.Name.ToLower()).Take(3).ToList();

			celebsWithSameGender.Add(celeb);
			Helper.Shuffle(celebsWithSameGender);

			First.Content = celebsWithSameGender[0].Name;
			Second.Content = celebsWithSameGender[1].Name;
			Third.Content = celebsWithSameGender[2].Name;
			Fourth.Content = celebsWithSameGender[3].Name;
		}

		private void StartGame(object sender, RoutedEventArgs e)
		{
			HandleClick(string.Empty, true);
			GameButtons.Visibility = Visibility.Visible;
			StartButton.IsEnabled = false;
			_difficultyLevel = RadioExpert.IsChecked == true ? 4 : 2;
			_timer.Start();
		}

		private void CompletedTheGame(bool winner)
		{
			
			//DefeatedGame.IsOpen = true;
			GameButtons.Visibility = Visibility.Collapsed;
			var message = winner ? "Du kan allt om kändisar" : "Du tog dig inte riktigt ända fram, testa igen!";
			var elementsInList = _celebrityList.Count;
			if (elementsInList == 0)
				elementsInList = 1;


			var points = winner ? ((_timecounter * 50 + 4000*_difficultyLevel) / elementsInList).ToString() : (4000 / elementsInList*_difficultyLevel).ToString();
			var mes = new MessageDialog(message + " Din Poäng blev: " + points);
			
			mes.ShowAsync();
			GameButtons.Visibility = Visibility.Collapsed;
			Dispose();_timer.Stop();
			_timer.Tick -= TimerTick;
			StartButton.IsEnabled = true;
			SetupGame();
			SetImage("nopicture.jpg");

		}

		
		private void UpdateProgress()
		{
			try
			{
				Rektangle.Width = _timecounter/2;
			}
			catch (Exception)
			{
				Rektangle.Width = 0;
				CompletedTheGame(false);
			}
		}

		private void LoadPixels()
		{
			_pixelList = new List<Rectangle>();

			for (int i = 0; i < 250; i += 25)
			{
				for (int j = 0; j < 250; j += 25)
				{
					_pixelList.Add(new Rectangle
					{
						Margin = new Thickness(i, j, 0, 0),
						Width = 30,
						Height = 30,
						Fill = new SolidColorBrush(Colors.White)
					});
				}
			}
		}

		public void Dispose()
		{
			_timer.Stop();
			_timer.Tick -= TimerTick;
			StartButton.IsEnabled = true;
		}

		
	}
}
