using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ColorPalette
{
    public class App : Application
    {
        const string valueRed = "valueRed";
        const string valueGreen = "valueGreen";
        const string valueBlue = "valueBlue";

        public App()
        {
            if (Properties.ContainsKey(valueRed))
            {
                redValue = (string)Properties[valueRed];
            }
            if (Properties.ContainsKey(valueGreen))
            {
                greenValue = (string)Properties[valueGreen];
            }
            if (Properties.ContainsKey(valueBlue))
            {
                blueValue = (string)Properties[valueBlue];
            }

            MainPage = new ColorPalette();
        }

        public string redValue { set; get; }
        public string greenValue { set; get; }
        public string blueValue { set; get; }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            Properties[valueRed] = redValue;
            Properties[valueGreen] = greenValue;
            Properties[valueBlue] = blueValue;
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
