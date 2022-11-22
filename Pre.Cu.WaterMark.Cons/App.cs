using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Pre.Cu.WaterMark.Cons;

public class App
{
    private string _assetsPath = @"../../../assets";

    public void Run()
    {
        var images = Directory.EnumerateFiles(_assetsPath);
        Console.WriteLine("I've found following images:");
        foreach (var image in images)
        {
            Console.WriteLine(image);
        }

        EditImage(images.First());
    }

    private void EditImage(string image)
    {
        using (var img = Image.FromFile(image))
        {
            AddWatermark(img);

            img.Save($"{image}.watermarked.jpg");
        }
    }

    private static void AddWatermark(Image img)
    {
        using (Graphics g = Graphics.FromImage(img))
        {
            g.DrawString("HOWEST", new Font(FontFamily.GenericSansSerif, 20, FontStyle.Bold),
                new SolidBrush(Color.Fuchsia), 100, 100);

            g.DrawEllipse(
                new Pen(new SolidBrush(Color.Aqua), 8),
                new Rectangle(150, 150, 50, 50));
        }
    }
}