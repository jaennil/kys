namespace kysMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Organizer();
        }
    }
}