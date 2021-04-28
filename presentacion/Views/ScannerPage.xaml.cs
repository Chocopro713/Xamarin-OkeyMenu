using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace presentacion.Views
{
    public partial class ScannerPage : ContentPage
    {
        public ScannerPage()
        {
            InitializeComponent();
            GoogleVisionBarCodeScanner.Methods.SetSupportBarcodeFormat(GoogleVisionBarCodeScanner.BarcodeFormats.All);
        }

        private void CameraView_OnDetected(object sender, GoogleVisionBarCodeScanner.OnDetectedEventArg e)
        {
            var results = e.BarcodeResults;

            var resultString = string.Empty;
            var barcodeValue = string.Empty;

            foreach (var barcode in results)
            {
                resultString += $"Type: {barcode.BarcodeType}, Value: {barcode.DisplayValue} {Environment.NewLine}";
                barcodeValue = barcode.DisplayValue;
            }


            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Results", resultString, "OK");

                GoogleVisionBarCodeScanner.Methods.SetIsScanning(true);

                MessagingCenter.Send(barcodeValue, MessagingKeys.GetInfoBarcode);
            });

        }
    }
}
