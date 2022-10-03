using System;
using System.Runtime.InteropServices;

namespace NoMoreQueues.ProgramInput.Internal.PInvoke.Keyboard
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct KeyboardInput
    {
        public VirtualKey VirtualKey;

        public ScanCode ScanCode;

        public KeyboardInputEvent Flags;

        public uint Time;

        public UIntPtr ExtraInfo;
    }
}
