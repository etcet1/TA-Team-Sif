using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class Color : Page
    {
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public Color()
        {
            this.InitializeComponent();
        }

        private void GenerateRandomColor()
        {
            var random = new Random();
            var color = ((SolidColorBrush)this.canvasColor.Background).Color;

            color.R = (byte)(random.Next(0, 255) - color.R);
            color.G = (byte)(random.Next(0, 255) - color.G);
            color.B = (byte)(random.Next(0, 255) - color.B);
            ((SolidColorBrush)this.canvasColor.Background).Color = color;
        }

        private void Execute(object sender, RoutedEventArgs e)
        {
            this.dispatcherTimer.Tick += dispatcherTimerExcute;

            this.dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);

            this.dispatcherTimer.Start();
        }

        private void dispatcherTimerExcute(object sender, object e)
        {
            this.GenerateRandomColor();
        }

        private void ShowButton(object sender, TappedRoutedEventArgs e)
        {
            this.buttonStopAnimation.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void StopAnimation(object sender, TappedRoutedEventArgs e)
        {
            this.dispatcherTimer.Stop();

            this.Frame.Navigate(typeof(StartPage));
        }
    }
}
