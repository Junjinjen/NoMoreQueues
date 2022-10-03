using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace NoMoreQueues
{
    internal static class Extensions
    {
        public unsafe static Rectangle? ContainsImage(this Bitmap sourceBitmap, Bitmap searchBitmap, double tolerance = 0.1f)
        {
            var sourceData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            var searchData = searchBitmap.LockBits(new Rectangle(0, 0, searchBitmap.Width, searchBitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            var sourceStride = sourceData.Stride;
            var searchStride = searchData.Stride;

            var sourceWidth = sourceBitmap.Width;
            var sourceHeight = sourceBitmap.Height - searchBitmap.Height + 1;
            var searchWidth = searchBitmap.Width * 3;
            var searchHeight = searchBitmap.Height;

            var location = Rectangle.Empty;
            var margin = Convert.ToInt32(byte.MaxValue * tolerance);

            var searchScanPointer = (byte*)searchData.Scan0.ToPointer();
            var sourceScanPointer = (byte*)sourceData.Scan0.ToPointer();

            var bigOffset = sourceStride - sourceBitmap.Width * 3;

            var matchFound = true;

            for (int y = 0; y < sourceHeight; y++)
            {
                for (int x = 0; x < sourceWidth; x++)
                {
                    var sourceBackup = sourceScanPointer;
                    var searchBackup = searchScanPointer;

                    for (int i = 0; i < searchHeight; i++)
                    {
                        var j = 0;
                        matchFound = true;
                        for (j = 0; j < searchWidth; j++)
                        {
                            var inf = sourceScanPointer[0] - margin;
                            var sup = sourceScanPointer[0] + margin;
                            if (sup < searchScanPointer[0] || inf > searchScanPointer[0])
                            {
                                matchFound = false;
                                break;
                            }

                            sourceScanPointer++;
                            searchScanPointer++;
                        }

                        if (!matchFound)
                        {
                            break;
                        }

                        searchScanPointer = searchBackup;
                        sourceScanPointer = sourceBackup;

                        searchScanPointer += searchStride * (1 + i);
                        sourceScanPointer += sourceStride * (1 + i);
                    }

                    if (matchFound)
                    {
                        location.X = x;
                        location.Y = y;
                        location.Width = searchBitmap.Width;
                        location.Height = searchBitmap.Height;
                        break;
                    }
                    else
                    {
                        sourceScanPointer = sourceBackup;
                        searchScanPointer = searchBackup;
                        sourceScanPointer += 3;
                    }
                }

                if (matchFound)
                {
                    break;
                }

                sourceScanPointer += bigOffset;
            }

            sourceBitmap.UnlockBits(sourceData);
            searchBitmap.UnlockBits(searchData);

            return matchFound ? location : null;
        }

        public static Point Center(this Rectangle rect)
        {
            return new Point(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
        }

        public static bool IsRunning(this Process process)
        {
            process.Refresh();
            return !process.HasExited;
        }

        public static T PickRandom<T>(this IList<T> source, Random random)
        {
            int randIndex = random.Next(source.Count);
            return source[randIndex];
        }
    }
}
