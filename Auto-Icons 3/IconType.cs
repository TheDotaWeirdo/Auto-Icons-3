using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Auto_Icons_3
{
	public enum IconType
	{
		Any,
		Application,
		Category,
		Game,
		Season,
		TV,
		Movie,
		Photoshop,
		Anime
	};

	public static class IconTypeMethods
	{
		public static IconType GetType(string typeLetter)
		{
			switch (typeLetter)
			{
				case "A": return IconType.Application;
				case "C": return IconType.Category;
				case "G": return IconType.Game;
				case "S": return IconType.Season;
				case "T": return IconType.TV;
				case "M": return IconType.Movie;
				case "P": return IconType.Photoshop;
				default:
					return IconType.Any;
			}
		}
	}
}
