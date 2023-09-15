using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeusLivros.MVVM.Models;
using MeusLivros.Services;

namespace MeusLivros.MVVM.ViewModels;

public partial class AddLivroViewModel : ObservableObject
{
    private readonly ILivroService _livroService;

    [ObservableProperty]
    private string _livroTitulo;
    [ObservableProperty]
    private string _livroAutor;
    [ObservableProperty]
    private string _livroImagemUrl;
    [ObservableProperty]
    private string _livroEmprestadoPara;
    [ObservableProperty]
    private int _livroPaginas;
    [ObservableProperty]
    private bool _livroLeituraConcluida;

    public AddLivroViewModel(ILivroService livroService)
    {
        _livroService = livroService;
    }


    [RelayCommand]
    private async Task AddLivro()
    {
        try
        {
            if (!string.IsNullOrEmpty(LivroTitulo))
            {
                Livro livro = new()
                {
                    Titulo = LivroTitulo,
                    Autor = LivroAutor,
                    ImagemUrl = LivroImagemUrl,
                    EmprestadoPara = LivroEmprestadoPara,
                    Paginas = LivroPaginas,
                    LeituraConcluida = LivroLeituraConcluida
                };

                await _livroService.InitializeAsync();
                await _livroService.CriaLivroAsync(livro);

                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Livro sem Título", "OK");
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
    }
}