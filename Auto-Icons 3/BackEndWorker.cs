using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Extensions;

namespace Auto_Icons_3
{
	public static class BackEndWorker
	{
		public static void CloseExplorerWindows()
			=> EnumWindows(new EnumWindowsProc(EnumTheWindows), IntPtr.Zero);

		public static bool Compare(this List<Format> format1, List<Format> format2, FormatComparer comparerFirst, FormatComparer comparerSecond)
			=> format1.Any(f1 => format2.Any(f2 =>
				f1.PropertyFromComparer(comparerFirst) == f2.PropertyFromComparer(comparerSecond)));

		public static IconCategory[] GetCategories(ItemFile file)
		{
			var Out = new List<IconCategory>();

			if (ParentNameCheck(file, new string[] { "photoshop" }, 1))
				Out.Add(IconCategory.Photoshop);

			if (ParentNameCheck(file, new string[] { "movies", "films" }, 2))
				Out.Add(IconCategory.Movie);

			if (ParentNameCheck(file, new string[] { "series", "tv series" }, 2))
				Out.Add(IconCategory.TV);

			if (ParentNameCheck(file, new string[] { "anime" }, 2))
				Out.Add(IconCategory.Anime);

			if (ParentNameCheck(file, new string[] { "games", "gaming" }, 2))
				Out.Add(IconCategory.Game);

			if (ParentNameCheck(file, new string[] { "application", "apps" }, 1))
				Out.Add(IconCategory.Application);

			return Out.Count == 0 ? new IconCategory[] { IconCategory.Any } : Out.ToArray();
		}

		public static List<IconFile> GetIcons(string path, int layers = 2)
		{
			if (!Directory.Exists(path))
				throw new Exception("Invalid Path");

			var Out = new List<IconFile>(400);
			try
			{
				foreach (var file in ExtensionClass.GetFiles(path, "*.ico", layers))
					Out.Add(new IconFile(file));
			}
			catch (UnauthorizedAccessException) { }

			return Out;
		}

		public static string GetIconsVersion(List<IconFile> list)
		{
			if (list.Any(x => x.Formats[0].Base == "Folder CP Sharp"))
				return "#SHARP v3";

			if (list.Any(x => x.Formats[0].Base == "Folder C Sharp"))
				return "#SHARP v2";

			if (list.Any(x => x.Formats[0].Base == "Folder Sharp"))
				return "#SHARP";

			if (list.Any(x => x.Formats[0].Base == "Folder eTrans"))
				return "eTrans";

			if (list.Any(x => x.Formats[0].Base.StartsWith("Folder Alt osX")))
				return "Alt osX";

			return "Custom";
		}

		public static IconType GetType(string path)
		{
			if (path.EndsWith(".lnk"))
				path = path.GetShortcutPath();

			if (Directory.GetParent(path).Parent == null || Directory.GetParent(path).Name.ToLower() == "desktop")
				return IconType.Major;

			if ((Directory.Exists(path)) && File.GetAttributes(path).HasFlag(FileAttributes.Directory))
				return IconType.Folder;

			return IconType.Normal;
		}

		public static void RefreshIcons()
		{
			var objProcess = new System.Diagnostics.Process();
			objProcess.StartInfo.FileName = @"C:\Windows\System32\ie4uinit.exe";
			objProcess.StartInfo.Arguments = "-show";
			objProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
			objProcess.Start();
			objProcess.WaitForExit();
			objProcess.Close();
		}

		public static Exception SetIcon(ItemFile itemFile)
		{
			try
			{
				if (itemFile.FilePath.EndsWith(".lnk"))
					UpdateShortcut(itemFile);
				else
					UpdateFolder(itemFile);
			}
			catch (Exception ex) { return ex; }

			return null;
		}

		private static bool ParentNameCheck(ItemFile file, string[] querry, int depth)
		{
			if (file.Type == IconType.Normal)
				depth++;

			var parents = file.Parents.Trim(0, depth).Convert(x => Path.GetFileName(x).ToLower());

			return (parents.Any(x => querry.Any(y => y == x
				 || IconMatcher.SpellCheck(x, y) < 3
				 || x.Contains(y))));
		}

		#region Explorer Closing Methods

		private static uint WM_CLOSE = 0x10;

		private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

		private static bool EnumTheWindows(IntPtr hWnd, IntPtr lParam)
		{
			int size = GetWindowTextLength(hWnd);
			if (size++ > 0 && IsWindowVisible(hWnd))
			{
				var sb = new StringBuilder(size);
				GetWindowText(hWnd, sb, size);

				var threadID = GetWindowThreadProcessId(hWnd, out var processID);
				var s = System.Diagnostics.Process.GetProcessById((int)processID).ProcessName;

				if (s == "explorer" && sb.ToString() != "Program Manager")
					SendMessage(hWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
			}
			return true;
		}

		[DllImport("user32.dll")]
		private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		private static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		private static extern int GetWindowTextLength(IntPtr hWnd);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

		[DllImport("user32.dll")]
		private static extern bool IsWindowVisible(IntPtr hWnd);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

		#endregion Explorer Closing Methods

		#region Update Methods

		public static void UpdateFolder(ItemFile Folder)
		{
			Folder.Match = Folder.Match ?? Data.Session.FolderIcon;
			var iniPath = Path.Combine(Folder.FilePath, "desktop.ini");

			if (Folder.Match == null)
				return;

			if (File.Exists(iniPath))
			{
				//remove hidden and system attributes to make ini file writable
				File.SetAttributes(
					iniPath,
					File.GetAttributes(iniPath) &
					~(FileAttributes.Hidden | FileAttributes.System));
			}

			//create new ini file with the required contents
			var iniContents = $"[.ShellClassInfo]\r\n" +
				$"IconResource = {Folder.Match.FilePath.Substring(Data.Session.O_DriveDependant ? 0 : 2)},0\r\n" +
				$"[ViewState]\r\n" +
				$"Mode =\r\n" +
				$"Vid =\r\n" +
				$"FolderType = Generic";
			File.WriteAllText(iniPath, iniContents);

			//hide the ini file and set it as system
			File.SetAttributes(
				iniPath,
				File.GetAttributes(iniPath) | FileAttributes.Hidden | FileAttributes.System);
			//set the folder as system
			File.SetAttributes(
				 Folder.FilePath,
				 File.GetAttributes(Folder.FilePath) | FileAttributes.System);
		}

		public static void UpdateShortcut(ItemFile Shortcut)
		{
			Type t = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")); //Windows Script Host Shell Object
			dynamic shell = Activator.CreateInstance(t);

			var TargetPath = Shortcut.FilePath.GetShortcutPath();
			var IconPath = Shortcut.Match == null ? Shortcut.FilePath.GetShortcutPath() : Shortcut.Match.FilePath.Substring(Data.Session.O_DriveDependant ? 0 : 2);

			if (IconPath == "") return;

			try
			{
				var lnk = shell.CreateShortcut(Shortcut.FilePath);
				try
				{
					lnk.TargetPath = TargetPath;
					lnk.IconLocation = IconPath;
					lnk.Save();
				}
				finally
				{
					Marshal.FinalReleaseComObject(lnk);
				}
			}
			finally
			{
				Marshal.FinalReleaseComObject(shell);
			}
		}

		#endregion Update Methods
	}
}