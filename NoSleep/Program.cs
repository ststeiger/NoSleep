
using System;
using System.Windows.Forms;


namespace NoSleep
{


    static class Program
    {


        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.CancelKeyPress += MouseEventSimulator.OnCancel;
            /*
            Console.CancelKeyPress += delegate(object sender, ConsoleCancelEventArgs e)
            {
                e.Cancel = true;
                MouseEventSimulator.KeepRunning = false;
            };
            */

            bool bWinFormsMode = true;

            if (bWinFormsMode)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                Console.WriteLine("Simulating mouse input.\nPress [CTRL + C] to quit.");
                MouseEventSimulator.SimulateSlightMovementContinuously(10, 100);
            }
            
        } // End Sub Main 


    } // End Class Program


} // End Namespace NoSleep
