using System.Collections.Generic;

namespace KnowYourCelebCore
{
	public class CelebrityHandler
	{
		public static List<Celebrity> GetAllCelebs()
		{
			var placelist = new List<Celebrity>(new[]
					{
						new Celebrity("Angela Stanford", "angelastanford.jpg", false),
						new Celebrity("eminem", "eminem.jpg", true),
						new Celebrity("carmen electra", "carmenelectra.jpg", false),
						new Celebrity("john cena", "johncena.jpg", true),
						new Celebrity("katehudson", "katehudson.jpg", false),
						new Celebrity("kellan lutz", "kellanlutz.jpg", true),
						new Celebrity("lebron james", "lebronjames.jpg", true),
						new Celebrity("selena gomez", "selenagomez.jpg", false),
						new Celebrity("adrien brody", "adrienbrody.jpg", true),
						new Celebrity("emma watson", "emmawatson.jpg", false),

						new Celebrity("Akon", "akon.jpg", true),
						new Celebrity("Alicia Keys", "aliciakeys.jpg", false),
						new Celebrity("Bob Marley", "bobmarley.jpg", true),
						new Celebrity("Bono", "bono.jpg", true),
						new Celebrity("Fergie", "fergie.jpg", false),
						new Celebrity("Gisele Bundchen", "giselebundchen.jpg", false),
						new Celebrity("Hilary Duff", "hilaryduff.jpg", false),
						new Celebrity("Lady Gaga", "ladygaga.jpg", false)
					});
			return placelist;
		}
	}
}