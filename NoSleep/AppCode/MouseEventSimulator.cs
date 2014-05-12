
namespace NoSleep
{


    public class MouseEventSimulator
    {


        [System.Flags]
        private enum MouseEventFlags : uint
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010,
            WHEEL = 0x00000800,
            XDOWN = 0x00000080,
            XUP = 0x00000100
        } // End Enum MouseEventFlags 


        // http://www.pinvoke.net/default.aspx/user32/mouse_event.html
        // http://msdn.microsoft.com/en-us/library/windows/desktop/ms646260(v=vs.85).aspx
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern void mouse_event(MouseEventFlags dwFlags, uint dx, uint dy, uint dwData, System.UIntPtr dwExtraInfo);


        public static void Move(int dx, int dy)
        {
            mouse_event(MouseEventFlags.MOVE, unchecked((uint)dx), unchecked((uint)dy), 0, new System.UIntPtr());
        } // End Sub Move


        public static void SimulateSlightMovement()
        {
            MouseEventSimulator.Move(1, 0);
            MouseEventSimulator.Move(-1, 0);
        } // End Sub SimulateSlightMovement


        public static void SimulateSlightMovementContinuously()
        {
            SimulateSlightMovementContinuously(30, 1);
        } // End Sub SimulateSlightMovementContinuously


        public static bool KeepRunning = true;


        // MouseEventSimulator.SimulateSlightMovementContinuously(10, 100);
        public static void SimulateSlightMovementContinuously(int interval, int strength)
        {
            while (KeepRunning)
            {
                MouseEventSimulator.Move(strength, 0);
                //System.Threading.Thread.Sleep(interval * 1000);
                MouseEventSimulator.Move(-strength, 0);
                System.Threading.Thread.Sleep(interval * 1000);
            } // Whend
        } // End Sub SimulateSlightMovementContinuously


        private static void StartAsyncWrapper(object obj)
        {
            int[] args = (int[])obj;
            SimulateSlightMovementContinuously(args[0], args[1]);
        } // End Sub StartAsyncWrapper


        public static void StartAsync()
        {
            StartAsync(30, 1);
        } // End Sub StartAsync


        public static void StartAsync(int interval, int strength)
        {
            System.Threading.ParameterizedThreadStart ts = new System.Threading.ParameterizedThreadStart(StartAsyncWrapper);
            
            System.Threading.Thread th = new System.Threading.Thread(ts);

            object obj = (object)new int[] { interval, strength };

            th.Start(obj);
        } // End Sub StartAsync


        public static void OnCancel(object sender, System.ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
            KeepRunning = false;
        } // End Sub OnCancel 


    } // End Class MouseEventSimulator


} // End Namespace NoSleep
