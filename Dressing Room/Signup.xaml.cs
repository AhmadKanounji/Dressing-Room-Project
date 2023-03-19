using Dressing_Room.ViewModels;

namespace Dressing_Room;

public partial class Signup : ContentPage
{
	public Signup(SignupViewModel signupvm) 
	{
		InitializeComponent();
        this.BindingContext = signupvm;
	}
}