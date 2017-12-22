using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Auto_Icons_3
{
	public class ItemFile
	{
      public string   FilePath { get; private set; }
      public string   Name     { get; private set; }
      public string[] Formats	 { get; private set; }
      public bool     Folder   { get; private set; }
      public bool     Major    { get; private set; }
      public IconType Type     { get; private set; }

		public ItemFile(string path)
		{
			FilePath = path;
			Formats = BackEndWorker.GetFormats(path);
			Name = Formats[1];
			Folder = BackEndWorker.IsFolder(path);
			Major = BackEndWorker.IsMajor(path);
			Type = BackEndWorker.GetType(path);
		}
	}
}
