namespace kysMaui;

public partial class Authorization : ContentPage
{
    bool validated = false;
    Captcha captcha;
    public Authorization()
    {
        InitializeComponent();
        captcha = (Captcha)graphicsView.Drawable;
    }

    void Submit(object sender, EventArgs e)
    {
        if (validated)
        {
            App.Current.MainPage = new NavigationPage(new EventInfo());
            return;
        }
        // TODO: warn the user to enter captcha before auth

    }

    void OnClickRegenetareCaptcha(object sender, EventArgs e)
    {
        captcha.Generate();
        graphicsView.Invalidate();
    }

    async void OnSubmitCaptcha(object sender, EventArgs e)
    {
        if (captchaEntry.Text == captcha.Value)
        {
            validated = true;
            return;
        }

        validated = false;
        EnableUI(false);
        await DisplayAlert("Предупреждение", "Вы ввели неправильную капчу. Следующая попытка будет доступна через 10 секунд", "OK");
        await Task.Delay(10000);
        EnableUI(true);
        captcha.Generate();
        graphicsView.Invalidate();
    }

    void EnableUI(bool value)
    {
        idNumberEntry.IsEnabled = value;
        passwordEntry.IsEnabled = value;
        submitButton.IsEnabled = value;
        captchaEntry.IsEnabled = value;
        regenerateCaptchaButton.IsEnabled = value;
        submitCaptchaButton.IsEnabled = value;
    }
}