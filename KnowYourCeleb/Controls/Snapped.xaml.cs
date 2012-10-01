using System;
using System.Collections.Generic;
using System.Linq;
using KnowYourCelebCore;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace KnowYourCeleb.Controls
{
	public sealed partial class Snapped : UserControl
	{
		private List<Celebrity> _allcelebrityList;
		private List<Celebrity> _celebrityList;
		private string _currentCeleb;
		private int _difficultyLevel = 2;
		private int _highScore;
		private List<Rectangle> _pixelList;
		private int _timecounter;
		private DispatcherTimer _timer;

		public Snapped()
		{
			InitializeComponent();
			LoadHighScore();
			Setup();
			SetupGame();
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

		private void TimerTick(object sender, object e)
		{
			_timecounter -= _difficultyLevel/2;
			if (_timecounter < 0)
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
			LoadHighScore();
			_timer = new DispatcherTimer();
			_timer.Tick += TimerTick;
			TimeSpan times = TimeSpan.FromMilliseconds(10);
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
			HandleClick(Fourth.Content.ToString(), false);
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
				bool correctAnswer = answer.ToLower() == _currentCeleb.ToLower();
				int updateTime = CalculateProgress(start, correctAnswer);
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
			if (start)
				return 0;

			if (correctAnswer)
				return 70;

			return -90;
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
			RadioRookie.IsEnabled = false;
			RadioExpert.IsEnabled = false;
			HighHolder.IsEnabled = false;
		}

		private void CompletedTheGame(bool winner)
		{
			GameButtons.Visibility = Visibility.Collapsed;
			string message = winner ? "Du kan allt om kändisar." : "Du tog dig inte riktigt ända fram, testa igen!";
			int elementsInList = _celebrityList.Count;
			if (elementsInList == 0)
				elementsInList = 1;

			int winnerPoints = (_timecounter*50 + 4000*_difficultyLevel)/elementsInList;
			int looserPoints = ((4000/elementsInList)*_difficultyLevel);
			int points = winner ? winnerPoints : looserPoints;


			if (points > _highScore)
			{
				SaveHighScore(points);
			}

			var mes = new MessageDialog(message + " Din Poäng blev: " + points.ToString(), "Game Over");
			mes.ShowAsync();
			GameButtons.Visibility = Visibility.Collapsed;
			Dispose();
		}

		private void LoadHighScore()
		{
			try
			{
				ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
				var high = localSettings.Values["highscore"];
				var highScorer = localSettings.Values["highscorer"];
				HighScorer.Text = highScorer.ToString();
				HighScore.Text = high.ToString();
				_highScore = (int)high;
			}
			catch (Exception)
			{
				HighScore.Text = 0.ToString();
			}
		}


		private void SaveHighScore(int points)
		{
			ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
			//localSettings.Values["highscore"] = 0;
			
			if (localSettings.Values["highscore"] != null && (int) localSettings.Values["highscore"] < points)
			{
				var holder = "Anonym...";
				if(!string.IsNullOrEmpty(HighHolder.Text)){
					holder = HighHolder.Text;
				}
				localSettings.Values["highscorer"] = holder;
				HighScorer.Text = holder;
				localSettings.Values["highscore"] = points;
				HighScore.Text = points.ToString();
			}

			else if (localSettings.Values["highscore"] == null)
			{
				localSettings.Values["highscore"] = points;
				HighScore.Text = points.ToString();
			}
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
			_pixelList = Helper.GetPixelList();
		}

		public void Dispose()
		{
			_timer.Stop();
			_timer.Tick -= TimerTick;
			StartButton.IsEnabled = true;
			RadioRookie.IsEnabled = true;
			RadioExpert.IsEnabled = true;
			HighHolder.IsEnabled = true;
			SetupGame();
			SetImage("nopicture.jpg");
		}
	}
}