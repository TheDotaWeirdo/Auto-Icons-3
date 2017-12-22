using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Icons_3
{
	public class SessionData
	{
		public Dictionary<ItemFile, IconFile>	Matches;
		public List<IconFile>						Icons;
		public List<string>							WorkingPaths;

		public SessionData()
		{
			Matches = new Dictionary<ItemFile, IconFile>();
			Icons = new List<IconFile>();
			WorkingPaths = new List<string>();
		}
	}
}
