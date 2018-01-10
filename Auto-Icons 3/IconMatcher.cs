using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Extensions;

namespace Auto_Icons_3
{
	public static class IconMatcher
	{
		private const int SPELLCHECK_MAX_ERRORS	= 1;
		private const int SPELLCHECK_MAX_SCORE		= 10;
		private const int GENERAL_MIN_CHAR_LENGTH = 3;

		#region First Pass
		public static Exception Match(ItemFile file)
		{
			try
			{
				var workingIcons = Data.Session.Icons
					.Where(x => x.Type == file.Type && (file.Categories.Any(x.Categories)
					|| (file.Categories.IsOnly(IconCategory.Any) && !x.Categories.IsOnly(IconCategory.Photoshop)
						&& !x.Categories.Contains(IconCategory.Season)))).OrderByDescending(x => x.Categories.Length).ToArray();

				// Exact Match
				file.Match = workingIcons.FirstThat(x => file.Formats.Compare(x.Formats, FormatComparer.LowerCase, FormatComparer.LowerCase));
				if (file.Match != null)
					goto End;

				// Exact Match without spaces
				file.Match = workingIcons.FirstThat(x => file.Formats.Compare(x.Formats, FormatComparer.LowerCaseNoSpace, FormatComparer.LowerCaseNoSpace));
				if (file.Match != null)
					goto End;

				// Spell Check
				file.Match = workingIcons.Convert(x => 
					new Tuple<IconFile, int>(x, SpellCheck(x.Formats, file.Formats)))
					.Where(x => x.Item2 > 0).OrderByDescending(x => x.Item2).FirstOrDefault()?.Item1;
				if (file.Match != null)
					goto End;

				// Icon Contains File Check
				file.Match = workingIcons.FirstThat(x => FileContainCheck(file, x));
				if (file.Match != null)
					goto End;

				// File Contains Icon Check
				file.Match = workingIcons.FirstThat(x => IconContainCheck(x, file));
				if (file.Match != null)
					goto End;

				// Similar Words
				file.Match = workingIcons.Convert(x =>
					new Tuple<IconFile, int>(x, WordCheck(x.Formats[0].LowerCase, file.Formats[0].LowerCase)))
					.Where(x => x.Item2 > GENERAL_MIN_CHAR_LENGTH).OrderByDescending(x => x.Item2).FirstOrDefault()?.Item1;
				if (file.Match != null)
					goto End;

				// Abbreviation Check
				file.Match = workingIcons
				.FirstThat(x => x.Formats.Any(f1 => f1.Abbreviation.Length >= GENERAL_MIN_CHAR_LENGTH)
					&& x.Formats.Compare(file.Formats, FormatComparer.Abbreviation, FormatComparer.LowerCaseWords)
				|| (file.Formats.Any(f2 => f2.Abbreviation.Length >= GENERAL_MIN_CHAR_LENGTH)
					&& file.Formats.Compare(x.Formats, FormatComparer.Abbreviation, FormatComparer.LowerCaseWords)));
				if (file.Match != null)
					goto End;

				// Similar Starting
				file.Match = workingIcons.Convert(x =>
					new Tuple<IconFile, int>(x, SimilarCheck(file, x)))
					.Where(x => x.Item2 > 1).OrderByDescending(x => x.Item2).FirstOrDefault()?.Item1;
				if (file.Match != null)
					goto End;
			}
			catch(Exception ex) { return ex; }

			End: return null;
		}

		private static int SimilarCheck(ItemFile file, IconFile test)
		{
			var s1 = file.Formats[0].LowerCase;
			var s2 = test.Formats[0].LowerCase;

			if (s1.Length > s2.Length)
				s1.Substring(0, s2.Length);
			else
				s2.Substring(0, s1.Length);

			if (s1.Length <= GENERAL_MIN_CHAR_LENGTH)
				return 0;

			return SPELLCHECK_MAX_ERRORS - SpellCheck(s1, s2);
		}

		private static int SpellCheck(List<Format> f1, List<Format> f2)
		{
			var bestScore = 0;
			foreach (var format1 in f1)
			{
				var w1 = format1.LowerCase;

				if (w1.Length == 0)
					continue;

				foreach (var format2 in f2)
				{
					var w2 = format2.LowerCase;

					if (w2.Length == 0)
						continue;

					if (Math.Abs(w1.Length - w2.Length) > SPELLCHECK_MAX_ERRORS || w1[0] != w2[0])
						continue;

					if (w1.Length <= GENERAL_MIN_CHAR_LENGTH || w2.Length <= GENERAL_MIN_CHAR_LENGTH)
						continue;

					var totErrors = SpellCheck(w1, w2);

					if (totErrors > SPELLCHECK_MAX_ERRORS)
						continue;

					bestScore = bestScore > SPELLCHECK_MAX_SCORE - totErrors ? bestScore : SPELLCHECK_MAX_SCORE - totErrors;
				}
			}

			return bestScore;
		}

		public static int SpellCheck(string s1, string s2)
		{
			// Levenshtein Algorithm
			var n = s1.Length;
			var m = s2.Length;
			var d = new int[n + 1, m + 1];

			if (n == 0)
				return m;

			if (m == 0)
				return n;

			for (int i = 0; i <= n; d[i, 0] = i++) { }

			for (int j = 0; j <= m; d[0, j] = j++) { }

			for (int i = 1; i <= n; i++)
			{
				for (int j = 1; j <= m; j++)
				{
					int cost = (s2[j - 1] == s1[i - 1]) ? 0 : 1;

					d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
						 d[i - 1, j - 1] + cost);
				}
			}
			return d[n, m];
		}

		private static bool IconContainCheck(IconFile icon, ItemFile file)
		{
			foreach (var format in file.Formats)
			{
				if (format.LowerCase.Length > GENERAL_MIN_CHAR_LENGTH && Regex.IsMatch(format.LowerCase, "[a-z]")
					&& icon.Formats.Any(x => x.LowerCase.GetWords().Length <= GENERAL_MIN_CHAR_LENGTH
						&& x.LowerCase.ContainsWord(format.LowerCase)))
					return true;
			}
			return false;
		}

		private static bool FileContainCheck(ItemFile file, IconFile icon)
		{
			foreach (var format in icon.Formats)
			{
				if (format.LowerCase.Length >= GENERAL_MIN_CHAR_LENGTH && Regex.IsMatch(format.LowerCase, "[a-z]")
					&& file.Formats.Any(x => x.LowerCase.GetWords().Length <= GENERAL_MIN_CHAR_LENGTH
						&& x.LowerCase.ContainsWord(format.LowerCase)))
					return true;
			}
			return false;
		}

		private static int WordCheck(string s1, string s2)
		{
			var w1 = s1.GetWords();
			var w2 = s2.GetWords();
			var count = 0;

			foreach (var word in w1)
				if (w2.Contains(word))
					count++;

			return count;
		}
		#endregion

		#region Second Pass
		public static Exception ReMatch(ItemFile file)
		{
			try
			{
				file.Match = GetIconBasedOnContent(file);
				if (file.Match != null)
					return null;

				var parents = file.Parents.Trim(0, 3);
				foreach (var parent in parents)
				{
					file.Match = Data.Session.Folders.FirstThat(x => x.Match != null && parent == Path.GetFullPath(x.FilePath))?.Match.Folder;
					if (file.Match != null)
						return null;

					file.Match = GetFolderIcon(parent)?.Folder;
					if (file.Match != null)
						return null;
				}
			}
			catch (Exception ex) { return ex; }

			return null;
		}

		private static IconFile GetIconBasedOnContent(ItemFile folder, int? limit = null)
		{
			var Files = Directory.GetFiles(folder.FilePath.EndsWith(".lnk") ? folder.FilePath.GetShortcutPath() : folder.FilePath, "*.*", SearchOption.TopDirectoryOnly);
			var Limit = (int)(limit != null ? Math.Max((int)limit, Files.Count() * 85 / 100) : Math.Max(3, Files.Count() * .35));
			var CatCount = new Dictionary<FileTypeCategory, int>();

			foreach (var cat in FileTypeCategory.Categories)
			{ CatCount.Add(cat, 0); }

			foreach (var file in Files)
			{
				var ext = Path.GetExtension(file).ToLower();
				if (ext == ".lnk" && !file.IsFolder())
					ext = Path.GetExtension(file.GetShortcutPath()).ToLower();

				foreach (var cat in FileTypeCategory.Categories)
				{
					if (cat.Extensions.Any(x => x == ext))
					{
						CatCount[cat]++;
						break;
					}
				}
			}

			var max = CatCount.FirstThat(y => y.Value == CatCount.Max(x => x.Value));

			if (max.Value >= Limit)
				return Data.Session.Icons.FirstThat(x => x.Categories.Contains(IconCategory.Category) && x.Type == folder.Type && x.Name == max.Key.IconName);

			return null;
		}

		private static IconFile GetFolderIcon(string path)
		{
			if (File.Exists(Path.Combine(path, "desktop.ini")))
			{
				path = Path.GetFullPath(GetIconPath(path)).RegexRemove(@"[A-Z]:");
				return Data.Session.Icons.FirstThat(x => Path.GetFullPath(x.FilePath).RegexRemove(@"[A-Z]:") == path);
			}

			return null;
		}

		private static string GetIconPath(string folderPath)
		{
			SHFILEINFO shinfo = new SHFILEINFO();
			Win32.SHGetFileInfo(folderPath, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), (int)0x1000);
			return shinfo.szDisplayName;
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct SHFILEINFO
		{
			public IntPtr hIcon;
			public int iIcon;
			public uint dwAttributes;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string szDisplayName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
			public string szTypeName;
		};

		private class Win32
		{
			[DllImport("shell32.dll")]
			public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);
		}
		#endregion
	}
}
