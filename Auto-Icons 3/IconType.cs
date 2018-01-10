using System.Collections.Generic;
using System.Linq;

namespace Auto_Icons_3
{
	public enum IconType
	{
		Normal,
		Folder,
		Major
	}

	public enum IconCategory
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

	public static class IconCategoryMethods
	{
		public static IconCategory[] GetCategory(string typeLetters)
		{
			if (typeLetters == string.Empty)
				return new IconCategory[] { IconCategory.Any };

			var Out = new List<IconCategory>();

			foreach (var typeLetter in typeLetters)
			{
				switch (typeLetter)
				{
					case 'A': Out.Add(IconCategory.Application); break;
					case 'C': Out.Add(IconCategory.Category);		break;
					case 'G': Out.Add(IconCategory.Game);			break;
					case 'S': Out.Add(IconCategory.Season);		break;
					case 'T': Out.Add(IconCategory.TV);				break;
					case 'M': Out.Add(IconCategory.Movie);			break;
					case 'J': Out.Add(IconCategory.Anime);			break;
					case 'P': Out.Add(IconCategory.Photoshop);	break;
					default : Out.Add(IconCategory.Any);			break;
				}
			}

			return Out.Distinct().ToArray();
		}
	}
}
