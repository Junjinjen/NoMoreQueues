using System.Runtime.InteropServices;

namespace NoMoreQueues.ProgramInput.Internal.PInvoke
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct Input
    {
        public static readonly int Size = Marshal.SizeOf<Input>();

        public InputType Type;

        public InputUnion Union;
    }
}
