using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX.XInput;
using System.Runtime.InteropServices;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Net.Mime.MediaTypeNames;

namespace BugXbox360
{
    public partial class Form1 : Form
    {
        private int m_maintick = 0;

        private int bounce_delay = 200;

        private Controller controller;
        private Gamepad stateGamepad; // Gamepad nesnesini saklamak için
        private GamepadButtonFlags xbox_but;

        private bool isr_FKeyboard = false;
        private bool isr_A = false;
        private bool isr_B = false;
        private bool isr_X = false;
        private bool isr_Y = false;
        private bool isr_LS = false;
        private bool isr_RS = false;
        private bool isr_LT = false;
        private bool isr_RT = false;         
        private bool isr_DL = false;
        private bool isr_DR = false;
        private bool isr_DU = false;
        private bool isr_DD = false;
        private bool isr_ST = false;
        private bool isr_BK = false;
        


        [DllImport("user32.dll")]
        private static extern int GetAsyncKeyState(Keys vKey);

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        private const int KEYEVENTF_KEYUP = 0x0002;

        private int headlight_tick;
        private int lobby_tick;

        public Form1()
        {
            InitializeComponent();
            main_timer.Interval = 50;
            main_timer.Enabled = true;
            main_timer.Start();

            lobby_timer.Interval = 100;
            lobby_timer.Enabled = true;
            lobby_timer.Start();

            headlight_anim1_timer.Interval = 50;
            headlight_anim1_timer.Enabled = true;
            headlight_anim1_timer.Start();

            controller = new Controller(UserIndex.One);
        }

        private void main_run_Tick(object sender, EventArgs e)
        {
            m_maintick++;

            if (controller != null && controller.IsConnected)
            {
                if ((GetAsyncKeyState(Keys.F7) & 0x8000) != 0)
                {
                    isr_FKeyboard = !isr_FKeyboard;
                    Thread.Sleep(bounce_delay);
                }

                var state = controller.GetState();
                stateGamepad = state.Gamepad; 
                xbox_but = stateGamepad.Buttons; 

                if ((xbox_but & GamepadButtonFlags.A) == GamepadButtonFlags.A)
                {
                    isr_A = !isr_A;
                    Thread.Sleep(bounce_delay);
                    Console.WriteLine(isr_A);
                }

                if ((xbox_but & GamepadButtonFlags.B) == GamepadButtonFlags.B)
                {
                    isr_B = !isr_B;
                    Thread.Sleep(bounce_delay);
                }

                if ((xbox_but & GamepadButtonFlags.X) == GamepadButtonFlags.X)
                {
                    isr_X = !isr_X;
                    Thread.Sleep(bounce_delay);
                }

                if ((xbox_but & GamepadButtonFlags.Y) == GamepadButtonFlags.Y)
                {
                    isr_Y = !isr_Y;
                    Thread.Sleep(bounce_delay);
                }

                if ((xbox_but & GamepadButtonFlags.LeftShoulder) == GamepadButtonFlags.LeftShoulder)
                {
                    isr_LS = !isr_LS;
                    Thread.Sleep(bounce_delay);
                }

                if ((xbox_but & GamepadButtonFlags.RightShoulder) == GamepadButtonFlags.RightShoulder)
                {
                    isr_RS = !isr_RS;
                    Thread.Sleep(bounce_delay);
                }

                if ((xbox_but & GamepadButtonFlags.LeftThumb) == GamepadButtonFlags.LeftThumb)
                {
                    isr_LT = !isr_LT;
                    Thread.Sleep(bounce_delay);
                }

                if ((xbox_but & GamepadButtonFlags.RightThumb) == GamepadButtonFlags.RightThumb)
                {
                    isr_RT = !isr_RT;
                    Thread.Sleep(bounce_delay);
                }

                if ((xbox_but & GamepadButtonFlags.DPadLeft) == GamepadButtonFlags.DPadLeft)
                {
                    isr_DL = !isr_DL;
                    Thread.Sleep(bounce_delay);
                }

                if ((xbox_but & GamepadButtonFlags.DPadRight) == GamepadButtonFlags.DPadRight)
                {
                    isr_DR = !isr_DR;
                    Thread.Sleep(bounce_delay);
                }

                if ((xbox_but & GamepadButtonFlags.DPadUp) == GamepadButtonFlags.DPadUp)
                {
                    isr_DU = !isr_DU;
                    Thread.Sleep(bounce_delay);
                }

                if ((xbox_but & GamepadButtonFlags.DPadDown) == GamepadButtonFlags.DPadDown)
                {
                    isr_DD = !isr_DD;
                    Thread.Sleep(bounce_delay);
                }

                if ((xbox_but & GamepadButtonFlags.Start) == GamepadButtonFlags.Start)
                {
                    isr_ST = !isr_ST;
                    Thread.Sleep(bounce_delay);
                }

                if ((xbox_but & GamepadButtonFlags.Back) == GamepadButtonFlags.Back)
                {
                    isr_BK = !isr_BK;
                    Thread.Sleep(bounce_delay);
                }

 //               m_but_functions(isr_A, isr_B, isr_X, isr_Y, isr_LS, isr_RS, isr_LT, isr_RT, isr_DL, isr_DR, isr_DU, isr_DD, isr_ST, isr_BK);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (controller != null && controller.IsConnected)
            {
                var state = controller.GetState();
                var xbox_but = state.Gamepad.Buttons; //state.Gamepad.LeftThumbX - state.Gamepad.LeftTrigger
            }
            else
            {
                MessageBox.Show("Controller is not connected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void apply_button_Click(object sender, EventArgs e)
        {
            if (int.TryParse(headlight_textbox.Text, out headlight_tick)){
                headlight_anim1_timer.Interval = headlight_tick;
            }
            else MessageBox.Show("Please enter headlight toggle ms delay !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (int.TryParse(lobby_textbox.Text, out lobby_tick))
            {
                lobby_timer.Interval = lobby_tick;
            }
            else MessageBox.Show("Please enter lobby toggle ms delay !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /*private void m_but_functions(bool A, bool B, bool X, bool Y, bool LS, bool RS, bool LT, bool RT, bool DL, bool DR, bool DU, bool DD, bool ST, bool BK)
        {
        }*/

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void headlight_anim1_timer_Tick(object sender, EventArgs e)
        {
            if(isr_RS == true)
            {
                keybd_event(VirtualKeyCodes.VK_L, 0, 0, UIntPtr.Zero);
                System.Threading.Thread.Sleep(10);
                keybd_event(VirtualKeyCodes.VK_L, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
            }
        }

        private void lobby_timer_Tick(object sender, EventArgs e)
        {
            if(isr_FKeyboard == true)
            {
                keybd_event(VirtualKeyCodes.VK_SPACE, 0, 0, UIntPtr.Zero);
                System.Threading.Thread.Sleep(50);
                keybd_event(VirtualKeyCodes.VK_SPACE, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
            }
        }
    }
}

public static class VirtualKeyCodes
{
    public const byte VK_LBUTTON = 0x01; // Left mouse button
    public const byte VK_RBUTTON = 0x02; // Right mouse button
    public const byte VK_CANCEL = 0x03; // Control-break processing
    public const byte VK_MBUTTON = 0x04; // Middle mouse button (three-button mouse)
    public const byte VK_XBUTTON1 = 0x05; // X1 mouse button
    public const byte VK_XBUTTON2 = 0x06; // X2 mouse button
    public const byte VK_BACK = 0x08; // BACKSPACE key
    public const byte VK_TAB = 0x09; // TAB key
    public const byte VK_CLEAR = 0x0C; // CLEAR key
    public const byte VK_RETURN = 0x0D; // ENTER key
    public const byte VK_SHIFT = 0x10; // SHIFT key
    public const byte VK_CONTROL = 0x11; // CTRL key
    public const byte VK_MENU = 0x12; // ALT key
    public const byte VK_PAUSE = 0x13; // PAUSE key
    public const byte VK_CAPITAL = 0x14; // CAPS LOCK key
    public const byte VK_KANA = 0x15; // IME Kana mode
    public const byte VK_HANGUL = 0x15; // IME Hangul mode
    public const byte VK_JUNJA = 0x17; // IME Junja mode
    public const byte VK_FINAL = 0x18; // IME final mode
    public const byte VK_HANJA = 0x19; // IME Hanja mode
    public const byte VK_KANJI = 0x19; // IME Kanji mode
    public const byte VK_ESCAPE = 0x1B; // ESC key
    public const byte VK_CONVERT = 0x1C; // IME convert
    public const byte VK_NONCONVERT = 0x1D; // IME nonconvert
    public const byte VK_ACCEPT = 0x1E; // IME accept
    public const byte VK_MODECHANGE = 0x1F; // IME mode change request
    public const byte VK_SPACE = 0x20; // SPACEBAR
    public const byte VK_PRIOR = 0x21; // PAGE UP key
    public const byte VK_NEXT = 0x22; // PAGE DOWN key
    public const byte VK_END = 0x23; // END key
    public const byte VK_HOME = 0x24; // HOME key
    public const byte VK_LEFT = 0x25; // LEFT ARROW key
    public const byte VK_UP = 0x26; // UP ARROW key
    public const byte VK_RIGHT = 0x27; // RIGHT ARROW key
    public const byte VK_DOWN = 0x28; // DOWN ARROW key
    public const byte VK_SELECT = 0x29; // SELECT key
    public const byte VK_PRINT = 0x2A; // PRINT key
    public const byte VK_EXECUTE = 0x2B; // EXECUTE key
    public const byte VK_SNAPSHOT = 0x2C; // PRINT SCREEN key
    public const byte VK_INSERT = 0x2D; // INS key
    public const byte VK_DELETE = 0x2E; // DEL key
    public const byte VK_HELP = 0x2F; // HELP key
    public const byte VK_0 = 0x30; // 0 key
    public const byte VK_1 = 0x31; // 1 key
    public const byte VK_2 = 0x32; // 2 key
    public const byte VK_3 = 0x33; // 3 key
    public const byte VK_4 = 0x34; // 4 key
    public const byte VK_5 = 0x35; // 5 key
    public const byte VK_6 = 0x36; // 6 key
    public const byte VK_7 = 0x37; // 7 key
    public const byte VK_8 = 0x38; // 8 key
    public const byte VK_9 = 0x39; // 9 key
    public const byte VK_A = 0x41; // A key
    public const byte VK_B = 0x42; // B key
    public const byte VK_C = 0x43; // C key
    public const byte VK_D = 0x44; // D key
    public const byte VK_E = 0x45; // E key
    public const byte VK_F = 0x46; // F key
    public const byte VK_G = 0x47; // G key
    public const byte VK_H = 0x48; // H key
    public const byte VK_I = 0x49; // I key
    public const byte VK_J = 0x4A; // J key
    public const byte VK_K = 0x4B; // K key
    public const byte VK_L = 0x4C; // L key
    public const byte VK_M = 0x4D; // M key
    public const byte VK_N = 0x4E; // N key
    public const byte VK_O = 0x4F; // O key
    public const byte VK_P = 0x50; // P key
    public const byte VK_Q = 0x51; // Q key
    public const byte VK_R = 0x52; // R key
    public const byte VK_S = 0x53; // S key
    public const byte VK_T = 0x54; // T key
    public const byte VK_U = 0x55; // U key
    public const byte VK_V = 0x56; // V key
    public const byte VK_W = 0x57; // W key
    public const byte VK_X = 0x58; // X key
    public const byte VK_Y = 0x59; // Y key
    public const byte VK_Z = 0x5A; // Z key
    public const byte VK_LWIN = 0x5B; // Left Windows key (Natural keyboard)
    public const byte VK_RWIN = 0x5C; // Right Windows key (Natural keyboard)
    public const byte VK_APPS = 0x5D; // Applications key (Natural keyboard)
    public const byte VK_SLEEP = 0x5F; // Computer Sleep key
    public const byte VK_NUMPAD0 = 0x60; // Numeric keypad 0 key
    public const byte VK_NUMPAD1 = 0x61; // Numeric keypad 1 key
    public const byte VK_NUMPAD2 = 0x62; // Numeric keypad 2 key
    public const byte VK_NUMPAD3 = 0x63; // Numeric keypad 3 key
    public const byte VK_NUMPAD4 = 0x64; // Numeric keypad 4 key
    public const byte VK_NUMPAD5 = 0x65; // Numeric keypad 5 key
    public const byte VK_NUMPAD6 = 0x66; // Numeric keypad 6 key
    public const byte VK_NUMPAD7 = 0x67; // Numeric keypad 7 key
    public const byte VK_NUMPAD8 = 0x68; // Numeric keypad 8 key
    public const byte VK_NUMPAD9 = 0x69; // Numeric keypad 9 key
    public const byte VK_MULTIPLY = 0x6A; // Multiply key
    public const byte VK_ADD = 0x6B; // Add key
    public const byte VK_SEPARATOR = 0x6C; // Separator key
    public const byte VK_SUBTRACT = 0x6D; // Subtract key
    public const byte VK_DECIMAL = 0x6E; // Decimal key
    public const byte VK_DIVIDE = 0x6F; // Divide key
    public const byte VK_F1 = 0x70; // F1 key
    public const byte VK_F2 = 0x71; // F2 key
    public const byte VK_F3 = 0x72; // F3 key
    public const byte VK_F4 = 0x73; // F4 key
    public const byte VK_F5 = 0x74; // F5 key
    public const byte VK_F6 = 0x75; // F6 key
    public const byte VK_F7 = 0x76; // F7 key
    public const byte VK_F8 = 0x77; // F8 key
    public const byte VK_F9 = 0x78; // F9 key
    public const byte VK_F10 = 0x79; // F10 key
    public const byte VK_F11 = 0x7A; // F11 key
    public const byte VK_F12 = 0x7B; // F12 key
    public const byte VK_F13 = 0x7C; // F13 key
    public const byte VK_F14 = 0x7D; // F14 key
    public const byte VK_F15 = 0x7E; // F15 key
    public const byte VK_F16 = 0x7F; // F16 key
    public const byte VK_F17 = 0x80; // F17 key
    public const byte VK_F18 = 0x81; // F18 key
    public const byte VK_F19 = 0x82; // F19 key
    public const byte VK_F20 = 0x83; // F20 key
    public const byte VK_F21 = 0x84; // F21 key
    public const byte VK_F22 = 0x85; // F22 key
    public const byte VK_F23 = 0x86; // F23 key
    public const byte VK_F24 = 0x87; // F24 key
    public const byte VK_NUMLOCK = 0x90; // NUM LOCK key
    public const byte VK_SCROLL = 0x91; // SCROLL LOCK key
    public const byte VK_LSHIFT = 0xA0; // Left SHIFT key
    public const byte VK_RSHIFT = 0xA1; // Right SHIFT key
    public const byte VK_LCONTROL = 0xA2; // Left CONTROL key
    public const byte VK_RCONTROL = 0xA3; // Right CONTROL key
    public const byte VK_LMENU = 0xA4; // Left MENU key
    public const byte VK_RMENU = 0xA5; // Right MENU key
    public const byte VK_BROWSER_BACK = 0xA6; // Browser Back key
    public const byte VK_BROWSER_FORWARD = 0xA7; // Browser Forward key
    public const byte VK_BROWSER_REFRESH = 0xA8; // Browser Refresh key
    public const byte VK_BROWSER_STOP = 0xA9; // Browser Stop key
    public const byte VK_BROWSER_SEARCH = 0xAA; // Browser Search key
    public const byte VK_BROWSER_FAVORITES = 0xAB; // Browser Favorites key
    public const byte VK_BROWSER_HOME = 0xAC; // Browser Start and Home key
    public const byte VK_VOLUME_MUTE = 0xAD; // Volume Mute key
    public const byte VK_VOLUME_DOWN = 0xAE; // Volume Down key
    public const byte VK_VOLUME_UP = 0xAF; // Volume Up key
    public const byte VK_MEDIA_NEXT_TRACK = 0xB0; // Next Track key
    public const byte VK_MEDIA_PREV_TRACK = 0xB1; // Previous Track key
    public const byte VK_MEDIA_STOP = 0xB2; // Stop Media key
    public const byte VK_MEDIA_PLAY_PAUSE = 0xB3; // Play/Pause Media key
    public const byte VK_LAUNCH_MAIL = 0xB4; // Launch Mail key
    public const byte VK_LAUNCH_MEDIA_SELECT = 0xB5; // Select Media key
    public const byte VK_LAUNCH_APP1 = 0xB6; // Launch Application 1 key
    public const byte VK_LAUNCH_APP2 = 0xB7; // Launch Application 2 key
    public const byte VK_OEM_1 = 0xBA; // Used for miscellaneous characters; it can vary by keyboard.
    public const byte VK_OEM_PLUS = 0xBB; // For any symbol in the US keyboard layout; it can vary by keyboard.
    public const byte VK_OEM_COMMA = 0xBC; // For any symbol in the US keyboard layout; it can vary by keyboard.
    public const byte VK_OEM_MINUS = 0xBD; // For any symbol in the US keyboard layout; it can vary by keyboard.
    public const byte VK_OEM_PERIOD = 0xBE; // For any symbol in the US keyboard layout; it can vary by keyboard.
    public const byte VK_OEM_2 = 0xBF; // Used for miscellaneous characters; it can vary by keyboard.
    public const byte VK_OEM_3 = 0xC0; // Used for miscellaneous characters; it can vary by keyboard.
    public const byte VK_ABNT_C1 = 0xC1; // / / ? key on Portuguese (Brazilian) keyboards
    public const byte VK_ABNT_C2 = 0xC2; // / ? key on Portuguese (Brazilian) keyboards
    public const byte VK_ATTN = 0xC3; // Attn key
    public const byte VK_CRSEL = 0xC4; // CrSel key
    public const byte VK_EXSEL = 0xC5; // ExSel key
    public const byte VK_EREOF = 0xC6; // Erase EOF key
    public const byte VK_PLAY = 0xC7; // Play key
    public const byte VK_ZOOM = 0xCB; // Zoom key
    public const byte VK_NONAME = 0xCC; // Reserved
    public const byte VK_PA1 = 0xFD; // PA1 key
    public const byte VK_OEM_CLEAR = 0xFE; // Clear key
}