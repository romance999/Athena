using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Athena.Handler.Memory
{
    class CodeCave
    {
        [DllImport("kernel32.dll")]

        static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]

        static extern int CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll")]

        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddres, int dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll")]
        static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, int size, int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, int dwFreeType);

        public static IntPtr createCodeCave(string process, int cavesize)
        {
            var proc = Process.GetProcessesByName(process)[0];
            var hndProc = OpenProcess(0x0008 | 0x0020, 1, proc.Id); //get handle
            var caveAddress = VirtualAllocEx(hndProc, (IntPtr)null, cavesize, 0x1000 | 0x2000, 0x40); //allocate memory
            CloseHandle(hndProc);
            return caveAddress;
        }

        public static int writeToCave(string process, IntPtr caveAddress, byte[] code)
        {
            var proc = Process.GetProcessesByName(process)[0];
            var hndProc = OpenProcess(0x0020 | 0x008, 1, proc.Id);

            return WriteProcessMemory(hndProc, caveAddress, code, code.Length, 0);
        }

        public static int releaseCave(string process, IntPtr caveAddress)
        {
            var proc = Process.GetProcessesByName(process)[0];
            var hndProc = OpenProcess(0x0008, 1, proc.Id);
            var rel = VirtualFreeEx(hndProc, caveAddress, 0, 0x000008000);
            if (rel)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
