using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GleamTech.VideoUltimate;
using Newtonsoft.Json;
using ImageFormat = System.Drawing.Imaging.ImageFormat;

namespace DiaperChrisFitbitMap
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            int movienumber = 12;
            using (var videoFrameReader = new VideoFrameReader($@"{movienumber}.mp4"))
            {
                var startTime = 10;
                videoFrameReader.Seek(startTime);
                var frameIndex = 0;
                foreach (var frame in videoFrameReader)
                {
                    using (frame)
                    {
                        if (frameIndex % 60 == 0) //Save every 60th frame
                        {
                            Console.WriteLine($"Getting image at {TimeSpan.FromSeconds(startTime).TotalMinutes}");
                            frame.Save($@"{movienumber}-full/Frame{frameIndex} - {startTime} - {TimeSpan.FromSeconds(startTime).TotalMinutes}.jpg", ImageFormat.Jpeg);
                            startTime++;
                        }
                        frameIndex++;
                    }
                }
            }
        }

        public class FitbitRate
        {
            public int HeartRate { get; set; }
            public double Time { get; set; }
        }

        private static Image CropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            bmpImage = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
            return new Bitmap(bmpImage, new Size(90, 60));
        }

        public static Stream ImageToStream(Image image, ImageFormat formaw)
        {
            var stream = new MemoryStream();
            image.Save(stream, formaw);
            stream.Position = 0;
            return stream;
        }
    }
}
