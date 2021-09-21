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

            const bool wroover = false;
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
            DisplayControl.Initialize(new SpiConfiguration(1, chipSelect, dataCommand, reset, backLightPin), new ScreenConfiguration(0, 0, 320, 240), 30 * 1024);
            Debug.WriteLine($"MaximumBufferSize {DisplayControl.MaximumBufferSize}");
            Debug.WriteLine($"BitsPerPixel {DisplayControl.BitsPerPixel}");
            Debug.WriteLine($"LongerSide {DisplayControl.LongerSide}");
            Debug.WriteLine($"Orientation {DisplayControl.Orientation}");
            Debug.WriteLine($"ScreenHeight {DisplayControl.ScreenHeight}");
            Debug.WriteLine($"ScreenWidth {DisplayControl.ScreenWidth}");
            Debug.WriteLine($"ShorterSide {DisplayControl.ShorterSide}");


            Debug.WriteLine("Screen initialized");
            PwmController pwm = PwmController.GetDefault();
            pwm.SetDesiredFrequency(44100);
            PwmPin pwmPin = pwm.OpenPin(backLightPin);
            pwmPin.SetActiveDutyCyclePercentage(0.1);
            pwmPin.Start();

            int delayBetween = 5000;

            int width = 80;
            int height = 60;
            //byte[] img = new byte[20 * 240 * 2];
            //Bitmap theBitmap = new Bitmap(img, Bitmap.BitmapImageType.NanoCLRBitmap);
            Bitmap theBitmap = new Bitmap(width, height);
            ushort[] toSend = new ushort[100];
            Font DisplayFont = Resource.GetFont(Resource.FontResources.segoeuiregular12);
            Debug.WriteLine($"Font height: {DisplayFont.Height}, width: {DisplayFont.MaxWidth} external leading: {DisplayFont.ExternalLeading}, internal: {DisplayFont.InternalLeading}, descent: {DisplayFont.Descent}, ascent: {DisplayFont.Ascent}");
            Bitmap charBitmap = new Bitmap(DisplayFont.MaxWidth + 1, DisplayFont.Height);
        start:

            var blue = ColorUtility.To16Bpp(Color.Blue);
            var red = ColorUtility.To16Bpp(Color.Red);
            var green = ColorUtility.To16Bpp(Color.Green);

            for (int i = 0; i < toSend.Length; i++)
            {
                toSend[i] = blue;
            }

            DisplayControl.Write(100, 100, 10, 10, toSend);
            for (int i = 0; i < toSend.Length; i++)
            {
                toSend[i] = red;
            }

            DisplayControl.Write(120, 120, 10, 10, toSend);
            for (int i = 0; i < toSend.Length; i++)
            {
                toSend[i] = green;
            }

            DisplayControl.Write(140, 140, 10, 10, toSend);

            Random random = new Random();
            ushort[] point = new ushort[1];
            ushort x;
            ushort y;
            for (int i = 0; i < 3000; i++)
            {
                point[0] = ColorUtility.To16Bpp((Color)random.Next(0xFFFFFF));
                x = (ushort)random.Next(319);
                y = (ushort)random.Next(239);
                DisplayControl.Write(x, y, 1, 1, point);
            }

            Thread.Sleep(delayBetween);

            //theBitmap.DrawLine(Color.Blue, 3, 0, 0, 9, 9);
            theBitmap.DrawRectangle(Color.Blue, 1, 0, 0, width, height, 0, 0, Color.Red, 0, 100, Color.Yellow, 50, 0, 0xFF);
            for (int i = 0; i < 320 / width; i++)
            {
                for (int j = 0; j < 240 / height; j++)
                {
                    theBitmap.Flush(i * width, j * height, theBitmap.Width, theBitmap.Height);
                }
            }

            Thread.Sleep(delayBetween);

            //var fullScreenBitmap = DisplayControl.FullScreen;
            //var theBitmap = new Bitmap(80, 100);
            theBitmap.Clear();

            //while (true)
            {
                RandomDrawLine rdlt = new RandomDrawLine(theBitmap, DisplayFont);
                Thread.Sleep(delayBetween);

                theBitmap.Clear();

                PagedText pt = new PagedText(theBitmap, DisplayFont);
                Thread.Sleep(delayBetween);
            }

            DisplayControl.Clear();

            theBitmap.Clear();
            theBitmap.DrawText("Some text", DisplayFont, Color.White, 0, 0);
            theBitmap.Flush();

            Thread.Sleep(delayBetween);
            DisplayControl.Clear();

            DisplayText(charBitmap, DisplayFont, 0, 0, "This is with unitary buffer, needs improvement", true);

            Thread.Sleep(delayBetween);

            goto start;

            Thread.Sleep(Timeout.Infinite);
        }

        public static void DisplayText(Bitmap charBitmap, Font font, ushort x, ushort y, string text, bool newLine)
        {
            int posX = x;
            int charWidth;
            for (int i = 0; i < text.Length; i++)
            {
                charBitmap.Clear();
                charBitmap.DrawText(text.Substring(i, 1), font, Color.White, 0, 0);
                charWidth = font.CharWidth(text[i]);
                posX += charWidth;
                charBitmap.Flush(posX, y, charBitmap.Width, charBitmap.Height);
            }
        }
    }
}
