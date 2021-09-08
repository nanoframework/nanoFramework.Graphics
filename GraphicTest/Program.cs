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

            Configuration.SetPinFunction(19, DeviceFunction.SPI1_MISO);
            Configuration.SetPinFunction(23, DeviceFunction.SPI1_MOSI);
            Configuration.SetPinFunction(18, DeviceFunction.SPI1_CLOCK);
            Configuration.SetPinFunction(32, DeviceFunction.PWM1);

            //var pwmController = PwmController.FromId("TIM1");
            //pwmController.SetDesiredFrequency(5000);
            //var pwmPin = pwmController.OpenPin(32);
            //pwmPin.SetActiveDutyCyclePercentage(0.1);
            //pwmPin.Start();
            GpioController controller = new();
            GpioPin blPin = controller.OpenPin(32, PinMode.Output);
            blPin.Write(PinValue.High);

            Debug.WriteLine("Hello from nanoFramework!");

            DisplayControl.Initialize(new SpiConfiguration() { ChipSelect = 14, SpiBus = 1, DataCommand = 27, Reset = 33, BackLight = 32 }, 320, 240, 1024);

            Debug.WriteLine("Screen initialized");

            int delayBetween = 1100;

            // Get full screen bitmap from displayControl to draw on.
            Bitmap fullScreenBitmap = new Bitmap(100, 100);

            fullScreenBitmap.Clear();

            Font DisplayFont = Resource.GetFont(Resource.FontResources.segoeuiregular12);

            while (true)
            {
                RandomDrawLine rdlt = new RandomDrawLine(fullScreenBitmap, DisplayFont);
                Thread.Sleep(delayBetween);

                PagedText pt = new PagedText(fullScreenBitmap, DisplayFont);
                Thread.Sleep(delayBetween);
            }


            Thread.Sleep(Timeout.Infinite);
            
            
        }
    }
}
