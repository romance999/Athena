using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Athena.Handler.Win32
{
    class Win32Console
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]

        public static extern bool AllocConsole();  //allocate console

        public static void Update(string message)
        {
            Console.Title = "Athena Console";
            Console.WriteLine(message);
        }
    }
}
