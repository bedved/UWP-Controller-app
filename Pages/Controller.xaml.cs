using System;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Devices.Enumeration;
using Windows.Devices.Bluetooth;
using Windows.Foundation;
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
            Device_List.Items.Add("ASdASd");

        }
        BluetoothLEAdvertisementWatcher watcher = new BluetoothLEAdvertisementWatcher();


        private bool Is_BT_On = false;
        private void Get_Devices()
        {
            Device_List.Items.Clear();
            // Checks bluetooth status, if on - updates it
            if (Switch_Bluetooth.IsOn)
            {
                if (Is_BT_On == false)
                {
                    Bluetooth_Controller_On();
                }

                else
                {
                    Bluetooth_Controller_Update();
                }

                Is_BT_On = true;
            }

            // Shuts off Bluetooth
            else
            {
                if (Is_BT_On == true)
                {
                    Bluetooth_Controller_Off();
                }
                Is_BT_On = false;
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

        public void Bluetooth_Controller_On()
        {
            watcher.Received += OnAdvertisementReceived;
            //watcher.Start();
            DevicePicker picker = new DevicePicker(); 
            picker.Filter.SupportedDeviceSelectors.Add(BluetoothLEDevice.GetDeviceSelectorFromPairingState(false));
            picker.Filter.SupportedDeviceSelectors.Add(BluetoothLEDevice.GetDeviceSelectorFromPairingState(true));

            picker.Show(new Rect(150, 200, Width, Height));
        }

        private async void OnAdvertisementReceived(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementReceivedEventArgs args)
        {
            DateTimeOffset timestamp = DateTimeOffset.Now;
            _ = Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
              {
                  Device_List.Items.Add(args.BluetoothAddress);
              });
            // Device_List.Items.Add(args.BluetoothAddress);
        }

        private void Bluetooth_Controller_Update()
        {

        }

        private void Bluetooth_Controller_Off()
        {


        }

    }
}