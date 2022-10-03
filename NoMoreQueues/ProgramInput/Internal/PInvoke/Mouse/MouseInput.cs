using System;
using System.Runtime.InteropServices;

namespace NoMoreQueues.ProgramInput.Internal.PInvoke.Mouse
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct MouseInput
    {
        public int X;

        public int Y;

        public int MouseData;

        public MouseInputEvent Flags;

        public uint Time;

        public UIntPtr ExtraInfo;
    }
}
