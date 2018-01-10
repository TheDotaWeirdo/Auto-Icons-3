namespace Auto_Icons_3
{
	public class FileTypeCategory
	{
		public string   IconName;
		public string[] Extensions;

		private FileTypeCategory(string iconName, string[] extensions)
		{
			IconName = iconName;
			Extensions = extensions;
		}

		public static FileTypeCategory[] Categories => new FileTypeCategory[]
		{
			Application	, Archive,
			eBook			, Fonts	,
			Music			, Office	,
			Videos		, Pictures,
			Photoshop	, Icons
		};

		public static FileTypeCategory Application 
			= new FileTypeCategory("Application", new string[] {
				".exe"
			});

		public static FileTypeCategory Icons
			= new FileTypeCategory("Icons", new string[] {
				".ico"
			});

		public static FileTypeCategory Archive
			= new FileTypeCategory("Archive", new string[] {
				".zip", ".7z", ".rar"
			});

		public static FileTypeCategory eBook
			= new FileTypeCategory("eBook", new string[] {
				".epub"
			});

		public static FileTypeCategory Fonts
			= new FileTypeCategory("Fonts", new string[] {
				".fon", ".ttf", ".otf"
			});

		public static FileTypeCategory Music
			= new FileTypeCategory("Music", new string[] {
				".mp3", ".aac",
				".flac", ".m4a",
				".opus", ".wav"
			});

		public static FileTypeCategory Office
			= new FileTypeCategory("Office" , new string[] {
				".docx", ".doc",
				".xlsx", ".xls",
				".pptx", ".ppt",
				".vsdx", ".vsd"
			});

		public static FileTypeCategory Pictures
			= new FileTypeCategory("Pictures", new string[] {
				".tif"  , ".tiff",
				".gif"  , ".jpeg",
				".jpg"  , ".jif" ,
				".jfif" , ".jp2" ,
				".jpx"  , ".png"
			});

		public static FileTypeCategory Videos
			= new FileTypeCategory("Videos", new string[] {
				".mkv"  , ".webm" , ".flv"  , "vob"   , ".ogv",
				".ogg"  , ".drc"  , ".mng"  , ".avi"  , ".mov",
				".wmv"  , ".amv"  , ".mp4"  , ".m4v"  , ".amv",
				".mpg"  , ".mpeg" , ".3gp"  , ".f4v"  
			});

		public static FileTypeCategory Photoshop
			= new FileTypeCategory("Photoshop CC", new string[] {
				".psd"
			});
	}	
}
