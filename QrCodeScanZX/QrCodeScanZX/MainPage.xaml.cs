namespace QrCodeScanZX
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            barcodeReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions
            {
                Formats = ZXing.Net.Maui.BarcodeFormat.QrCode,
                AutoRotate = true,
                Multiple = true
            };
        }


        private void barcodeReader_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
        {
            var first = e.Results.FirstOrDefault();
            if(first == null)
            {
                return;
            }
            Dispatcher.DispatchAsync(async () =>
            {
                linkLabel.Text = first.Value;
                linkLabel.IsVisible = true;
            });
        }

        private async void OnLinkLabelTapped(object sender, EventArgs e)
        {
            var url = linkLabel.Text;
            if (!string.IsNullOrWhiteSpace(url))
            {
                await Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
            }
        }
    }

}
