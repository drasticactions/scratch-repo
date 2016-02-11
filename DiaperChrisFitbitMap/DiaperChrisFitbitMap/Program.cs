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
            using (var videoFrameReader = new VideoFrameReader(@"1.mp4"))
            {
                var startTime = 97;
                videoFrameReader.Seek(startTime);
                var frameIndex = 0;
                var fitbitRates = new List<FitbitRate>();
                foreach (var frame in videoFrameReader)
                {
                    using (frame)
                    {
                        if (frameIndex % 60 == 0) //Save every 60th frame
                        {
                            Console.WriteLine($"Getting image at {TimeSpan.FromSeconds(startTime).TotalMinutes}");
                            var image = CropImage(frame, new Rectangle(30, 10, 30, 20));
                            //var ocrImage = new ImageReader(ImageToStream(image, ImageFormat.Jpeg));
                            //Console.WriteLine("Wait a sec...");
                            //await Task.Delay(5000);
                            //var result = await ocrImage.GetImageAnalysisResultsAsync();
                            //if (result != null && result.Regions.Any())
                            //{
                            //    if (result.Regions.First().Lines.Any())
                            //    {
                            //        if (result.Regions.First().Lines.First().Words.Any())
                            //        {
                            //            var word = result.Regions.First().Lines.First().Words.First();
                            //            try
                            //            {
                            //                var wordInt = Convert.ToInt32(word.Text);
                            //                fitbitRates.Add(new FitbitRate()
                            //                {
                            //                    HeartRate = wordInt,
                            //                    Time = TimeSpan.FromSeconds(startTime).TotalMinutes
                            //                });
                            //            }
                            //            catch (Exception)
                            //            {
                            //                // If we failed to parse, add in the last file.
                            //                if (fitbitRates.Any())
                            //                {
                            //                    fitbitRates.Add(fitbitRates.Last());
                            //                }
                            //                Console.WriteLine($"Fail at {startTime}");
                            //            }
                            //        }
                            //    }
                            //}
                            
                            // Save debug image
                            //image.Save(string.Format(@"1/Frame{0} - {1}.jpg", frameIndex, TimeSpan.FromSeconds(startTime).TotalMinutes));
                            //image.Dispose();
                            // Save full image
                            frame.Save($@"1-full/Frame{frameIndex} - {startTime} - {TimeSpan.FromSeconds(startTime).TotalMinutes}.jpg", ImageFormat.Jpeg);
                            startTime++;
                        }
                        frameIndex++;
                    }
                }

                File.WriteAllText("output-1.txt", JsonConvert.SerializeObject(fitbitRates));
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
