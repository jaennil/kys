namespace kysMaui;

public partial class Authorization : ContentPage
{
	public Authorization()
	{
		InitializeComponent();
	}

    private void Submit(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new EventInfo());
    }
}