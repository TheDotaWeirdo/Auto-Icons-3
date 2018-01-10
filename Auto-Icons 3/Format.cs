using System.IO;
using Extensions;

namespace Auto_Icons_3
{
	public enum FormatComparer
	{
		Base,
		Name,
		NoSpace,
		LowerCase,
		LowerCaseWords,
		LowerCaseNoSpace,
		Abbreviation
	};

	public class Format
	{
		public string Base;
		public string Name;
		public string NoSpace;
		public string LowerCase;
		public string LowerCaseWords;
		public string LowerCaseNoSpace;
		public string Abbreviation;

		public Format() { }

		public Format(string path)
		{
			Base = Path.GetFileName(path).RegexRemove(@"\.\w{2,5}$");
			Name = Base.RegexRemove("(?:Folder|Major)(?: [A-z]+)? ");
			NoSpace = Name.RegexRemove(" ");
			LowerCase = Name.ToLower();
			LowerCaseWords = LowerCase.RegexRemove(@"\b(?=[0-9])(\w+)(?:'\w+)?\b");
			LowerCaseNoSpace = NoSpace.ToLower();
			Abbreviation = LowerCase.GetWords().Convert(x => x.Substring(0, 1)).ListStrings();
		}

		public string PropertyFromComparer(FormatComparer comparer)
		{
			switch (comparer)
			{
				case FormatComparer.Base:
					return Base;
				case FormatComparer.Name:
					return Name;
				case FormatComparer.NoSpace:
					return NoSpace;
				case FormatComparer.LowerCase:
					return LowerCase;
				case FormatComparer.LowerCaseWords:
					return LowerCaseWords;
				case FormatComparer.LowerCaseNoSpace:
					return LowerCaseNoSpace;
				case FormatComparer.Abbreviation:
					return Abbreviation;
				default:
					return string.Empty;
			}
		}

		public static Format FromBase(string Base)
		{
			var f = new Format { Base = Base };

			f.Name = f.Base.RegexRemove("(?:Folder|Major)(?: [A-z]+)? ");
			f.NoSpace = f.Name.RegexRemove(" ");
			f.LowerCase = f.Name.ToLower();
			f.LowerCaseWords = f.LowerCase.RegexRemove(@"\b(?=[0-9])(\w+)(?:'\w+)?\b");
			f.LowerCaseNoSpace = f.NoSpace.ToLower();
			f.Abbreviation = f.LowerCase.GetWords().Convert(x => x.Substring(0, 1)).ListStrings();

			return f;
		}

		public override string ToString() => Base;
	}
}
