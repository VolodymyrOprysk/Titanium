using OpenQA.Selenium;
using System;
using System.IO;
using System.Text;

namespace Titanium
{
    public class ScreenshotMaker
    {
        public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName)
        {
            var path = Directory.GetCurrentDirectory();

            var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
            var fileName = new StringBuilder(path);

            fileName.Append(@"\" + ScreenShotFileName);
            fileName.Append(DateTime.Now.ToString(@"\ddMMyyyy_mms"));
            fileName.Append(".jpeg");
            screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Jpeg);
            return fileName.ToString();
        }
    }
}
