using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class Music : Page
    {
        public Music()
        {
            this.InitializeComponent();
        }

        //async private void SetLocalMedia()
        //{
        //    var openPicker = new Windows.Storage.Pickers.FileOpenPicker();

        //    openPicker.FileTypeFilter.Add(".wmv");
        //    openPicker.FileTypeFilter.Add(".mp4");
        //    openPicker.FileTypeFilter.Add(".wma");
        //    openPicker.FileTypeFilter.Add(".mp3");

        //    var file = await openPicker.PickSingleFileAsync();

        //    var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);

        //    // mediaControl is a MediaElement defined in XAML
        //    if (null != file)
        //    {
        //        mediaControl.SetSource(stream, file.ContentType);

        //        mediaControl.Play();
        //    }
        //}
    }
}
