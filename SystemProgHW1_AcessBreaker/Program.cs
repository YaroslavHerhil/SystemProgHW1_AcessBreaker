using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


//Howdy 
//This little piece of code is intended to be run while SystemProgHW1 is running :)

namespace SystemProgHW1_AcessBreaker
{
    internal class Program
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string sClass, string sWindow);


        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint wMsg, IntPtr wParam, IntPtr lParam);


        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint RegisterWindowMessage(string lpString);
        static void Main(string[] args)
        {

            
            bool isBrocken = false;
            while (!isBrocken)
            {
                Console.Clear();
                Console.WriteLine("Press any key to break access lock");
                Console.ReadKey();
                Console.Clear();
                IntPtr nWinHandle = FindWindow(null, "12B-L3");
                uint id = RegisterWindowMessage("BreakAccessLock");
                if (nWinHandle != IntPtr.Zero)
                {
                    SendMessage(nWinHandle, id, IntPtr.Zero, IntPtr.Zero);
                    Console.WriteLine("Lock succesfully brocken");
                    isBrocken = true;
                }
                else
                {
                    Console.WriteLine("Please open 12B-L3 report");
                    Console.ReadKey();
                }
            }

            Console.ReadKey();
        }
    }
}
