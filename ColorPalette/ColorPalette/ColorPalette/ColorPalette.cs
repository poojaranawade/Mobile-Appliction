using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ColorPalette
{
    public class ColorPalette : ContentPage
    {
        Label valueRed, valueGreen, valueBlue, redLabel, greenLabel, blueLabel;
        Label hexValue, hslValue, hexHeader, hslHeader, boxHeader;
        Button redButton1, redButton2, greenButton1, greenButton2, blueButton1, blueButton2;
        int red = 0, green = 0, blue = 0;
        double hue, saturation, luminosity;
        BoxView boxRed, boxGreen, boxBlue, colorBox;
        StackLayout stackLayout = new StackLayout();

        public ColorPalette()
        {
            //create buttons for "+" and "-" of RGB values
            //RED
            redButton1 = new Button
            {
                Text = "-",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                BorderWidth = 2,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            redButton1.Clicked += OnButtonClick;
            redButton2 = new Button
            {
                Text = "+",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                BorderWidth = 2,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            redButton2.Clicked += OnButtonClick;
            //GREEN
            greenButton1 = new Button
            {
                Text = "-",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                BorderWidth = 2,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            greenButton1.Clicked += OnButtonClick;
            greenButton2 = new Button
            {
                Text = "+",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                BorderWidth = 2,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            greenButton2.Clicked += OnButtonClick;
            //BLUE
            blueButton1 = new Button
            {
                Text = "-",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                BorderWidth = 2,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            blueButton1.Clicked += OnButtonClick;
            blueButton2 = new Button
            {
                Text = "+",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                BorderWidth = 2,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            blueButton2.Clicked += OnButtonClick;

            //create labels of RGB
            //RED
            redLabel = new Label
            {
                Text = "RED Value",
                TextColor = Color.Red,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
            //GREEN
            greenLabel = new Label
            {
                Text = "GREEN Value",
                TextColor = Color.Green,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
            //BLUE
            blueLabel = new Label
            {
                Text = "BLUE Value",
                TextColor = Color.Blue,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
            //create header label for page
            Label header = new Label
            {
                Text = "RGB Color Palette",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            //create labels to show current value of RGB
            //RED
            valueRed = new Label
            {
                Text = String.Format("{0}", red),                
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            //GREEN
            valueGreen = new Label
            {
                Text = String.Format("{0}", green),
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            //BLUE
            valueBlue = new Label
            {
                Text = String.Format("{0}", blue),
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            //create boxView to show composition of RGB valyes
            colorBox = new BoxView
            {
                Color = Color.FromRgb(red, green, blue),
                WidthRequest = 250,
                HeightRequest = 100,
                HorizontalOptions = LayoutOptions.Center,
            };
            //create seperate boxView for current R G B values
            //RED
            boxRed = new BoxView
            {
                Color=Color.FromRgb(red,0,0),
                WidthRequest = 30,
                HeightRequest = 50,

            };
            //GREEN
            boxGreen = new BoxView
            {
                Color = Color.FromRgb(0, green, 0),
                WidthRequest = 30,
                HeightRequest = 50,

            };
            //BLUE
            boxBlue = new BoxView
            {
                Color = Color.FromRgb(0, 0, blue),
                WidthRequest = 30,
                HeightRequest = 50,

            };

            //create label to show hex value of RGB
            hexValue = new Label
            {
                Text = "#000000",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
            //create label to show HSL value of current RGB
            hslValue = new Label
            {
                Text = "00,00,00",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
            //create headers
            boxHeader = new Label
            {
                Text = "RGB composition",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
            hexHeader = new Label
            {
                Text = "RGB -> Hex ",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
            hslHeader = new Label
            {
                Text = "HSL",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            stackLayout = new StackLayout
            {
                Spacing =20,
                Children =
                  {
                    header,
                    redLabel,
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        Children =
                        {
                            boxRed,
                            valueRed,
                            redButton1,
                            redButton2
                        }
                    },
                    greenLabel,
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        Children =
                        {
                            boxGreen,
                            valueGreen,
                            greenButton1,
                            greenButton2

                        }
                    },
                    blueLabel,
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        Children =
                        {
                            boxBlue,
                            valueBlue,
                            blueButton1,
                            blueButton2

                        }
                    },
                    boxHeader,
                    colorBox,
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        Children =
                        {
                            new StackLayout
                            {
                                Orientation = StackOrientation.Vertical,
                                HorizontalOptions = LayoutOptions.CenterAndExpand,
                                Children =
                                {
                                    hexHeader,
                                    hexValue
                                }
                            },
                            new StackLayout
                            {
                                Orientation = StackOrientation.Vertical,
                                HorizontalOptions = LayoutOptions.CenterAndExpand,
                                Children =
                                {
                                    hslHeader,
                                    hslValue
                                }
                            }
                            
                        }
                    }
                }
            };
            // Retriving current state of project (RGB values, HSL values and RED, GREEN and BLUE values)
            App app = Application.Current as App;
            valueRed.Text = app.redValue;
            valueGreen.Text = app.greenValue;
            valueBlue.Text = app.blueValue;

            // Put the StackLayout in a ScrollView.
            Content = new ScrollView
            {
                Content = stackLayout,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
        }

        void OnButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button == redButton1)
            {
                if (red == 0)
                {
                    redButton1.IsEnabled = false;
                }
                else
                {
                    red -= 1;
                    valueRed.Text = String.Format("{0}", red);
                }
            }
            else if (button == redButton2)
            {
                if (red == 255)
                {
                    redButton2.IsEnabled = false;
                }
                else
                {
                    red += 1;
                    valueRed.Text = String.Format("{0}", red);
                }
            }
            else if (button == greenButton1)
            {
                if (green == 0)
                {
                    greenButton1.IsEnabled = false;
                }
                else
                {
                    green -= 1;
                    valueGreen.Text = String.Format("{0}", green);
                }
            }
            else if (button == greenButton2)
            {
                if (green == 255)
                {
                    greenButton2.IsEnabled = false;
                }
                else
                {
                    green += 1;
                    valueGreen.Text = String.Format("{0}", green);
                }
            }
            else if (button == blueButton1)
            {
                if (blue == 0)
                {
                    blueButton1.IsEnabled = false;
                }
                else
                {
                    blue -= 1;
                    valueBlue.Text = String.Format("{0}", blue);
                }
            }
            else if (button == blueButton2)
            {
                if (blue == 255)
                {
                    blueButton2.IsEnabled = false;
                }
                else
                {
                    blue += 1;
                    valueBlue.Text = String.Format("{0}", blue);
                }
            }
            if (red != 0 && red != 255)
            {
                redButton1.IsEnabled = true;
                redButton2.IsEnabled = true;
            }
            if (green != 0 && green != 255)
            {
                greenButton1.IsEnabled = true;
                greenButton2.IsEnabled = true;
            }
            if (blue != 0 && blue != 255)
            {
                blueButton1.IsEnabled = true;
                blueButton2.IsEnabled = true;
            }
            
            colorBox.Color = Color.FromRgb(red, green, blue);
            boxRed.Color = Color.FromRgb(red, 0, 0);
            boxGreen.Color = Color.FromRgb(0, green, 0);
            boxBlue.Color = Color.FromRgb(0, 0, blue);

            hue = colorBox.Color.Hue;
            saturation = colorBox.Color.Saturation;
            luminosity = colorBox.Color.Luminosity;
            hexValue.Text = string.Format("#{0:X2}{1:X2}{2:X2}", red, green, blue);
            hslValue.Text = string.Format("{0:##.00}, {1:##.00}, {2:##.00}", hue, saturation, luminosity);

            // Retriving current state of project (RGB values, HSL values and RED, GREEN and BLUE values)
            App app = Application.Current as App;
            app.redValue = valueRed.Text;
            app.greenValue = valueGreen.Text;
            app.blueValue = valueBlue.Text;
        }
    }

}