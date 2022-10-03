using NoMoreQueues.ProgramInput.Internal.PInvoke;
using NoMoreQueues.ProgramInput.Internal.PInvoke.Keyboard;

namespace NoMoreQueues.ProgramInput.Internal
{
    internal class KeyboardKey : Key
    {
        private readonly VirtualKey _virtualKey;
        private readonly ScanCode _scanCode;

        public KeyboardKey(VirtualKey virtualKey, ScanCode scanCode)
        {
            _virtualKey = virtualKey;
            _scanCode = scanCode;
        }

        internal override PInvoke.Input GetInput(bool isPressed)
        {
            return new PInvoke.Input
            {
                Type = InputType.Keyboard,
                Union = new InputUnion
                {
                    KeyboardInput = new KeyboardInput
                    {
                        VirtualKey = _virtualKey,
                        ScanCode = _scanCode,
                        Flags = GetFlags(isPressed),
                    },
                },
            };
        }

        private KeyboardInputEvent GetFlags(bool isPressed)
        {
            if (_scanCode == ScanCode.None)
            {
                return isPressed
                    ? KeyboardInputEvent.None
                    : KeyboardInputEvent.KeyUp;
            }

            return isPressed
                ? KeyboardInputEvent.Scancode
                : KeyboardInputEvent.Scancode | KeyboardInputEvent.KeyUp;
        }
    }
}
