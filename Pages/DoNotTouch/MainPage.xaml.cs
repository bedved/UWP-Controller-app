using System.Collections.Generic;
using System.IO;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Farming
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            FrameUI.Navigate(typeof(Pages.MainUI), null);
        }

        private void NavigationViewItem_Tapped_MainUI(object sender, TappedRoutedEventArgs e)
        {
            //if (FrameUI.Loaded(typeof(Pages.MainUI)) == true)
            FrameUI.Navigate(typeof(Pages.MainUI), null);
        }

        private void NavigationViewItem_Tapped_Controller(object sender, TappedRoutedEventArgs e)
        {
            FrameUI.Navigate(typeof(Pages.Controller), null);
        }

        private void NavigationViewItem_Tapped_Photo_Library(object sender, TappedRoutedEventArgs e)
        {
            FrameUI.Navigate(typeof(Pages.Photo_Library), null);
        }
    }
}
