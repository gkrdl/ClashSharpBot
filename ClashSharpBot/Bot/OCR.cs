﻿/*
 * Clash Sharp Bot
 * 
 * Author : Moien007
 * Desc : Clash of Clans Screen and Resource Reader
 *        Using Tesseract Open Source OCR Engine With Tessercat.Net Wrapper
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using Tesseract;

namespace ClashSharpBot.Bot
{
    static class OCR
    {
        public static TesseractEngine OCREngine { get; private set; }

        static OCR()
        {
            OCREngine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default); ;

            OCREngine.DefaultPageSegMode = PageSegMode.SingleWord;
        }

        public static string ReadText(Rectangle rect)
        {
            Bitmap image = BlueStacks.GetBitmap().Clone(rect, PixelFormat.Format32bppArgb);

            return OCREngine.Process(image).GetText();
        }

        public static int ReadNumber(Rectangle rect)
        {
            return Base.BasicMath.CleanStringOfNonDigits(ReadText(rect));
        }
    }
}
