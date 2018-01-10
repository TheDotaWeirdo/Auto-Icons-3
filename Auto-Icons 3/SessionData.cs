using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Icons_3
{
	public enum SessionAction { Reset, Change }

	public class SessionData
	{
		public List<IconFile> Icons;
		public List<ItemFile> Files;
		public List<ItemFile> Shortcuts;
		public List<ItemFile> Folders;
		public List<ItemFile> SecondPassFolders;
		public List<string>	 WorkingPaths;
		public SessionAction	 SessionAction;
		public int				 Stage;
		public int				 LastShortcut;
		public int				 LastFolder;
		public int				 LastSecondPass;
		public int				 LastProccessedFile;
		public int[]			 StageErrors;
		public bool				 O_ChangeShortcuts;
		public bool				 O_ChangeFolders;
		public bool				 O_IncludeSubFolders;
		public bool				 O_DriveDependant;
		public bool				 O_TurboMode;

#if DEBUG
		public List<Exception> Exceptions = new List<Exception>();
#endif

		private IconFile folderIcon;
		public IconFile FolderIcon => folderIcon 
			?? (folderIcon = Icons.Where(x => x.Formats[0].Base == "Folder").FirstOrDefault());
		public int Errors => StageErrors.Sum();

		public SessionData()
		{
			Files = new List<ItemFile>();
			Shortcuts = new List<ItemFile>();
			Folders = new List<ItemFile>();
			SecondPassFolders = new List<ItemFile>();
			Icons = new List<IconFile>();
			WorkingPaths = new List<string>();
			StageErrors = new int[] { 0, 0, 0, 0, 0 };
			Stage = 0;
			LastShortcut = 0;
			LastFolder = 0;
			LastSecondPass = 0;
		}
	}
}
