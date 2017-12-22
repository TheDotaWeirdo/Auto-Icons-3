using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensions;

namespace Auto_Icons_3
{
	public static class BackEndWorker
	{
		public static string[] GetFormats(string path)
		{
			var Out = new string[3];

			Out[0] = Path.GetFileNameWithoutExtension(path);
			Out[1] = Out[0].RegexRemove("(?:Folder|Major)(?: \\w)? ");
			Out[2] = Out[1].RegexRemove(" ");

			return Out;
		}

		public static IconType GetType(string path)
		{
			return IconType.Any;
		}

		public static bool IsFolder(string path)
		{
			if (path.EndsWith(".lnk"))
				path = path.GetShortcutPath();
			return (Directory.Exists(path)) && File.GetAttributes(path).HasFlag(FileAttributes.Directory);
		}

		public static bool IsMajor(string path)
		{
			return Directory.GetParent(path).Parent == null || Directory.GetParent(path).Name.ToLower() == "desktop";
		}

		public static bool Eq(this string s, string st) => s.ToLower() == st.ToLower();
	}
}
