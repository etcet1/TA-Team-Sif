using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Sensors;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BabysitterApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Rattle : Page
    {
        public Accelerometer Accelerometer { get; set; }
        private CurrentPosition currentPosition { get; set; }
        // MainPage rootPage = MainPage.Curr;

        public Rattle()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            this.Accelerometer = Accelerometer.GetDefault();
            this.currentPosition = new CurrentPosition(0, 0, 0);

            if (this.Accelerometer != null)
            {
                this.Accelerometer.ReportInterval = 5;
                this.Accelerometer.ReadingChanged += (snd, args) =>
                {
                    this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        var newPosition = new CurrentPosition(args.Reading.AccelerationX, args.Reading.AccelerationY, args.Reading.AccelerationZ);

                        if (IsPositionChanged(newPosition) && Math.Abs(newPosition.X) > 0 && Math.Abs(newPosition.X) < 1
                            && Math.Abs(newPosition.Y) > 0 && Math.Abs(newPosition.Y) < 1
                            && Math.Abs(newPosition.Z) > 0 && Math.Abs(newPosition.Z) < 1)
                        {
                            this.PlaySoundEffect();
                            this.AnimateImage(newPosition);
                            this.currentPosition = newPosition;
                        }
                    });
                };
                //this.Accelerometer.ReadingChanged += new TypedEventHandler<Accelerometer, AccelerometerReadingChangedEventArgs>(Moved);
            }
            else
            {
                //rootPage.NotifyUser("No accelerometer found", NotifyType.StatusMessage);
            }
        }

        //async private void Moved(Windows.Devices.Sensors.Accelerometer sender, AccelerometerReadingChangedEventArgs args)
        //{
        //    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        //    {
        //        var newPosition = new CurrentPosition(args.Reading.AccelerationX, args.Reading.AccelerationY, args.Reading.AccelerationZ);

        //        if (IsPositionChanged(newPosition) && Math.Abs(newPosition.X) > 0 && Math.Abs(newPosition.X) < 1
        //            && Math.Abs(newPosition.Y) > 0 && Math.Abs(newPosition.Y) < 1
        //            && Math.Abs(newPosition.Z) > 0 && Math.Abs(newPosition.Z) < 1)
        //        {
        //            this.PlaySoundEffect();
        //            this.AnimateImage(newPosition);
        //            this.currentPosition = newPosition;
        //        }
        //    });
        //}

        private void AnimateImage(CurrentPosition newPosition)
        {
            Canvas.SetLeft(imageRattle, imageRattle.Margin.Left + newPosition.X * 5);
            Canvas.SetTop(imageRattle, imageRattle.Margin.Top + newPosition.Y * 5);
        }

        private void PlaySoundEffect()
        {
            this.mediaControl.Play();
            this.mediaControl.Stop();
        }

        private void PlaySoundEffect(object sender, TappedRoutedEventArgs e)
        {
            this.PlaySoundEffect();
        }

        private bool IsPositionChanged(CurrentPosition newPosition)
        {
            if (newPosition.X != this.currentPosition.X
                || newPosition.Y != this.currentPosition.Y
                || newPosition.Z != this.currentPosition.Z)
            {
                return true;
            }
            return false;
        }
    }
}
