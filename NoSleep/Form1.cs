
using System;
using System.Windows.Forms;


namespace NoSleep
{


    public partial class Form1 : Form
    {


        private static System.Drawing.Icon GetIcon()
        {
            System.Drawing.Icon ico = null;
            string strName = null;

            System.Reflection.Assembly ass = System.Reflection.Assembly.GetExecutingAssembly();
            foreach (string str in ass.GetManifestResourceNames())
            {

                if (str.EndsWith("NoSleep.ico", StringComparison.OrdinalIgnoreCase))
                {
                    strName = str;
                } 

            } // Next str 


            using ( System.IO.Stream strmIcon = ass.GetManifestResourceStream(strName) )
            {
                // http://msdn.microsoft.com/en-us/library/system.windows.forms.notifyicon.aspx
                //ico = new System.Drawing.Icon(@"..\..\NoSleep.ico");
                ico = new System.Drawing.Icon(strmIcon);
            } // End Using System.IO.Stream strmIcon

            return ico;
        } // End Function GetIcon


        public Form1()
        {
            InitializeComponent();

            this.Icon = GetIcon();

            this.niTaskBarIcon.Text = "NoSleep";
            this.niTaskBarIcon.Icon = GetIcon();
           


            var TrayContextMenu = new System.Windows.Forms.ContextMenu();

            var MenuItemExit = new System.Windows.Forms.MenuItem();
            MenuItemExit.Index = 0;
            MenuItemExit.Text = "E&xit";
            MenuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);

            TrayContextMenu.MenuItems.AddRange(
                    new System.Windows.Forms.MenuItem[] { MenuItemExit }
            );



            this.niTaskBarIcon.ContextMenu = TrayContextMenu;
            this.niTaskBarIcon.Visible = true;
            this.niTaskBarIcon.DoubleClick += new System.EventHandler(this.niTaskBarIcon_DoubleClick);
            this.niTaskBarIcon.Click += new System.EventHandler(this.niTaskBarIcon_DoubleClick);
        } // End Constructor Form1


        private void MenuItemExit_Click(object Sender, EventArgs e)
        {
            // Close the form, which closes the application. 
            this.Close();
        } // End Sub MenuItemExit_Click


        private void niTaskBarIcon_DoubleClick(object Sender, EventArgs e)
        {
            // Show the form when the user double clicks on the notify icon. 

            // Set the WindowState to normal if the form is minimized. 
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            
            this.ShowInTaskbar = true;
            //this.Visible = true;

            // Activate the form. 
            this.Activate();
        } // End Sub niTaskBarIcon_DoubleClick


        private void btnStartSimulate_Click(object sender, EventArgs e)
        {
            MouseEventSimulator.StartAsync(5, 100);
            this.WindowState = FormWindowState.Minimized;
        } // End Sub btnStartSimulate_Click


        // http://stackoverflow.com/questions/1052913/how-to-detect-when-a-windows-form-is-being-minimized
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                // Do some stuff
                //this.Visible = false;
                this.ShowInTaskbar = false;
            } // End if (WindowState == FormWindowState.Minimized)

        } // End Sub Form1_Resize


        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            MouseEventSimulator.KeepRunning = false;
        } // End Sub Form1_Closing 


    }


}
