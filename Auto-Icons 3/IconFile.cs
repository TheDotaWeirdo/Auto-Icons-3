using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Extensions;

namespace Auto_Icons_3
{
	public class IconFile
	{
      public string			 FilePath	{ get; private set; }
      public List<Format>	 Formats		{ get; private set; }
      public DateTime		 Time			{ get; private set; }
		public IconType		 Type			{ get; private set; }
		public IconCategory[] Categories	{ get; private set; }

		public string Name => Formats[0].Name;

		public IconFile(string path)
		{
			FilePath = path;
			Formats = new List<Format>() { new Format(path) };
			Categories = IconCategoryMethods.GetCategory(Regex.Match(Formats[0].Base, "(?:Folder ([A-z]+) )").Groups[1].Value);
			Type = Regex.IsMatch(Formats[0].Base, "^Folder ") ? IconType.Folder :
				Regex.IsMatch(Formats[0].Base, "^Major ") ? IconType.Major : IconType.Normal;
			Time = File.GetLastWriteTime(path);

			foreach (var synonym in IconSynonym.Synonyms)
			{
				if (Regex.IsMatch(Formats[0].LowerCase, synonym.Pattern))
					Formats.Add(Format.FromBase(Formats[0].LowerCase.RegexReplace(synonym.Pattern, synonym.Value)));
			}
		}

		public IconFile Folder
			=> Type != IconType.Major ? this :
			Data.Session.Icons.FirstThat(x => x.Type == IconType.Folder
				&& x.Formats[0].LowerCase == Formats[0].LowerCase);

		public override bool Equals(object obj) => obj is IconFile && ((IconFile)obj).Formats[0].Base == Formats[0].Base;

		public override string ToString() => $"({Type.ToString()}) {Formats[0].Name} [{Categories.ListStrings(x => x.ToString() + ", ").TrimEnd(2)}]";

		public override int GetHashCode()
		{
			var hashCode = 524848079;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FilePath);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
			hashCode = hashCode * -1521134295 + Formats.GetHashCode();
			hashCode = hashCode * -1521134295 + Time.GetHashCode();
			hashCode = hashCode * -1521134295 + Type.GetHashCode();
			hashCode = hashCode * -1521134295 + Categories.GetHashCode();
			return hashCode;
		}
	}
}
