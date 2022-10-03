using NoMoreQueues.ProgramInput.Internal;
using NoMoreQueues.ProgramInput.Internal.PInvoke.Keyboard;

namespace NoMoreQueues.ProgramInput
{
    public abstract class Key
    {
        public static readonly Key LeftMouseButton = new MouseKey(MouseButton.Left);
        public static readonly Key RightMouseButton = new MouseKey(MouseButton.Right);
        public static readonly Key MiddleMouseButton = new MouseKey(MouseButton.Middle);
        public static readonly Key MouseButton4 = new MouseKey(MouseButton.Button4);
        public static readonly Key MouseButton5 = new MouseKey(MouseButton.Button5);

        public static readonly Key Backspace = new KeyboardKey(VirtualKey.Back, ScanCode.Back);
        public static readonly Key Tab = new KeyboardKey(VirtualKey.Tab, ScanCode.Tab);
        public static readonly Key Clear = new KeyboardKey(VirtualKey.Clear, ScanCode.Clear);
        public static readonly Key Enter = new KeyboardKey(VirtualKey.Return, ScanCode.Return);
        public static readonly Key Shift = new KeyboardKey(VirtualKey.Shift, ScanCode.Shift);
        public static readonly Key Ctrl = new KeyboardKey(VirtualKey.Control, ScanCode.Control);
        public static readonly Key Alt = new KeyboardKey(VirtualKey.Menu, ScanCode.Menu);
        public static readonly Key Pause = new KeyboardKey(VirtualKey.Pause, ScanCode.None);
        public static readonly Key CapsLock = new KeyboardKey(VirtualKey.CapsLock, ScanCode.CapsLock);
        public static readonly Key Escape = new KeyboardKey(VirtualKey.Escape, ScanCode.Escape);
        public static readonly Key Space = new KeyboardKey(VirtualKey.Space, ScanCode.Space);
        public static readonly Key PageUp = new KeyboardKey(VirtualKey.Prior, ScanCode.Prior);
        public static readonly Key PageDown = new KeyboardKey(VirtualKey.Next, ScanCode.Next);
        public static readonly Key End = new KeyboardKey(VirtualKey.End, ScanCode.End);
        public static readonly Key Home = new KeyboardKey(VirtualKey.Home, ScanCode.Home);
        public static readonly Key Left = new KeyboardKey(VirtualKey.Left, ScanCode.Left);
        public static readonly Key Up = new KeyboardKey(VirtualKey.Up, ScanCode.Up);
        public static readonly Key Right = new KeyboardKey(VirtualKey.Right, ScanCode.Right);
        public static readonly Key Down = new KeyboardKey(VirtualKey.Down, ScanCode.Down);
        public static readonly Key PrintScreen = new KeyboardKey(VirtualKey.Snapshot, ScanCode.Snapshot);
        public static readonly Key Insert = new KeyboardKey(VirtualKey.Insert, ScanCode.Insert);
        public static readonly Key Delete = new KeyboardKey(VirtualKey.Delete, ScanCode.Delete);

        public static readonly Key Number0 = new KeyboardKey(VirtualKey.Number0, ScanCode.Number0);
        public static readonly Key Number1 = new KeyboardKey(VirtualKey.Number1, ScanCode.Number1);
        public static readonly Key Number2 = new KeyboardKey(VirtualKey.Number2, ScanCode.Number2);
        public static readonly Key Number3 = new KeyboardKey(VirtualKey.Number3, ScanCode.Number3);
        public static readonly Key Number4 = new KeyboardKey(VirtualKey.Number4, ScanCode.Number4);
        public static readonly Key Number5 = new KeyboardKey(VirtualKey.Number5, ScanCode.Number5);
        public static readonly Key Number6 = new KeyboardKey(VirtualKey.Number6, ScanCode.Number6);
        public static readonly Key Number7 = new KeyboardKey(VirtualKey.Number7, ScanCode.Number7);
        public static readonly Key Number8 = new KeyboardKey(VirtualKey.Number8, ScanCode.Number8);
        public static readonly Key Number9 = new KeyboardKey(VirtualKey.Number9, ScanCode.Number9);

        public static readonly Key A = new KeyboardKey(VirtualKey.A, ScanCode.A);
        public static readonly Key B = new KeyboardKey(VirtualKey.B, ScanCode.B);
        public static readonly Key C = new KeyboardKey(VirtualKey.C, ScanCode.C);
        public static readonly Key D = new KeyboardKey(VirtualKey.D, ScanCode.D);
        public static readonly Key E = new KeyboardKey(VirtualKey.E, ScanCode.E);
        public static readonly Key F = new KeyboardKey(VirtualKey.F, ScanCode.F);
        public static readonly Key G = new KeyboardKey(VirtualKey.G, ScanCode.G);
        public static readonly Key H = new KeyboardKey(VirtualKey.H, ScanCode.H);
        public static readonly Key I = new KeyboardKey(VirtualKey.I, ScanCode.I);
        public static readonly Key J = new KeyboardKey(VirtualKey.J, ScanCode.J);
        public static readonly Key K = new KeyboardKey(VirtualKey.K, ScanCode.K);
        public static readonly Key L = new KeyboardKey(VirtualKey.L, ScanCode.L);
        public static readonly Key M = new KeyboardKey(VirtualKey.M, ScanCode.M);
        public static readonly Key N = new KeyboardKey(VirtualKey.N, ScanCode.N);
        public static readonly Key O = new KeyboardKey(VirtualKey.O, ScanCode.O);
        public static readonly Key P = new KeyboardKey(VirtualKey.P, ScanCode.P);
        public static readonly Key Q = new KeyboardKey(VirtualKey.Q, ScanCode.Q);
        public static readonly Key R = new KeyboardKey(VirtualKey.R, ScanCode.R);
        public static readonly Key S = new KeyboardKey(VirtualKey.S, ScanCode.S);
        public static readonly Key T = new KeyboardKey(VirtualKey.T, ScanCode.T);
        public static readonly Key U = new KeyboardKey(VirtualKey.U, ScanCode.U);
        public static readonly Key V = new KeyboardKey(VirtualKey.V, ScanCode.V);
        public static readonly Key W = new KeyboardKey(VirtualKey.W, ScanCode.W);
        public static readonly Key X = new KeyboardKey(VirtualKey.X, ScanCode.X);
        public static readonly Key Y = new KeyboardKey(VirtualKey.Y, ScanCode.Y);
        public static readonly Key Z = new KeyboardKey(VirtualKey.Z, ScanCode.Z);

        public static readonly Key LeftWindows = new KeyboardKey(VirtualKey.LeftWindows, ScanCode.LeftWindows);
        public static readonly Key RightWindows = new KeyboardKey(VirtualKey.RightWindows, ScanCode.RightWindows);
        public static readonly Key Sleep = new KeyboardKey(VirtualKey.Sleep, ScanCode.Sleep);

        public static readonly Key Numpad0 = new KeyboardKey(VirtualKey.Numpad0, ScanCode.Numpad0);
        public static readonly Key Numpad1 = new KeyboardKey(VirtualKey.Numpad1, ScanCode.Numpad1);
        public static readonly Key Numpad2 = new KeyboardKey(VirtualKey.Numpad2, ScanCode.Numpad2);
        public static readonly Key Numpad3 = new KeyboardKey(VirtualKey.Numpad3, ScanCode.Numpad3);
        public static readonly Key Numpad4 = new KeyboardKey(VirtualKey.Numpad4, ScanCode.Numpad4);
        public static readonly Key Numpad5 = new KeyboardKey(VirtualKey.Numpad5, ScanCode.Numpad5);
        public static readonly Key Numpad6 = new KeyboardKey(VirtualKey.Numpad6, ScanCode.Numpad6);
        public static readonly Key Numpad7 = new KeyboardKey(VirtualKey.Numpad7, ScanCode.Numpad7);
        public static readonly Key Numpad8 = new KeyboardKey(VirtualKey.Numpad8, ScanCode.Numpad8);
        public static readonly Key Numpad9 = new KeyboardKey(VirtualKey.Numpad9, ScanCode.Numpad9);
        public static readonly Key Multiply = new KeyboardKey(VirtualKey.Multiply, ScanCode.Multiply);
        public static readonly Key Add = new KeyboardKey(VirtualKey.Add, ScanCode.Add);
        public static readonly Key Subtract = new KeyboardKey(VirtualKey.Subtract, ScanCode.Subtract);
        public static readonly Key NumpadDot = new KeyboardKey(VirtualKey.Decimal, ScanCode.Decimal);
        public static readonly Key Divide = new KeyboardKey(VirtualKey.Divide, ScanCode.Divide);

        public static readonly Key F1 = new KeyboardKey(VirtualKey.F1, ScanCode.F1);
        public static readonly Key F2 = new KeyboardKey(VirtualKey.F2, ScanCode.F2);
        public static readonly Key F3 = new KeyboardKey(VirtualKey.F3, ScanCode.F3);
        public static readonly Key F4 = new KeyboardKey(VirtualKey.F4, ScanCode.F4);
        public static readonly Key F5 = new KeyboardKey(VirtualKey.F5, ScanCode.F5);
        public static readonly Key F6 = new KeyboardKey(VirtualKey.F6, ScanCode.F6);
        public static readonly Key F7 = new KeyboardKey(VirtualKey.F7, ScanCode.F7);
        public static readonly Key F8 = new KeyboardKey(VirtualKey.F8, ScanCode.F8);
        public static readonly Key F9 = new KeyboardKey(VirtualKey.F9, ScanCode.F9);
        public static readonly Key F10 = new KeyboardKey(VirtualKey.F10, ScanCode.F10);
        public static readonly Key F11 = new KeyboardKey(VirtualKey.F11, ScanCode.F11);
        public static readonly Key F12 = new KeyboardKey(VirtualKey.F12, ScanCode.F12);
        public static readonly Key F13 = new KeyboardKey(VirtualKey.F13, ScanCode.F13);
        public static readonly Key F14 = new KeyboardKey(VirtualKey.F14, ScanCode.F14);
        public static readonly Key F15 = new KeyboardKey(VirtualKey.F15, ScanCode.F15);
        public static readonly Key F16 = new KeyboardKey(VirtualKey.F16, ScanCode.F16);
        public static readonly Key F17 = new KeyboardKey(VirtualKey.F17, ScanCode.F17);
        public static readonly Key F18 = new KeyboardKey(VirtualKey.F18, ScanCode.F18);
        public static readonly Key F19 = new KeyboardKey(VirtualKey.F19, ScanCode.F19);
        public static readonly Key F20 = new KeyboardKey(VirtualKey.F20, ScanCode.F20);
        public static readonly Key F21 = new KeyboardKey(VirtualKey.F21, ScanCode.F21);
        public static readonly Key F22 = new KeyboardKey(VirtualKey.F22, ScanCode.F22);
        public static readonly Key F23 = new KeyboardKey(VirtualKey.F23, ScanCode.F23);
        public static readonly Key F24 = new KeyboardKey(VirtualKey.F24, ScanCode.F24);

        public static readonly Key NumLock = new KeyboardKey(VirtualKey.NumLock, ScanCode.NumLock);
        public static readonly Key LeftShift = new KeyboardKey(VirtualKey.LeftShift, ScanCode.LeftShift);
        public static readonly Key RightShift = new KeyboardKey(VirtualKey.RightShift, ScanCode.RightShift);
        public static readonly Key LeftCtrl = new KeyboardKey(VirtualKey.LeftControl, ScanCode.LeftControl);
        public static readonly Key RightCtrl = new KeyboardKey(VirtualKey.RightControl, ScanCode.RightControl);
        public static readonly Key LeftAlt = new KeyboardKey(VirtualKey.LeftMenu, ScanCode.LeftMenu);
        public static readonly Key RightAlt = new KeyboardKey(VirtualKey.RightMenu, ScanCode.RightMenu);

        public static readonly Key Semicolon = new KeyboardKey(VirtualKey.Oem1, ScanCode.Oem1);
        public static readonly Key Plus = new KeyboardKey(VirtualKey.OemPlus, ScanCode.OemPlus);
        public static readonly Key Comma = new KeyboardKey(VirtualKey.OemComma, ScanCode.OemComma);
        public static readonly Key Minus = new KeyboardKey(VirtualKey.OemMinus, ScanCode.OemMinus);
        public static readonly Key Period = new KeyboardKey(VirtualKey.OemPeriod, ScanCode.OemPeriod);
        public static readonly Key Tilde = new KeyboardKey(VirtualKey.Oem3, ScanCode.Oem3);
        public static readonly Key OpenBrackets = new KeyboardKey(VirtualKey.Oem4, ScanCode.Oem4);
        public static readonly Key Pipe = new KeyboardKey(VirtualKey.Oem5, ScanCode.Oem5);
        public static readonly Key CloseBrackets = new KeyboardKey(VirtualKey.Oem6, ScanCode.Oem6);
        public static readonly Key Quotes = new KeyboardKey(VirtualKey.Oem7, ScanCode.Oem7);
        public static readonly Key Backslash = new KeyboardKey(VirtualKey.Oem102, ScanCode.Oem102);

        public static Key FromVirtualAndScanCode(ushort virtualCode, ushort scanCode)
        {
            return new KeyboardKey((VirtualKey)virtualCode, (ScanCode)scanCode);
        }

        public static Key FromVirtualCode(ushort virtualCode)
        {
            return new KeyboardKey((VirtualKey)virtualCode, ScanCode.None);
        }

        public static Key FromScanCode(ushort scanCode)
        {
            return new KeyboardKey(VirtualKey.None, (ScanCode)scanCode);
        }

        internal abstract Internal.PInvoke.Input GetInput(bool isPressed);
    }
}
