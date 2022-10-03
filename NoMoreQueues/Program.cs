using NoMoreQueues.ProgramInput;
using NoMoreQueues.Window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace NoMoreQueues
{
    public static class Program
    {
        private const string WowProcessName = "WowClassic";
        private const int LoopDelay = 5000;
        private const int PressDelay = 300;
        private const int MovementDelay = 180000;
        private const int MovementChangePercent = 10;

        private static readonly Random Random = new();
        private static readonly Size PrimaryDisplaySize = WindowManager.GetPrimaryDisplaySize();
        private static readonly List<Key> MovementKeys = new()
        {
            Key.W,
            Key.A,
            Key.S,
            Key.D,
        };

        private static readonly List<Bitmap> ClickableButtons = new()
        {
            LoadImage("EnterWorld.png"),
        };

        public static void Main(string[] args)
        {
            var process = GetWowProcess();
            if (process == null)
            {
                Console.WriteLine("Wow process not found");
                return;
            }

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var nextDelay = GetRandomChangedValue(MovementDelay, MovementChangePercent, Random);

            while (process.IsRunning())
            {
                WindowManager.ActivateWindow(process);
                ClickButtons(process);

                if (stopwatch.ElapsedMilliseconds >= nextDelay && process.IsRunning())
                {
                    nextDelay = GetRandomChangedValue(MovementDelay, MovementChangePercent, Random);
                    Input.SendKeysPress(PressDelay, MovementKeys.PickRandom(Random));
                    stopwatch.Restart();
                }

                Thread.Sleep(LoopDelay);
            }

            Console.WriteLine("Wow process finished");
        }

        private static void ClickButtons(Process process)
        {
            var game = WindowManager.GetWindowScreenshot(process);
            var clickPositions = ClickableButtons.Select(x => game.ContainsImage(x)).Where(x => x.HasValue).Select(x => x.Value.Center()).ToList();
            foreach (var position in clickPositions)
            {
                Input.SetCursorPosition(position);
                Thread.Sleep(PressDelay);
                Input.SendKeysPress(PressDelay, Key.LeftMouseButton);
                Thread.Sleep(PressDelay);
            }
        }

        private static Process GetWowProcess()
        {
            return Process.GetProcessesByName(WowProcessName).FirstOrDefault();
        }

        private static Bitmap LoadImage(string filename)
        {
            var path = @$"Images/{PrimaryDisplaySize.Width}x{PrimaryDisplaySize.Height}/{filename}";
            return (Bitmap)Image.FromFile(path);
        }

        private static int GetRandomChangedValue(int value, int percent, Random random)
        {
            if (percent == 0)
            {
                return value;
            }

            var changePercent = random.Next(-percent, percent + 1);

            return (int)(value + value / 100.0 * changePercent);
        }
    }
}