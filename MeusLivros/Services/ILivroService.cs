using MeusLivros.MVVM.Models;

namespace MeusLivros.Services;

public interface ILivroService
{
    Task InitializeAsync();
    Task<IEnumerable<Livro>> GetLivrosAsync();
    Task<IEnumerable<Livro>> GetLivroTituloAsync(string titulo);
    Task<int> CriaLivroAsync(Livro livro);
    Task<int> DeletaLivroAsync(Livro livro);
    Task<int> AtualizaLivroAsync(Livro livro);
}
