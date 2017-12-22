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
      public string   FilePath { get; private set; }
      public string   Name     { get; private set; }
      public string[] Formats	 { get; private set; }
      public bool     Folder   { get; private set; }
      public bool     Major    { get; private set; }
      public DateTime Time     { get; private set; }
      public IconType Type     { get; private set; }

		public IconFile(string path)
		{
			FilePath = path;
			Formats = BackEndWorker.GetFormats(path);
			Name = Formats[1];
			Type = IconTypeMethods.GetType(Regex.Match(Formats[0], "(?:Folder (\\w) )").Groups[1].Value);
			Folder = Regex.IsMatch(Formats[0], "^Folder ");
			Major = Regex.IsMatch(Formats[0], "^Major ");
			Time = File.GetLastWriteTime(path);
		}

		public override bool Equals(object obj) => obj is IconFile && ((IconFile)obj).Formats[0] == Formats[0];

		public override string ToString() => Formats[0];

		public override int GetHashCode()
		{
			var hashCode = -488051371;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FilePath);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
			hashCode = hashCode * -1521134295 + EqualityComparer<string[]>.Default.GetHashCode(Formats);
			hashCode = hashCode * -1521134295 + Folder.GetHashCode();
			hashCode = hashCode * -1521134295 + Major.GetHashCode();
			hashCode = hashCode * -1521134295 + Time.GetHashCode();
			hashCode = hashCode * -1521134295 + Type.GetHashCode();
			return hashCode;
		}
	}
}
