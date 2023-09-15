using MeusLivros.MVVM.ViewModels;
using MeusLivros.Services;

namespace MeusLivros.MVVM.Views;

public partial class LivrosPage : ContentPage
{
    private readonly ILivroService _livroService;
    public LivrosPage(LivrosViewModel livrosViewModel, 
                      ILivroService livroService)
    {
        InitializeComponent();
        BindingContext = livrosViewModel;
        _livroService = livroService;
    }

    private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var livros = await _livroService.GetLivroTituloAsync(((SearchBar)sender).Text);
        ColView1.ItemsSource = livros;
    }
}