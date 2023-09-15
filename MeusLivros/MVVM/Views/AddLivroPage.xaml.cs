using MeusLivros.MVVM.ViewModels;

namespace MeusLivros.MVVM.Views;

public partial class AddLivroPage : ContentPage
{
	public AddLivroPage(AddLivroViewModel addLivroViewModel)
	{
		InitializeComponent();
        BindingContext = addLivroViewModel;
    }
}