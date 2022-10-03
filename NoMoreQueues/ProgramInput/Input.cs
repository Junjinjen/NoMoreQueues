using NoMoreQueues.ProgramInput.Internal.PInvoke;
using NoMoreQueues.ProgramInput.Internal.PInvoke.Mouse;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace NoMoreQueues.ProgramInput
{
    public static class Input
    {
        private static readonly int PrimaryDisplayWidth = InputManager.GetSystemMetrics(SystemMetric.PrimaryDisplayWidth);
        private static readonly int PrimaryDisplayHeight = InputManager.GetSystemMetrics(SystemMetric.PrimaryDisplayHeight);

        public static void SendKeysDown(params Key[] keys)
        {
            if (!HasAnyKeys(keys))
            {
                return;
            }

            SendKeysInput(keys, true);
        }

        public static void SendKeysUp(params Key[] keys)
        {
            if (!HasAnyKeys(keys))
            {
                return;
            }

            SendKeysInput(keys, false);
        }

        public static void SendKeysPress(int millisecondsPressDelay, params Key[] keys)
        {
            if (millisecondsPressDelay < 0)
            {
                throw new ArgumentException("Press delay mustn't be less than zero", nameof(millisecondsPressDelay));
            }

            if (!HasAnyKeys(keys))
            {
                return;
            }

            if (millisecondsPressDelay > 0)
            {
                SendKeysInput(keys, true);
                Thread.Sleep(millisecondsPressDelay);
                SendKeysInput(keys, false);
                return;
            }

            var inputs = keys.Select(x => x.GetInput(true))
                .Concat(keys.Select(x => x.GetInput(false)))
                .ToArray();

            InputManager.SendInput(inputs);
        }

        public static void SendScroll(int movement)
        {
            if (movement == 0)
            {
                return;
            }

            var input = new Internal.PInvoke.Input
            {
                Type = InputType.Mouse,
                Union = new InputUnion
                {
                    MouseInput = new MouseInput
                    {
                        Flags = MouseInputEvent.Wheel,
                        MouseData = movement * MouseConstants.WheelDelta,
                    },
                },
            };

            InputManager.SendInput(new[] { input });
        }

        public static void SetCursorPosition(Point point)
        {
            var input = new Internal.PInvoke.Input
            {
                Type = InputType.Mouse,
                Union = new InputUnion
                {
                    MouseInput = new MouseInput
                    {
                        X = point.X * ushort.MaxValue / PrimaryDisplayWidth,
                        Y = point.Y * ushort.MaxValue / PrimaryDisplayHeight,
                        Flags = MouseInputEvent.Move | MouseInputEvent.Absolute,
                    },
                },
            };

            InputManager.SendInput(new[] { input });
        }

        private static bool HasAnyKeys(Key[] keys)
        {
            return keys?.Any() == true;
        }

        private static void SendKeysInput(Key[] keys, bool isPressed)
        {
            var inputs = keys.Select(x => x.GetInput(isPressed)).ToArray();
            InputManager.SendInput(inputs);
        }
    }
}
