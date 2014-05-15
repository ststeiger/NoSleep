
using System;
using System.Windows.Forms;


namespace NoSleep
{


    static class Program
    {

        // http://stackoverflow.com/questions/311165/how-do-you-convert-byte-array-to-hexadecimal-string-and-vice-versa
        public static string ByteArrayToString(byte[] ba)
        {
            System.Text.StringBuilder hex = new System.Text.StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);

            return hex.ToString();
        }

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length / 2;
            byte[] bytes = new byte[NumberChars];
            using (System.IO.StringReader sr = new System.IO.StringReader(hex))
            {
                for (int i = 0; i < NumberChars; i++)
                    bytes[i] = Convert.ToByte(new string(new char[2] { (char)sr.Read(), (char)sr.Read() }), 16);
            }
            return bytes;
        }



        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //byte[] bla = System.IO.File.ReadAllBytes(@"D:\Stefan.Steiger\Desktop\noimage.jpg");

            //// Unterschied liegt im D ...
            ////byte[] bla = System.IO.File.ReadAllBytes(@"D:\Stefan.Steiger\Desktop\FlashDWG_License.txt");
            ////byte[] bla = System.IO.File.ReadAllBytes(@"‪D:\Stefan.Steiger\Desktop\FlashDWG_License.txt");
            //Console.WriteLine(bla.Length);
            //string str = ByteArrayToString(bla);
            //Console.WriteLine(str);



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
