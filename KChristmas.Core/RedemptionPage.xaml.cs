using KChristmas.Core.Helpers;

namespace KChristmas.Core;

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
            AcceptGiftPanelStep3.FadeTo(1, 2000),
            AcceptGiftPanelStep3.ScaleTo(1, 2000)
        );
    }
}
