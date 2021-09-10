using GraphicTest;
using nanoFramework.Presentation.Media;
using nanoFramework.UI;
using System;
using System.Threading;

namespace Primitives.SimplePrimitives
{
    public class RandomDrawLine
    {
        public RandomDrawLine(Bitmap fullScreenBitmap, Font DisplayFont)
        {
            Random random = new Random();
            fullScreenBitmap.Clear();
            fullScreenBitmap.Flush();
            fullScreenBitmap.DrawText("Random Line Drawing", DisplayFont, Color.AliceBlue, 0, 0);

            for (int i = 100; i > 0; i--)
            {
                int thickness = random.Next(8);
                fullScreenBitmap.DrawLine((Color)random.Next(0xFFFFFF),
                                           thickness,
                                           random.Next(fullScreenBitmap.Width),
                                           random.Next(fullScreenBitmap.Height - 22),
                                           random.Next(fullScreenBitmap.Width),
                                           random.Next(fullScreenBitmap.Height));
                InformationBar.DrawInformationBar(fullScreenBitmap, DisplayFont, InfoBarPosition.bottom, $"Line Number {i}");
                fullScreenBitmap.Flush();
            }
        }
    }
    public enum InfoBarPosition
    {
        Top,
        bottom
    }
    public static class InformationBar
    {
        public static void DrawInformationBar(Bitmap theBitmap, Font DisplayFont, InfoBarPosition pos, string TextToDisplay)
        {
            theBitmap.DrawRectangle(Color.White, 0, 0, theBitmap.Height - 20, 320, 22, 0, 0, Color.White,
                0, theBitmap.Height - 20, Color.White, 0, theBitmap.Height, Bitmap.OpacityOpaque);
            theBitmap.DrawText(TextToDisplay, DisplayFont, Color.Black, 0, theBitmap.Height - 20);
        }

    }

    class PagedText
    {

        public PagedText(Bitmap fullScreenBitmap, Font DisplayFont)

        {
            //Bitmap bmp = new Bitmap(fullScreenBitmap.Width, fullScreenBitmap.Height);

            string text = "There is another overload of the DrawTextInRect " +
                      "method. That method comes along with reference " +
                      "parameters for the input string and the x and y " +
                      "drawing positions. After drawing text, the " +
                      "method updates the x and y positions to tell you " +
                      "where on the display the drawing of the text " +
                      "finished. This allows you to draw parts of the text " +
                      "with a different color or font. Also, if the method " +
                      "cannot display the complete text within the specified " +
                      "rectangle, it returns the remaining text. " +
                      "In this case, the method returns false to indicate " +
                      "that there is some text left that could not " +
                      "displayed. This enables you to build up a display " +
                      "to show text over mulitple pages.";
            bool completed;
            do
            {
                int x = 0;
                int y = 0;
                //draw frame around text and clear old contents
                fullScreenBitmap.DrawRectangle(Color.White, 1, 20, 20, 150, 150, 0, 0, Color.Black, 0, 0, Color.Black, 0, 0, Bitmap.OpacityOpaque);
                completed = fullScreenBitmap.DrawTextInRect(
                                     ref text,
                                     ref x, ref y, // x and y text position
                                     20, 20,       // x and y (rectangle top left)
                                     150, 150,     // width and height of rectangle
                                     Bitmap.DT_AlignmentLeft | Bitmap.DT_WordWrap,
                                     Color.White,  // color
                                     DisplayFont);        // font
                fullScreenBitmap.Flush();
                Thread.Sleep(3000); //display each page for three seconds
            } while (!completed);
        }
    }
}
