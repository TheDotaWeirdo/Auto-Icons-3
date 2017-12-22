using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensions;

namespace Auto_Icons_3
{
	class Data
	{
		public static SessionData CurrentSession = new SessionData();

		#region Design
		private static FormDesign design = FormDesign.Dark;

		public static FormDesign Design
		{
			get => design;
			set
			{
				design = (value == FormDesign.Custom && !FormDesign.IsCustomEligible()) ? design : value;
				DesignChanged?.Invoke(null, null);
			}
		}

		public static EventHandler DesignChanged;
		#endregion
	}
}
