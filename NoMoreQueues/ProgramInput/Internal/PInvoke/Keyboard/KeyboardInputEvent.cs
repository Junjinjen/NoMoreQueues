using System;

namespace NoMoreQueues.ProgramInput.Internal.PInvoke.Keyboard
{
    [Flags]
    internal enum KeyboardInputEvent : uint
    {
        None = 0x00,
        ExtendedKey = 0x0001,
        KeyUp = 0x0002,
        Scancode = 0x0008,
        Unicode = 0x0004,
    }
}
