using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ImageFrame2
{
    public partial class App : Application
    {
        const int index = 0;
        public App()
        {
            InitializeComponent();
            if (Properties.ContainsKey(index.ToString()))
            {
                indexNew = (string)Properties[index.ToString()];
            }
            MainPage = new ImageFrame2.MainPage();
        }
        public string indexNew { set; get; }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            Properties[index.ToString()] = indexNew;
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
