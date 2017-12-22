using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Icons_3
{
	public static class IconMatcher
	{
		#region First Pass
		public static IconFile Match(ItemFile file, out bool errorOccured)
		{
			try
			{
				errorOccured = false;
				var workingIcons = Data.CurrentSession.Icons
					.Where(x => x.Folder == file.Folder && x.Major == file.Major 
						&& x.Type != IconType.Photoshop && x.Type != IconType.Season);

				// Exact Match
				var iconMatch = workingIcons.Where(x => x.Name.Eq(file.Name)).FirstOrDefault();
				if (iconMatch != null)
					return iconMatch;

				// Exact Match without spaces
				iconMatch = workingIcons.Where(x => x.Formats[2].Eq(file.Formats[2])).FirstOrDefault();
				if (iconMatch != null)
					return iconMatch;

				// Spell Check (Length/5) max errors
				iconMatch = workingIcons.Where(x => SpellCheck(x.Formats[1], file.Formats[1])).FirstOrDefault();
				if (iconMatch != null)
					return iconMatch;

			}
			catch(Exception) { errorOccured = true; }
			return null;
		}

		private static bool SpellCheck(string s1, string s2)
		{
			throw new NotImplementedException();
		}
		#endregion

		#region Second Pass
		public static IconFile ReMatch(ItemFile file)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
