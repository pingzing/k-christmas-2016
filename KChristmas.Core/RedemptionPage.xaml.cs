using System;
using System.Threading.Tasks;
using KChristmas.Core.Helpers;
using Xamarin.Forms;

namespace KChristmas.Core
{
    public partial class RedemptionPage : ContentPage
    {
        public RedemptionPage()
        {
            InitializeComponent();
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            if (!Settings.GiftAccepted)
            {
                Settings.GiftAccepted = true;
            }

            await ShowCompletePanel();
        }

        private async Task ShowCompletePanel()
        {
            await Task.Delay(1000);

            await Task.WhenAll(
                AcceptGiftPanelStep1.FadeTo(1, 2000),
                AcceptGiftPanelStep1.ScaleTo(1, 2000)
            );

            await Task.Delay(3000);

            await Task.WhenAll(
                AcceptGiftPanelStep2.FadeTo(1, 2000),
                AcceptGiftPanelStep2.ScaleTo(1, 2000)
            );

            await Task.Delay(2000);

            await Task.WhenAll(
                AcceptGiftPanelStep3.ScaleTo(1, 2000),
                AcceptGiftPanelStep3.FadeTo(1, 2000)
            );

            await Task.Delay(4000);

            await Task.WhenAll(
                AcceptGiftPanelStep4.ScaleTo(1, 2000),
                AcceptGiftPanelStep4.FadeTo(1, 2000)
            );

            await Task.Delay(1000);

            await Task.WhenAll(
                AcceptGiftPanelStep5.ScaleTo(1, 2000),
                AcceptGiftPanelStep5.FadeTo(1, 2000),
                PhoneOverlayImage.FadeTo(1, 2000)
            );

            await Task.Delay(1500);

            await Task.WhenAll(
                AcceptGiftPanelStep6.ScaleTo(1, 2000),
                AcceptGiftPanelStep6.FadeTo(1, 2000)
            );
        }
    }
}
