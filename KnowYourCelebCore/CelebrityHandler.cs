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
						new Celebrity("Eminem", "eminem.jpg", true),
						new Celebrity("Carmen Electra", "carmenelectra.jpg", false),
						new Celebrity("John Cena", "johncena.jpg", true),
						new Celebrity("Kate Hudson", "katehudson.jpg", false),
						new Celebrity("Kellan Lutz", "kellanlutz.jpg", true),
						new Celebrity("Lebron James", "lebronjames.jpg", true),
						new Celebrity("Selena Gomez", "selenagomez.jpg", false),
						new Celebrity("Adrien Brody", "adrienbrody.jpg", true),
						new Celebrity("Emma Watson", "emmawatson.jpg", false),
						new Celebrity("Akon", "akon.jpg", true),
						new Celebrity("Alicia Keys", "aliciakeys.jpg", false),
						new Celebrity("Bob Marley", "bobmarley.jpg", true),
						new Celebrity("Bono", "bono.jpg", true),
						new Celebrity("Fergie", "fergie.jpg", false),
						new Celebrity("Gisele Bundchen", "giselebundchen.jpg", false),
						new Celebrity("Hilary Duff", "hilaryduff.jpg", false),
						new Celebrity("Alexis Bledel", "AlexisBledel.jpg", false),
						new Celebrity("Jessica Alba", "JessicaAlba.jpg", false),
						new Celebrity("Mila Kunis", "MilaKunis.jpg", false),
						new Celebrity("Adriana Lima", "adrianalima.jpg", false),
						new Celebrity("Aishwarya Rai", "aishwaryaRai.jpg", false),
						new Celebrity("Alyssa Milano", "alyssamilano.jpg", false),
						new Celebrity("Bill Clinton", "billclinton.jpg", true),
						new Celebrity("Brad Pitt", "bradpitt.jpg", true),
						new Celebrity("Catherine Zeta Jones", "catherinezetajones.jpg", false),
						new Celebrity("Chad Billingsley", "chadbillingsley.jpg", true),
						new Celebrity("Chad Michael Murray", "chadmichaelmurray.jpg", true),
						new Celebrity("Courteney Cox Arquette", "courteneycoxarquette.jpg", false),
						new Celebrity("Daniel Dae Kim", "danieldaekim.jpg", true),
						new Celebrity("Dan Sutton", "dansutton.jpg", true),
						new Celebrity("David Villa", "davidvilla.jpg", true),
						new Celebrity("Emily Van Camp", "emilyvancamp.jpg", false),
						new Celebrity("Halle Berry", "halleberry.jpg", false),
						new Celebrity("Heyden Penetiere", "heydenpenetiere.jpg", false),
						new Celebrity("Jessica Biel", "jessicabiel.jpg", false),
						new Celebrity("Josh Holloway", "joshholloway.jpg", true),
						new Celebrity("Justin Bieber", "justinbieber.jpg", true),
						new Celebrity("Kate Moss", "katemoss.jpg", false),
						new Celebrity("Kim Kardashian", "kimkardashian.jpg", false),
						new Celebrity("Koel Purie", "koelpurie.jpg", false),
						new Celebrity("Lauren Conrad", "laurenconrad.jpg", false),
						new Celebrity("Martin Luther King Jr", "martinlutherkingjr.jpg", true),
						new Celebrity("Miley Cyrus", "mileycyrus.jpg", false),
						new Celebrity("Olivia Wilde", "oliviawilde.jpg", false),
						new Celebrity("Phil Michelson", "philmichelson.jpg", true),
						new Celebrity("Robin Williams", "robinwilliams.jpg", true),
						new Celebrity("Sarah Palin", "sarahpalin.jpg", false),
						new Celebrity("Simon Cowell", "simoncowell.jpg", true),
						new Celebrity("Vanessa Hudgens", "vanessahudgens.jpg", false),
						new Celebrity("Will Smith", "willsmith.jpg", true),
						new Celebrity("Zac Efron", "zacefron.jpg", true),
						new Celebrity("Michelle Obama", "michelleobama.jpg", false),
						new Celebrity("Lady Gaga", "ladygaga.jpg", false)
					});
			return placelist;
		}
	}
}