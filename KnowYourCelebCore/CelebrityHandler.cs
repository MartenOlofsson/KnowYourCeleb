using System.Collections.Generic;

namespace KnowYourCelebCore
{
	public class CelebrityHandler
	{
		public static List<Celebrity> GetAllCelebs()
		{
			var placelist = new List<Celebrity>(new[]
					{
						new Celebrity("Angela Stanford", "Assets/angelastanford.jpg", false),
						new Celebrity("eminem", "Assets/eminem.jpg", true),
						new Celebrity("carmen electra", "Assets/carmenelectra.jpg", false),
						new Celebrity("john cena", "Assets/johncena.jpg", true),
						new Celebrity("katehudson", "Assets/katehudson.jpg", false),
						new Celebrity("kellan lutz", "Assets/kellanlutz.jpg", true),
						new Celebrity("lebron james", "Assets/lebronjames.jpg", true),
						new Celebrity("selena gomez", "Assets/selenagomez.jpg", false),
						new Celebrity("adrien brody", "Assets/adrienbrody.jpg", true),
						new Celebrity("emma watson", "Assets/emmawatson.jpg", false),

						new Celebrity("Akon", "Assets/akon.jpg", true),
						new Celebrity("Alicia Keys", "Assets/aliciakeys.jpg", false),
						new Celebrity("Bob Marley", "Assets/bobmarley.jpg", true),
						new Celebrity("Bono", "Assets/bono.jpg", true),
						new Celebrity("Fergie", "Assets/fergie.jpg", false),
						new Celebrity("Gisele Bundchen", "Assets/giselebundchen.jpg", false),
						new Celebrity("Hilary Duff", "Assets/hilaryduff.jpg", false),
						new Celebrity("Lady Gaga", "Assets/ladygaga.jpg", false)
					});
			return placelist;
		}
	}
}