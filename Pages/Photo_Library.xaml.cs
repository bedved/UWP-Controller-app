using System;
using System.IO;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Farming.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Photo_Library : Page
    {
        public Photo_Library()
        {
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            this.InitializeComponent();
            this.FilesChecker();
        }


        private void ScrollToBottom(TextBox textBox)
        // Scrolls the TextBox that is given
        {
            var grid = (Grid)VisualTreeHelper.GetChild(textBox, 0);
            for (var i = 0; i <= VisualTreeHelper.GetChildrenCount(grid) - 1; i++)
            {
                object obj = VisualTreeHelper.GetChild(grid, i);
                if (!(obj is ScrollViewer)) continue;
                ((ScrollViewer)obj).ChangeView(0.0f, ((ScrollViewer)obj).ExtentHeight, 1.0f, true);
                break;
            }
        }

        void FilesChecker()
        // Checks the folders inside folder "Photos"
        {
            String Photos_path = System.IO.Directory.GetCurrentDirectory();
            Photos_path += "/Photos";
            string[] Files = Directory.GetDirectories(Photos_path);
            ChooseDeviceBox.Items.Clear();
            foreach (string File in Files)
            {
                ChooseDeviceBox.Items.Add(Path.GetFileName(File));
            }
        }

        void WriteToTextLog(string DesiredText)
        // Adds text to right side log
        {
            MainUI.Home?.WriteMainLog(DesiredText);
            TextLog.Text += "\n" + DesiredText;
            ScrollToBottom(TextLog);
        }
        // TODO::
        /*
         * WriteToTextLog - Copy the message to a file (.txt file)
         */


        private void ChooseDeviceBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        // ComboBox Select the file you want to see
        {
            if (ChooseDeviceBox.Items.Count > 0)
            {
                WriteToTextLog(ChooseDeviceBox.SelectedItem.ToString());
            }
        }

        private void ForceFilesButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        // Forces the ComboBox list to update
        {
            FilesChecker();
        }


    }



}

