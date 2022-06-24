using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Athena.Handler;

namespace Athena.Handler.Input
{
    class Keyboard
    {
        public static string[] keyArray = new string[] { "W", "A", "S", "D" };
        public static string[] wordArray = new string[] { ".", "cock", "fuck you", "kys", "fucked your mom", "you have a small dick", "get good", "ur bad at the game", "stop crying", "bozo", "rip bozo" };

        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);
        [STAThread]

        public static void AntiAfk()
        {
            try
            {
                Process[] processes = Process.GetProcessesByName("GTA5");
                while (Data.antiafk == true)
                {

                    foreach (Process proc in processes)
                    {
                        SetForegroundWindow(proc.MainWindowHandle);
                        SendKeys.SendWait("A");
                        Thread.Sleep(300);
                        SendKeys.SendWait("A");
                        Thread.Sleep(300);
                        SendKeys.SendWait("D");
                        Thread.Sleep(300);
                        SendKeys.SendWait("D");
                        Thread.Sleep(300);
                        SendKeys.SendWait("W");
                        Thread.Sleep(300);
                        SendKeys.SendWait("S");
                        Thread.Sleep(300);
                        SendKeys.SendWait("S");
                        Thread.Sleep(300);
                        SendKeys.SendWait("W");
                        Thread.Sleep(300);
                    }
                    Thread.Sleep(300);
                }
                if (Data.antiafk == false)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
        }

        public static void RandomAntiAfk()
        {
            try
            {
                Process[] processes = Process.GetProcessesByName("GTA5");
                while (Data.antiafk == true)
                {
                    foreach (Process proc in processes)
                    {
                        Random random = new Random();
                        int value = random.Next(0, keyArray.Length);
                        SendKeys.SendWait(keyArray[value]);
                    }
                    Thread.Sleep(50);
                }
                if (Data.antiafk == false)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
        }

        public static void ChatSpam()
        {
            try
            {
                Process[] processes = Process.GetProcessesByName("GTA5");
                while (Data.spam == true)
                {
                    foreach (Process proc in processes)
                    {
                        //13 is the keycode for enter
                        Random random = new Random();
                        int value = random.Next(0, keyArray.Length);
                        SendKeys.SendWait("13"); // open chat
                        SendKeys.SendWait(wordArray[value]);
                        SendKeys.SendWait("13"); // close chat
                        SendKeys.SendWait("13"); // open chat
                        SendKeys.SendWait(wordArray[value]);
                        SendKeys.SendWait("13"); //close chat
                    }
                    Thread.Sleep(3000);
                }
                if (Data.spam == true)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
        }
    }
}
