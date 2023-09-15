using MeusLivros.MVVM.Models;
using SQLite;

namespace MeusLivros.Services;

public class LivroService : ILivroService
{
    private SQLiteAsyncConnection _dbConnection;
    public async Task InitializeAsync()
    {
        await SetUpDb();
    }
    private async Task SetUpDb()
    {
        if (_dbConnection == null)
        {
            string dbPath = Path.Combine(Environment.
            GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LivrosDB.db3");

            _dbConnection = new SQLiteAsyncConnection(dbPath);
            await _dbConnection.CreateTableAsync<Livro>();
        }
    }
    public async Task<int> CriaLivroAsync(Livro livro)
    {
        return await _dbConnection.InsertAsync(livro);
    }

    public async Task<int> DeletaLivroAsync(Livro livro)
    {
        return await _dbConnection.DeleteAsync(livro);
    }
    public async Task<int> AtualizaLivroAsync(Livro livro)
    {
        return await _dbConnection.UpdateAsync(livro);
    }

    public async Task<IEnumerable<Livro>> GetLivrosAsync()
    {
        var livros = await _dbConnection.Table<Livro>().ToListAsync();
        return livros;
    }

    public async Task<IEnumerable<Livro>> GetLivroTituloAsync(string titulo)
    {
       var livros = await _dbConnection.Table<Livro>().Where(x => x.Titulo.Contains(titulo)).ToListAsync();
       return livros;
    }
}
