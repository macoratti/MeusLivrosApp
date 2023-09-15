using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeusLivros.MVVM.Models;
using MeusLivros.Services;

namespace MeusLivros.MVVM.ViewModels;

[QueryProperty(nameof(Livro), "LivroObject")]
public partial class UpdateLivroViewModel : ObservableObject
{
    private readonly ILivroService _livroService;

    [ObservableProperty]
    private Livro _livro;

    public UpdateLivroViewModel(ILivroService livroService)
    {
        _livroService = livroService;
    }

    [RelayCommand]
    private async Task UpdateLivro()
    {
        if (!string.IsNullOrEmpty(Livro.Titulo))
        {
            await _livroService.InitializeAsync();
            await _livroService.AtualizaLivroAsync(Livro);

            await Shell.Current.GoToAsync("..");
        }
        else
        {
            await Shell.Current.DisplayAlert("Error", "Livro sem Título", "OK");
        }
    }
}