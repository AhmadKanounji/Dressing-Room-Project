using Dressing_Room.ViewModels;

namespace Dressing_Room;

public partial class GeneratePage : ContentPage
{
    private GenerateViewModel viewModel;
    public GeneratePage()
    {
        InitializeComponent();
        viewModel = new GenerateViewModel();
        this.BindingContext = viewModel;
    }
}