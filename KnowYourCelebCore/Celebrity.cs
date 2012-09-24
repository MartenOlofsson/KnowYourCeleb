using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowYourCelebCore
{
	public class Celebrity
	{
		public string Image { get; set; }
		public string Name { get; set; }
		public bool Male { get; set; }

		public Celebrity(string name, string image, bool male)
		{
			this.Name = name;
			this.Image = image;
			this.Male = male;
		}
	}
}
