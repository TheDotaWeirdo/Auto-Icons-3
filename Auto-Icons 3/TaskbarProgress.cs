using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public static class TaskbarProgress
{
	public enum TaskbarStates
	{
		NoProgress = 0,
		Indeterminate = 0x1,
		Normal = 0x2,
		Error = 0x4,
		Paused = 0x8
	}

	[ComImport()]
	[Guid("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	private interface ITaskbarList3
	{
		// ITaskbarList
		[PreserveSig]
		void HrInit();
		[PreserveSig]
		void AddTab(IntPtr hwnd);
		[PreserveSig]
		void DeleteTab(IntPtr hwnd);
		[PreserveSig]
		void ActivateTab(IntPtr hwnd);
		[PreserveSig]
		void SetActiveAlt(IntPtr hwnd);

		// ITaskbarList2
		[PreserveSig]
		void MarkFullscreenWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

		// ITaskbarList3
		[PreserveSig]
		void SetProgressValue(IntPtr hwnd, UInt64 ullCompleted, UInt64 ullTotal);
		[PreserveSig]
		void SetProgressState(IntPtr hwnd, TaskbarStates state);
	}

	[ComImport()]
	[Guid("56fdf344-fd6d-11d0-958a-006097c9a090")]
	[ClassInterface(ClassInterfaceType.None)]
	private class TaskbarInstance
	{
	}

	private static ITaskbarList3 taskbarInstance = (ITaskbarList3)new TaskbarInstance();
	private static bool taskbarSupported = Environment.OSVersion.Version >= new Version(6, 1);

	public static void SetState(IntPtr windowHandle, TaskbarStates taskbarState)
	{
		if (taskbarSupported) taskbarInstance.SetProgressState(windowHandle, taskbarState);
	}

	public static void SetValue(IntPtr windowHandle, double progressValue, double progressMax)
	{
		if (taskbarSupported) taskbarInstance.SetProgressValue(windowHandle, (ulong)progressValue, (ulong)progressMax);
	}
}

public static class FlashWindow
{
	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

	[StructLayout(LayoutKind.Sequential)]
	private struct FLASHWINFO
	{
		/// <summary>
		/// The size of the structure in bytes.
		/// </summary>
		public uint cbSize;
		/// <summary>
		/// A Handle to the Window to be Flashed. The window can be either opened or minimized.
		/// </summary>
		public IntPtr hwnd;
		/// <summary>
		/// The Flash Status.
		/// </summary>
		public uint dwFlags;
		/// <summary>
		/// The number of times to Flash the window.
		/// </summary>
		public uint uCount;
		/// <summary>
		/// The rate at which the Window is to be flashed, in milliseconds. If Zero, the function uses the default cursor blink rate.
		/// </summary>
		public uint dwTimeout;
	}

	/// <summary>
	/// Stop flashing. The system restores the window to its original stae.
	/// </summary>
	public const uint FLASHW_STOP = 0;

	/// <summary>
	/// Flash the window caption.
	/// </summary>
	public const uint FLASHW_CAPTION = 1;

	/// <summary>
	/// Flash the taskbar button.
	/// </summary>
	public const uint FLASHW_TRAY = 2;

	/// <summary>
	/// Flash both the window caption and taskbar button.
	/// This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags.
	/// </summary>
	public const uint FLASHW_ALL = 3;

	/// <summary>
	/// Flash continuously, until the FLASHW_STOP flag is set.
	/// </summary>
	public const uint FLASHW_TIMER = 4;

	/// <summary>
	/// Flash continuously until the window comes to the foreground.
	/// </summary>
	public const uint FLASHW_TIMERNOFG = 12;


	/// <summary>
	/// Flash the spacified Window (Form) until it recieves focus.
	/// </summary>
	/// <param name="form">The Form (Window) to Flash.</param>
	/// <returns></returns>
	public static bool Flash(System.Windows.Forms.Form form)
	{
		// Make sure we're running under Windows 2000 or later
		if (Win2000OrLater)
		{
			FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_ALL | FLASHW_TIMERNOFG, uint.MaxValue, 0);
			return FlashWindowEx(ref fi);
		}
		return false;
	}

	private static FLASHWINFO Create_FLASHWINFO(IntPtr handle, uint flags, uint count, uint timeout)
	{
		FLASHWINFO fi = new FLASHWINFO();
		fi.cbSize = Convert.ToUInt32(Marshal.SizeOf(fi));
		fi.hwnd = handle;
		fi.dwFlags = flags;
		fi.uCount = count;
		fi.dwTimeout = timeout;
		return fi;
	}

	/// <summary>
	/// Flash the specified Window (form) for the specified number of times
	/// </summary>
	/// <param name="form">The Form (Window) to Flash.</param>
	/// <param name="count">The number of times to Flash.</param>
	/// <returns></returns>
	public static bool Flash(System.Windows.Forms.Form form, uint count)
	{
		if (Win2000OrLater)
		{
			FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_ALL, count, 0);
			return FlashWindowEx(ref fi);
		}
		return false;
	}

	/// <summary>
	/// Start Flashing the specified Window (form)
	/// </summary>
	/// <param name="form">The Form (Window) to Flash.</param>
	/// <returns></returns>
	public static bool Start(System.Windows.Forms.Form form)
	{
		if (Win2000OrLater)
		{
			FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_ALL, uint.MaxValue, 0);
			return FlashWindowEx(ref fi);
		}
		return false;
	}

	/// <summary>
	/// Stop Flashing the specified Window (form)
	/// </summary>
	/// <param name="form"></param>
	/// <returns></returns>
	public static bool Stop(System.Windows.Forms.Form form)
	{
		if (Win2000OrLater)
		{
			FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_STOP, uint.MaxValue, 0);
			return FlashWindowEx(ref fi);
		}
		return false;
	}

	/// <summary>
	/// A boolean value indicating whether the application is running on Windows 2000 or later.
	/// </summary>
	private static bool Win2000OrLater
	{
		get { return System.Environment.OSVersion.Version.Major >= 5; }
	}
}