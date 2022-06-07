using Windows.Devices.Bluetooth.Advertisement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Farming.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Controller : Page
    {
        public Controller()
        {
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            this.InitializeComponent();
        }


        private void Get_Devices()
        {
            Device_List.Items.Clear();
            if (Switch_Bluetooth.IsOn)
            {
                // string[] BL_Devices = Bluetooth
                BluetoothLEAdvertisementWatcher BLwatcher = new BluetoothLEAdvertisementWatcher();
                BLwatcher.Received += OnAdvertisementReceived;
                BLwatcher.Start();
                Device_List.Items.Add("Bluetooth");
            }
            if (Switch_Wifi.IsOn)
            {
                Device_List.Items.Add("Wifi");
            }
            if (Switch_USB.IsOn)
            {
                Device_List.Items.Add("USB");
            }
        }

        private void Switch_Bluetooth_Toggled(object sender, RoutedEventArgs e)
        {
            Get_Devices();
        }

        private void Switch_Wifi_Toggled(object sender, RoutedEventArgs e)
        {
            Get_Devices();
        }

        private void Switch_USB_Toggled(object sender, RoutedEventArgs e)
        {
            Get_Devices();
        }

        private void OnAdvertisementReceived(BluetoothLEAdvertisementWatcher watcher, BluetoothLEAdvertisementReceivedEventArgs eventArgs)
        {
            // Do whatever you want with the advertisement
            Device_List.Items.Add(watcher.ToString());
        }
    }
}