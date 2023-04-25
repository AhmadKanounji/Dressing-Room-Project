namespace Dressing_Room;
using Mopups.Services;

public partial class TermsAndCondition
{
	public TermsAndCondition()
	{
		InitializeComponent();
	}

    void AcceptClicked(System.Object sender, System.EventArgs e)
    {
		MopupService.Instance.PopAllAsync();
    }

    async void DeclineClicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.DisplayAlert("Uh Oh!", "Make sure you read the terms and conditions", "Exit");
    }
}
