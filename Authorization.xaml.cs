namespace kysMaui;

public partial class Authorization : ContentPage
{
    public Authorization()
    {
        InitializeComponent();
    }

    async private void Submit(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EventInfo());
    }

    private void OnClickRegenetareCaptcha(object sender, EventArgs e)
    {
        Captcha captcha = new();
        captcha.Generate(4);
        Canvas.Invalidate();
    }
}