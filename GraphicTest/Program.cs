using nanoFramework.Hardware.Esp32;
using nanoFramework.Presentation.Media;
using nanoFramework.UI;
using Primitives.SimplePrimitives;
using System;
using System.Device.Gpio;
using System.Diagnostics;
using System.Threading;
using Windows.Devices.Pwm;

namespace GraphicTest
{
    public class Program
    {
        public static void Main()
        {
            Thread.Sleep(2000);
            int chipSelect;
            int dataCommand;
            int reset;
            int backLightPin;

            const bool wroover = true;
            if (wroover)
            {
                backLightPin = 5;
                chipSelect = 22;
                dataCommand = 21;
                reset = 18;
            }
            else
            {
                backLightPin = 32;
                chipSelect = 14;
                dataCommand = 27;
                reset = 33;
                Configuration.SetPinFunction(19, DeviceFunction.SPI1_MISO);
                Configuration.SetPinFunction(23, DeviceFunction.SPI1_MOSI);
                Configuration.SetPinFunction(18, DeviceFunction.SPI1_CLOCK);
            }

            Configuration.SetPinFunction(backLightPin, DeviceFunction.PWM1);


            //GpioController controller = new();
            //GpioPin blPin = controller.OpenPin(BackLightPin, PinMode.Output);
            //blPin.Write(PinValue.High);

            Debug.WriteLine("Hello from nanoFramework!");

            //DisplayControl.Initialize(new SpiConfiguration(1, chipSelect, dataCommand, reset, backLightPin), 10, 10, 300, 220, 1024);
            DisplayControl.Initialize(new SpiConfiguration(1, chipSelect, dataCommand, reset, backLightPin), 0, 0, 320, 240, 1024);
            Debug.WriteLine($"BitsPerPixel {DisplayControl.BitsPerPixel}");
            Debug.WriteLine($"LongerSide {DisplayControl.LongerSide}");
            Debug.WriteLine($"Orientation {DisplayControl.Orientation}");
            Debug.WriteLine($"ScreenHeight {DisplayControl.ScreenHeight}");
            Debug.WriteLine($"ScreenWidth {DisplayControl.ScreenWidth}");
            Debug.WriteLine($"ShorterSide {DisplayControl.ShorterSide}");


            Debug.WriteLine("Screen initialized");
            var desc = PwmController.GetDeviceSelector();
            Debug.WriteLine(desc);
            PwmController pwm = PwmController.GetDefault();
            pwm.SetDesiredFrequency(44100);
            PwmPin pwmPin = pwm.OpenPin(backLightPin);
            pwmPin.SetActiveDutyCyclePercentage(0.1);
            pwmPin.Start();

            int delayBetween = 1100;


            //Bitmap theBitmap = new Bitmap(10, 10);
            ////theBitmap.DrawLine(Color.Blue, 3, 0, 0, 9, 9);
            //theBitmap.DrawRectangle(Color.Blue, 1, 0, 0, 10, 10, 0, 0, Color.Red, 0, 100, Color.Yellow, 50, 0, 0xFF);
            //for (int i = 0; i < 32; i++)
            //{
            //    for (int j = 0; j < 24; j++)
            //    {
            //        theBitmap.Flush(i * 10, j * 10, theBitmap.Width, theBitmap.Height);
            //    }
            //}

            Thread.Sleep(delayBetween);

            //var fullScreenBitmap = DisplayControl.FullScreen;
            var fullScreenBitmap = new Bitmap(100, 100);
            //fullScreenBitmap.Clear();

            Font DisplayFont = Resource.GetFont(Resource.FontResources.segoeuiregular12);

            while (true)
            {
                RandomDrawLine rdlt = new RandomDrawLine(fullScreenBitmap, DisplayFont);
                Thread.Sleep(delayBetween);

                fullScreenBitmap.Clear();

                PagedText pt = new PagedText(fullScreenBitmap, DisplayFont);
                Thread.Sleep(delayBetween);
            }


            Thread.Sleep(Timeout.Infinite);


        }
    }
}
