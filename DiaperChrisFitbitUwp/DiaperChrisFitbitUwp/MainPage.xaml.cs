using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
using Windows.Graphics.Imaging;
using Windows.Media.Ocr;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Newtonsoft.Json;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DiaperChrisFitbitUwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private OcrEngine ocrEngine;

        public MainPage()
        {
            this.InitializeComponent();
            Language ocrLanguage = new Language("en");
            ocrEngine = OcrEngine.TryCreateFromLanguage(ocrLanguage);
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var fitbitRates = new List<FitbitRate>();
            var failCount = 0;
            StorageFolder pictureFolder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets\6-full");
            IReadOnlyList<StorageFile> fileList = await pictureFolder.GetFilesAsync();
            foreach (StorageFile file in fileList)
            {
                var filename = file.DisplayName;
                var splitfilename = filename.Split('-');
                // left 28, 11
                // right 1194, 2
                var writeableBitmap = await CropBitmap.GetCroppedBitmapAsync(file, new Point(1205, 3), new Size(30, 20), 2);
                var result = await ocrEngine.RecognizeAsync(SoftwareBitmap.CreateCopyFromBuffer(
                    writeableBitmap.PixelBuffer,
                    BitmapPixelFormat.Bgra8,
                    writeableBitmap.PixelWidth,
                    writeableBitmap.PixelHeight
                    ));
                try
                {
                    var starttime = Convert.ToInt32(splitfilename[1].Trim());
                    var wordInt = Convert.ToInt32(new String(result.Text.Where(Char.IsDigit).ToArray()));
                    fitbitRates.Add(new FitbitRate()
                    {
                        StartTime = starttime,
                        HeartRate = wordInt,
                        Time = TimeSpan.FromSeconds(starttime).TotalMinutes,
                        FileName = file.Name
                    });
                }
                catch (Exception ex)
                {
                    //TestImage.Source = writeableBitmap;
                    //break;
                    if (fitbitRates.Any())
                    {

                        var last = fitbitRates.Last();
                        fitbitRates.Add(new FitbitRate()
                        {
                            HeartRate = last.HeartRate,
                            StartTime = last.StartTime + 1,
                            Time = TimeSpan.FromSeconds(last.StartTime).TotalMinutes,
                            FileName = file.Name
                        });
                    }
                    else
                    {
                        fitbitRates.Add(new FitbitRate()
                        {
                            HeartRate = 80,
                            StartTime = 12,
                            Time = TimeSpan.FromSeconds(80).TotalMinutes,
                            FileName = file.Name
                        });
                    }

                    failCount = failCount + 1;
                }

            }
            var text = JsonConvert.SerializeObject(fitbitRates, Formatting.Indented);
            OutputBox.Text = text;
        }


        public class FitbitRate
        {
            public int HeartRate { get; set; }
            public double Time { get; set; }

            public int StartTime { get; set; }

            public string FileName { get; set; }
        }
    }
}
