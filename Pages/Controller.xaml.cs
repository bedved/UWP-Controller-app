using System;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
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

        Windows.UI.Core.CoreDispatcher dispatcher;
        public static DeviceWatcher deviceWatcher = null;
        public static int count = 0;
        public static DeviceInformation[] interfaces = new DeviceInformation[1000];
        public static bool isEnumerationComplete = false;
        public static string StopStatus = null;
        bool BLWatcherStatus = false;

        private void Get_Devices()
        {
            Device_List.Items.Clear();
            if (Switch_Bluetooth.IsOn)
            {
                if (BLWatcherStatus == false)
                {
                    try
                    {
                        deviceWatcher = DeviceInformation.CreateWatcher();
                        deviceWatcher.Added += DeviceWatcher_Added;
                        deviceWatcher.Start();
                        BLWatcherStatus = true;
                    }
                    catch (ArgumentException)
                    {
                        Device_List.Items.Clear ();
                        string Fail = "Try failed!";
                        Device_List.Items.Add(Fail);
                        Device_List.Items.Equals(Fail);
                    }

                    BluetoothUpdateAsync();
                }
                else
                {
                    BluetoothUpdateAsync();
                }
                // Poista, kun valmis!
                Device_List.Items.Add("Bluetooth");
            }
            // Turns off the bluetooth watcher
            else
            {
                if (BLWatcherStatus == true)
                {
                    deviceWatcher.Stop();
                    BLWatcherStatus = false;
                }
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

        async void DeviceWatcher_Added(DeviceWatcher sender, DeviceInformation args)
        {

        }

        private async Task BluetoothUpdateAsync()
        {
            string[] BL_Devices;

            //Using DeviceInformation.FindAllAsync method
            var deviceInfoCollection = await DeviceInformation.FindAllAsync();
            foreach (var deviceInfo in deviceInfoCollection)
            {
                Device_List.Items.Add(deviceInfo.ToString());
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
    }
}