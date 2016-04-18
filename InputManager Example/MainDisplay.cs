using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using InputManager;

namespace InputManager_Example
{
    public partial class MainDisplay : Form
    {
        public MainDisplay()
        {
            InitializeComponent();
        }

        private void MainDisplay_Load(object sender, EventArgs e)
        {
            //Adding keyboard event handlers and installing the hook
            KeyboardHook.KeyDown += new KeyboardHook.KeyDownEventHandler(KeyboardHook_KeyDown);
            KeyboardHook.KeyUp += new KeyboardHook.KeyUpEventHandler(KeyboardHook_KeyUp);
            KeyboardHook.InstallHook();

            //Adding mouse event handlers and installing the hook
            //MouseHook.MouseEvent += new MouseHook.MouseEventEventHandler(MouseHook_MouseEvent);
            //MouseHook.MouseMove += new MouseHook.MouseMoveEventHandler(MouseHook_MouseMove);
            //MouseHook.WheelEvent += new MouseHook.WheelEventEventHandler(MouseHook_WheelEvent);
            //MouseHook.InstallHook();
        }

        void MouseHook_WheelEvent(MouseHook.MouseWheelEvents wEvent)
        {
            //Event time the wheel was scrolled the application will go to this line
            //Using the wEvent argument we can detect if the mouse was scrolled forward or backward

            string scrollDirection;
            if (wEvent == MouseHook.MouseWheelEvents.ScrollDown) scrollDirection = "scrolled down";
            else scrollDirection = "scrolled up";

            //Log.Items.Add("The user mouse wheel was " + scrollDirection);
        }

        void MouseHook_MouseMove(MouseHook.POINT ptLocat)
        {
            //Everytime the mouse moved, the application will go to this line
            //Using the ptLocat arguments you can detect which point the mouse cursor moved to

           // Log.Items.Add("The mouse cursor moved to: " + ptLocat.x + ", " + ptLocat.y);
        }

        void MouseHook_MouseEvent(MouseHook.MouseEvents mEvent)
        {
            //Everytime a mouse button changed it's state (from up to down or down to up) the application will go to this line
            //Using the mEvent argument we can detect which button changed it's state

            //Log.Items.Add("Mouse button changed state to: " + mEvent.ToString());
        }

        void KeyboardHook_KeyUp(int vkCode)
        {
            //Everytime the users releases a certain key up, your application will go to this line
            //Use the vKCode argument to determine which key has been released

            string keyString = ((Keys)vkCode).ToString(); //Convert the numeric value to a user easy to recognize string
            //Log.AppendText(keyString); //Add the message to the Log listbox.
        }

        void KeyboardHook_KeyDown(int vkCode)
        {
            //Everytime the users holds a certain key down, your application will go to this line
            //Use the vKCode argument to determine which key is held down

            string keyString = ((Keys)vkCode).ToString(); //Convert the numeric value to a user easy to recognize string
            Log.AppendText(keyString); //Add the message to the Log listbox.
        }
    }
}
