using MeusLivros.MVVM.ViewModels;

namespace MeusLivros.MVVM.Views;

public partial class UpdateLivroPage : ContentPage
{
	public UpdateLivroPage(UpdateLivroViewModel updateLivroViewModel)
	{
		InitializeComponent();
		BindingContext = updateLivroViewModel;
	}
}