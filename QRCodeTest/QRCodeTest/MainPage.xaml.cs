using Camera.MAUI;

namespace QRCodeTest
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            cameraView.BarCodeOptions = new()
            {
                PossibleFormats = new List<BarcodeFormat>() { BarcodeFormat.QR_CODE, BarcodeFormat.EAN_13, BarcodeFormat.EAN_13 }
               
            };
        }

        private void cameraView_CamerasLoaded(object sender, EventArgs e)
        {
            if (cameraView.Cameras.Count > 0)
            {
                cameraView.Camera = cameraView.Cameras.First();
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await cameraView.StopCameraAsync();
                    await cameraView.StartCameraAsync();
                });
            }
        }

        private void cameraView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                barcodeScanResult.Text = $"{args.Result[0].BarcodeFormat}: {args.Result[0].Text}";
            });
        }
    }

}
