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

    void OnSubmitCaptcha(object sender, EventArgs e)
    {
        if (captchaEntry.Text == captcha.Value)
        {
            validated = true;
        }
        else
        {
            validated = false;
            // TODO: block the system for 10 sec
            captcha.Generate();
            graphicsView.Invalidate();
            // TODO: let the user know that captcha is wrong
        }
    }
}