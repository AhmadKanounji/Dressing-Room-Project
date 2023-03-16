namespace Dressing_Room;

public partial class Signup : ContentPage
{
	public Signup()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
	 Navigation.PopAsync();
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Navigation.PushAsync(new WardrobePage());
    }
}