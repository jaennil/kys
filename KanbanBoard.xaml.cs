namespace kysMaui;

public partial class KanbanBoard : ContentPage
{
    bool button_clicked = false;
    bool move_mode = false;
    public KanbanBoard()
    {
        InitializeComponent();
    }

    private void PointerGestureRecognizer_PointerMoved(object sender, PointerEventArgs e)
    {
        Point? point = e.GetPosition(null);
        //Point? point = e.GetPosition(Button);
        double x = point.Value.X;
        double y = point.Value.Y;
        point_label.Text = x + " " + y;
        if (!move_mode) return;
        if (!button_clicked) return;
        //Point? point = e.GetPosition((View)sender);
        //Point? point = e.GetPosition(absoluteLayout);
        Button.TranslationX = x-verticalStackLayout.Bounds.Width/2;
        Button.TranslationY = y-Button.Bounds.Top*2;
        btn_clicked_label.Text = Button.X + " " + Button.Y;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        button_clicked = !button_clicked;
        //btn_clicked_label.Text = button_clicked.ToString();
    }

    private void Button_Clicked_MoveMode(object sender, EventArgs e)
    {
        move_mode = !move_mode;
        move_mode_label.Text = move_mode.ToString();
        ((Button)sender).Text = move_mode ? "Y" : "N";
    }
}