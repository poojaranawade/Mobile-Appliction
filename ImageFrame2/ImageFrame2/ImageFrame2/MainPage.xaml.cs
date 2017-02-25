using Xamarin.Forms;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Collections.ObjectModel;
using System;
namespace ImageFrame2
{
    public partial class MainPage : ContentPage
    {
        App app = Application.Current as App;
        string[] images = new string[100];
        int index = 0, i = 0,j;
        Assembly assembly;
        Image fromRes, fromFile, fromStream, fromUrl, N;
        Stream stream;
        Label lab;
        string res;
        StackLayout list;
        string resourseID;
        ActivityIndicator activityIndicator = new ActivityIndicator();
        public MainPage()
        {
            InitializeComponent();
            index = int.Parse(app.indexNew);
            i = index;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (switchButton.IsToggled == true)
                {
                    timer.Text = (Int32.Parse(timer.Text) - 1).ToString();
                    if (Int32.Parse(timer.Text) == 0)
                    {
                        if (i == 0)
                        {
                            activityIndicator.IsRunning = true;
                            imageFrame.Source = ImageSource.FromUri(new Uri(images[i]));
                            i = i + 1;
                            activityIndicator.IsRunning = false;
                        }
                        else if (i == 1)
                        {
                            activityIndicator.IsRunning = true;
                            imageFrame.Source = ImageSource.FromFile(images[i]);
                            i = i + 1;
                            activityIndicator.IsRunning = false;
                        }
                        else if (i == 2)
                        {
                            activityIndicator.IsRunning = true;
                            imageFrame.Source = ImageSource.FromResource(images[i]);
                            i = i + 1;
                            activityIndicator.IsRunning = false;
                        }
                        else if (i == 3)
                        {
                            activityIndicator.IsRunning = true;
                            resourseID = images[i];
                            imageFrame.Source = ImageSource.FromStream(() =>
                            {
                                Assembly assembly = GetType().GetTypeInfo().Assembly;
                                Stream stream = assembly.GetManifestResourceStream(resourseID);
                                return stream;
                            });
                            i = i + 1;
                            activityIndicator.IsRunning = false;
                        }
                        timer.Text = entryTime.Text;
                        if (i == index)
                        {
                            i = 0;
                        }
                    }
                    // app.I = i.ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            });
            fromRes = new Image
            {
                Source = ImageSource.FromResource("ImageFrame2.forResource.jpg"),
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.End,
                HeightRequest = 100,
                WidthRequest = 100
            };
            // Adding image from Resource
            list1.Children.Add(fromRes);
            images[index] = "ImageFrame2.forResource.jpg";
            index = index + 1;

            fromFile = new Image
            {
                Source = ImageSource.FromFile("fromFile.jpg"),
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.End,
                HeightRequest = 100,
                WidthRequest = 100
            };
            //Adding image from File
            list2.Children.Add(fromFile);
            images[index] = "fromFile.jpg";
            index = index + 1;

            fromStream = new Image
            {
                Source = ImageSource.FromStream(() =>
                {
                    assembly = GetType().GetTypeInfo().Assembly;
                    stream = assembly.GetManifestResourceStream("ImageFrame2.fromStream.jpg");
                    return stream;
                }),
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.End,
                HeightRequest = 100,
                WidthRequest = 100
            };
            //Adding image from stream
            list3.Children.Add(fromStream);
            images[index] = "ImageFrame2.fromStream.jpg";
            index = index + 1;

            fromUrl = new Image
            {
                Source = "http://hd.wallpaperswide.com/thumbs/small_blue_flowers_macro-t2.jpg",
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.End,
                HeightRequest = 100,
                WidthRequest = 100
            };
            //adding image from URL
            list4.Children.Add(fromUrl);
            images[index] = "http://hd.wallpaperswide.com/thumbs/small_blue_flowers_macro-t2.jpg";
            index = index + 1;


            status.Text = i + "/" + (index + 1);

        }

        void ValidateInput(object sender, EventArgs args)
        {
            Entry textEntry = (Entry)sender;
            if (textEntry.Text == " ")
            {
                DisplayAlert("Alert", "Enter values between 1 to 60 inclusive", "OK");
            }
            int seconds = Int32.Parse(textEntry.Text);
            if (seconds > 0 && seconds <= 60)
            {
                stepper.Value = seconds;
                slider.Value = seconds;
                timer.Text = textEntry.Text;
            }
            else
            {
                DisplayAlert("Alert", "Enter values between 1 to 60 inclusive", "OK");
                textEntry.Text = stepper.Value.ToString();
            }
        }

        void OnAddButtonClicked(object sender, EventArgs args)
        {
            hiddenChild.IsVisible = true;
        }
        async void OnRemoveButtonClicked(object sender, EventArgs args)
        {
            int count = j;
            if (count == 4)
            {
                await DisplayAlert("Warning!", "Can't Remove:Default Image", "OK");
            }
            else
            {
                var answer = await DisplayAlert("Confirm", "Do you want to remove \"" + images[index - 1] + "\"from the list?", "Yes", "No");
                if (answer == true)
                {
                    list.Children.Clear();
                    j--;
                }
                //  app.Index = index.ToString();
            }
        }

        void OnAddImageButtonClicked(object sender, EventArgs args)
        {
            lab = new Label
            {
                Text = entryName.Text
            };
            N = new Image
            {
                Source = ImageSource.FromUri(new Uri(entryUrl.Text)),
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.End,
                HeightRequest = 100,
                WidthRequest = 100
            };
            list = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    lab,
                    N
                }
            };

            j++;
            stacklayout.Children.Add(list);
            images[index] = entryUrl.Text;
            index = index + 1;
            entryUrl.Text = null;
            entryName.Text = null;

            hiddenChild.IsVisible = false;


            //app.Index = index.ToString();

        }
        
        void OnSwitchToggled(object sender, ToggledEventArgs args)
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (switchButton.IsToggled == true)
                {
                    timer.Text = (int.Parse(timer.Text) - 1).ToString();
                    if (int.Parse(timer.Text) == 0)
                    {
                        if (i == 0)
                        {
                            activityIndicator.IsRunning = true;
                            imageFrame.Source = ImageSource.FromResource(images[i]);
                            i = i + 1;
                            activityIndicator.IsRunning = false;
                        }
                        else if (i == 1)
                        {
                            activityIndicator.IsRunning = true;
                            imageFrame.Source = ImageSource.FromFile(images[i]);
                            i = i + 1;
                            activityIndicator.IsRunning = false;
                        }
                        else if (i == 2)
                        {
                            activityIndicator.IsRunning = true;
                            res = images[i];
                            imageFrame.Source = ImageSource.FromStream(() =>
                            {
                                assembly = GetType().GetTypeInfo().Assembly;
                                stream = assembly.GetManifestResourceStream(res);
                                return stream;
                            });
                            i = i + 1;
                            activityIndicator.IsRunning = false;
                        }
                        else
                        {
                            activityIndicator.IsRunning = true;
                            imageFrame.Source = ImageSource.FromUri(new Uri(images[i]));
                            i = i + 1;
                            activityIndicator.IsRunning = false;
                        }
                        timer.Text = entryTime.Text;
                        if (i == index)
                        {
                            i = 0;
                        }

                    }
                    //app.I = i.ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            });

        }
        void OnStepperValueChanged(object sender, ValueChangedEventArgs args)
        {
            Stepper stepper = (Stepper)sender;
            slider.Value = stepper.Value;
            entryTime.Text = stepper.Value.ToString();
            timer.Text = stepper.Value.ToString();
            //app.TextEntry = entryTime.Text;
        }
        void OnImagePropertyChanged(object sender, ValueChangedEventArgs args)
        {
        }
        async void OnImageTapped(object sender, EventArgs args)
        {

            if (sender == list1)
            {
                imageFrame.Source = fromRes.Source;
            }
            else if (sender == list2)
            {
                imageFrame.Source = fromFile.Source;

            }
            else if (sender == list3)
            {
                imageFrame.Source = fromStream.Source;
            }
            else if (sender == list4)
            {
                imageFrame.Source = fromUrl.Source;
            }
            else if (sender == stacklayout)
            {
                imageFrame.Source = N.Source;
            }
            else
            {
                await DisplayAlert("Warning!", "More Tappped", "OK");
            }

        }
        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            Slider slider = (Slider)sender;
            int value = Convert.ToInt32(slider.Value);
            if (value == 0)
            {
                value = value + 1;
                slider.Value = value;
                entryTime.Text = value.ToString();
                timer.Text = value.ToString();
            }
            else
            {
                slider.Value = value;
                entryTime.Text = value.ToString();
                timer.Text = value.ToString();
            }
            // app.TextEntry = timeEntry.Text;
        }

    }
}
