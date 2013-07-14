using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MonoTouch.UIKit;

namespace ExcelLibrary.BinaryFileFormat
{
    public class ColorPalette
    {
        public Dictionary<int, UIColor> Palette = new Dictionary<int, UIColor>();

        public ColorPalette()
        {
			Palette.Add(0, UIColor.Black);
			Palette.Add(1, UIColor.White);
			Palette.Add(2, UIColor.Red);
			Palette.Add(3, UIColor.Green);
			Palette.Add(4, UIColor.Blue);
			Palette.Add(5, UIColor.Yellow);
			Palette.Add(6, UIColor.Magenta);
			Palette.Add(7, UIColor.Cyan);
            // 0x08-0x3F: user-defined colour from the PALETTE record
			Palette.Add(0x1F, UIColor.FromRGB(204, 204, 255));

			Palette.Add (0x40, UIColor.White); //SystemColors.Window);
			Palette.Add(0x41, UIColor.Black); //SystemColors.WindowText);
			Palette.Add (0x43, UIColor.LightGray); //SystemColors.WindowFrame);//dialogue background colour
			Palette.Add (0x4D, UIColor.Black); //SystemColors.ControlText);//text colour for chart border lines
			Palette.Add (0x4E, UIColor.LightGray); //SystemColors.Control); //background colour for chart areas
            Palette.Add(0x4F, UIColor.Black); //Automatic colour for chart border lines
			Palette.Add (0x50, UIColor.Yellow); //SystemColors.Info);
			Palette.Add(0x51,  UIColor.Black); //SystemColors.InfoText);
			Palette.Add(0x7FFF,  UIColor.Black); //SystemColors.WindowText);
        }

        public UIColor this[int index]
        {
            get
            {
                if (Palette.ContainsKey(index))
                {
                    return Palette[index];
                }
                return UIColor.White;
            }
            set
            {
                Palette[index] = value;
            }
        }
    }
}
