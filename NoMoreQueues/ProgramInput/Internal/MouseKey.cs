using NoMoreQueues.ProgramInput.Internal.PInvoke;
using NoMoreQueues.ProgramInput.Internal.PInvoke.Mouse;
using System;

namespace NoMoreQueues.ProgramInput.Internal
{
    internal class MouseKey : Key
    {
        private readonly MouseButton _mouseButton;

        public MouseKey(MouseButton mouseButton)
        {
            _mouseButton = mouseButton;
        }

        internal override PInvoke.Input GetInput(bool isPressed)
        {
            return new PInvoke.Input
            {
                Type = InputType.Mouse,
                Union = new InputUnion
                {
                    MouseInput = new MouseInput
                    {
                        Flags = GetFlags(isPressed),
                        MouseData = GetMouseData(),
                    },
                },
            };
        }

        private MouseInputEvent GetFlags(bool isPressed)
        {
            return isPressed
                ? GetDownFlags()
                : GetUpFlags();
        }

        private MouseInputEvent GetDownFlags()
        {
            return _mouseButton switch
            {
                MouseButton.Left => MouseInputEvent.LeftDown,
                MouseButton.Right => MouseInputEvent.RightDown,
                MouseButton.Middle => MouseInputEvent.MiddleDown,
                MouseButton.Button4 or MouseButton.Button5 => MouseInputEvent.XDown,
                _ => throw new InvalidOperationException("Invalid MouseButton value"),
            };
        }

        private MouseInputEvent GetUpFlags()
        {
            return _mouseButton switch
            {
                MouseButton.Left => MouseInputEvent.LeftUp,
                MouseButton.Right => MouseInputEvent.RightUp,
                MouseButton.Middle => MouseInputEvent.MiddleUp,
                MouseButton.Button4 or MouseButton.Button5 => MouseInputEvent.XUp,
                _ => throw new InvalidOperationException("Invalid MouseButton value"),
            };
        }

        private int GetMouseData()
        {
            return _mouseButton switch
            {
                MouseButton.Button4 => MouseConstants.XButton1,
                MouseButton.Button5 => MouseConstants.XButton2,
                _ => 0,
            };
        }
    }
}
