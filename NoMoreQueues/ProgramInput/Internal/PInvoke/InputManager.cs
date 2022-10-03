using System.ComponentModel;
using System.Runtime.InteropServices;

namespace NoMoreQueues.ProgramInput.Internal.PInvoke
{
    internal static class InputManager
    {
        public static void SendInput(Input[] inputs)
        {
            var inserted = SendInput((uint)inputs.Length, inputs, Input.Size);
            if (inserted != inputs.Length)
            {
                throw new Win32Exception();
            }
        }

        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(SystemMetric smIndex);

        [DllImport("user32.dll")]
        private static extern uint SendInput(uint inputsCount, [MarshalAs(UnmanagedType.LPArray), In] Input[] inputs, int inputStructSize);
    }
}
