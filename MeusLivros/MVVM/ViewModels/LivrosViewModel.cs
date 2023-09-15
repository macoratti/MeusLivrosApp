using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeusLivros.MVVM.Models;
using MeusLivros.Services;
using System.Collections.ObjectModel;

namespace MeusLivros.MVVM.ViewModels;

public partial class LivrosViewModel : ObservableObject
{
    private readonly ILivroService _livroService;

    public ObservableCollection<Livro> MeusLivros { get; set; } = new();

    public LivrosViewModel(ILivroService livroService)
    {
        _livroService = livroService;
    }

    [RelayCommand]
    public async Task GetLivros()
    {
        MeusLivros.Clear();

        try
        {
            await _livroService.InitializeAsync();
            var livros = await _livroService.GetLivrosAsync();

            if (livros.Any())
            {
                foreach (var livro in livros)
                {
                    MeusLivros.Add(livro);
                }
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
    }

    [RelayCommand]
    private async Task AddLivro() => await Shell.Current.GoToAsync("AddLivroPage");

    [RelayCommand]
    private async Task DeleteLivro(Livro livro)
    {
        var result = await Shell.Current.DisplayAlert("Deletar", $"Confirma exclusão do livro : \n\n \"{livro.Titulo}\"?", "Sim", "Não");

        if (result is true)
        {
            try
            {
                await _livroService.InitializeAsync();
                await _livroService.DeletaLivroAsync(livro);
                await GetLivros();
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }

    [RelayCommand]
    private async Task UpdateLivro(Livro livro) =>
       await Shell.Current.GoToAsync("UpdateLivroPage", new Dictionary<string, object>
    {
    {"LivroObject", livro }
    });
}
