using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Auto_Icons_3
{
	public class IconSynonym
	{
		public string Pattern;
		public string Value;

		public IconSynonym(string pattern, string value)
		{
			Pattern = pattern;
			Value = value;
		}

		public static IconSynonym[] Synonyms =
		{
			new IconSynonym(@"\bcollege\b", "University"),
			new IconSynonym(@"^adobe ", ""),
			new IconSynonym(@"^office ", ""),
			new IconSynonym(@"\bico\b", "Icons"),
			new IconSynonym(@"\butorrent", "µTorrent"),
			new IconSynonym(@"\bwindows\b", "Application"),
			new IconSynonym(@"^season ", "s"),
			new IconSynonym(@"^chapter ", "s"),
			new IconSynonym(@"^part ", "s"),
			new IconSynonym(@"(?<![0-9])0+", "")
		};
	}
}
